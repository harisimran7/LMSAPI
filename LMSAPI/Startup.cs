using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using LMSData;
using Services;
using AutoMapper.Mappers;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using FluentValidation.AspNetCore;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Utf8Json.Resolvers;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace LMSAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.AddDbContext<ILMSDBContext, LMSDBContext>(optionsBuilder =>
            {
                optionsBuilder.UseLazyLoadingProxies(true);
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DBConnection"), option => option.UseRowNumberForPaging());
                //optionsBuilder.UseInMemoryDatabase("testapi");
                //optionsBuilder.UseLazyLoadingProxies();
            });
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "LMSClient";
            });

            #region Swagger

            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization heading",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LMS API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id="Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
            #endregion

            ConfigureDependency(services);
            configureJWTAuthentication(services);
            ConfigureIdentity(services);
            //ConfigureCookie(services);

            #region AutoMapper

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            #endregion AutoMapper
            
            services.AddCors();
            //services.AddCors(options =>
            //{
                
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://example.com"));
            //});
            //.WithHeaders(HeaderNames.ContentType, "x-custom-header");
            

            //services.AddCors(options => options.AddPolicy("AllowAllOrigins",
            //    builder =>
            //    {
            //        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //    }));

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                //options.Filters.Add(new RequireHttpsAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            //Hl7.Fhir.Serialization.FhirJsonSerializer
            //services.AddControllers().AddJsonOptions(options=>options.JsonSerializerOptions.Converters.Add(new Hl7.Fhir.Serialization.FhirJsonSerializer()));
            //    option => option.JsonSerializerOptions.Converters.Add(PrimitiveTypeConverter.));

            

            services.AddControllers().AddMvcOptions(option =>
            {
                option.EnableEndpointRouting = false;
                //option.OutputFormatters.Clear();
                //option.OutputFormatters.Add(new Utf8JsonOutputFormatter(StandardResolver.Default));
                //option.InputFormatters.Clear();
                //option.InputFormatters.Add(new Utf8JsonInputFormatter());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //options.SerializerSettings.Converters.Add(new Hl7.Fhir.Serialization.FhirJsonSerializer());
                // Configure a custom converter
                //options.SerializerOptions.Converters.Add(new Hl7.Fhir.Serialization.FhirJsonSerializer());
            });
            services.AddOData();

            //services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();

            // Workaround: https://github.com/OData/WebApi/issues/1177
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Scorm")),
                    RequestPath = "/Scorm"
            });

            //app.UseRouting();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().Filter().Count().OrderBy();
            });
            app.UseCors();
            //app.UseAuthorization();
            app.UseAuthentication();
            app.UseDefaultFiles();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "LMSClient";

                app.UseSpaStaticFiles();

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                }
                //if (!env.IsDevelopment())
                //{
                //    app.UseSpaStaticFiles();
                //}

            });
        }


        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Services.Model.CourseCategory>("Category");

            return odataBuilder.GetEdmModel();
        }
        private void ConfigureDependency(IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ICourseTopicsService, CourseTopicsService>();
            services.AddScoped<ICourseSectionService, CourseSectionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEmailSender, EmailSender>();

        }

        private void configureJWTAuthentication(IServiceCollection services)
        {

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };


            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;                                

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = false;
                configureOptions.RequireHttpsMetadata = false;
                configureOptions.IncludeErrorDetails = true;
                
                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            // add identity
            /*
            var builder = services.AddIdentityCore<ApplicationUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            */

            services.AddIdentity<LMSData.Model.ApplicationUser, IdentityRole>()
               //.AddUserStore<AMEUserStore>().AddUserManager<AMEUserManager>()
               .AddEntityFrameworkStores<AppIdentityDbContext>()
               .AddDefaultTokenProviders();
            //services.AddScoped<Microsoft.AspNetCore.Identity.SignInManager<AMEUser>, ChiaouSingnInManager>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

        }
    }
}
