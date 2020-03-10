using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LMSData.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace LMSData
{
    public class LMSDBContext : DbContext, ILMSDBContext
    {

        public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = true;

            this.Database.EnsureCreated();

        }

        #region General
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        //public DbSet<AttachmentList> AttachmentLists { get; set; }

        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<LookupValue> LookupValues  { get; set; }
        public DbSet<LookupCategory> LookupCategories { get; set; }
        #endregion

        #region Courses
        public DbSet<Calender> Events { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseSections> CourseSections { get; set; }
        public DbSet<CourseTopics> CourseTopics { get; set; }
        #endregion

        #region Users
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetail { get; set; }
        public DbSet<ContactPoint> ContactPoints { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public DbSet<Member> Members { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        #endregion

        #region Utilities

        public IDbContextTransaction BeginTransaction() {

            return this.Database.BeginTransaction();
        }

        public string GetTableName(Type entityType)
        {
            var entity = this.Model.FindEntityType(entityType.ToString());
            return entity.GetTableName();
        }
        public string GetSchemaName(Type entityType)
        {
            var entity = this.Model.FindEntityType(entityType.ToString());
            return entity.GetSchema();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Ignore<EntityBase>();

            //modelBuilder.ApplyConfiguration(new EntityBaseDbConfiguration());
            //modelBuilder.ApplyConfiguration(new AttachmentListDbConfiguration());

            //modelBuilder.ApplyConfiguration(new HumanNameDbConfiguration());
            
            //modelBuilder.ApplyConfiguration(new AddressDbConfiguration());
            //modelBuilder.ApplyConfiguration(new CourseDbConfiguration());
            //modelBuilder.ApplyConfiguration(new MemberDbConfiguration());
            //modelBuilder.ApplyConfiguration(new ContactPointDbConfiguration());
            
            seedData(modelBuilder);

        }
        /*
        /// <summary>
        /// Further configuration the model
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(NopEntityTypeConfiguration<>)
                        || type.BaseType.GetGenericTypeDefinition() == typeof(NopQueryTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
        */
        /// <summary>
        /// Modify the input SQL query by adding passed parameters
        /// </summary>
        /// <param name="sql">The raw SQL query</param>
        /// <param name="parameters">The values to be assigned to parameters</param>
        /// <returns>Modified raw SQL query</returns>
        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            //add parameters to sql
            for (var i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                //whether parameter is output
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }

            return sql;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Generate a script to create all tables for the current model
        /// </summary>
        /// <returns>A SQL script</returns>
        public virtual string GenerateCreateScript()
        {
            return this.Database.GenerateCreateScript();
        }

        /// <summary>
        /// Creates a LINQ query for the query type based on a raw SQL query
        /// </summary>
        /// <typeparam name="TQuery">Query type</typeparam>
        /// <param name="sql">The raw SQL query</param>
        /// <returns>An IQueryable representing the raw SQL query</returns>
        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class
        {
            return this.Query<TQuery>().FromSqlRaw(sql);
        }

        /// <summary>
        /// Creates a LINQ query for the entity based on a raw SQL query
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="sql">The raw SQL query</param>
        /// <param name="parameters">The values to be assigned to parameters</param>
        /// <returns>An IQueryable representing the raw SQL query</returns>
        public virtual IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : EntityBase
        {
            return this.Set<TEntity>().FromSqlRaw(CreateSqlWithParameters(sql, parameters), parameters);
        }

        /// <summary>
        /// Executes the given SQL against the database
        /// </summary>
        /// <param name="sql">The SQL to execute</param>
        /// <param name="doNotEnsureTransaction">true - the transaction creation is not ensured; false - the transaction creation is ensured.</param>
        /// <param name="timeout">The timeout to use for command. Note that the command timeout is distinct from the connection timeout, which is commonly set on the database connection string</param>
        /// <param name="parameters">Parameters to use with the SQL</param>
        /// <returns>The number of rows affected</returns>
        public virtual int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            //set specific command timeout
            var previousTimeout = this.Database.GetCommandTimeout();
            this.Database.SetCommandTimeout(timeout);

            var result = 0;
            if (!doNotEnsureTransaction)
            {
                //use with transaction
                using (var transaction = this.Database.BeginTransaction())
                {
                    result = this.Database.ExecuteSqlCommand(sql, parameters);
                    transaction.Commit();
                }
            }
            else
                result = this.Database.ExecuteSqlCommand(sql, parameters);

            //return previous timeout back
            this.Database.SetCommandTimeout(previousTimeout);

            return result;
        }

        /// <summary>
        /// Detach an entity from the context
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity</param>
        public virtual void Detach<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = this.Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }

        #endregion


        #region Seed Data

        private void seedData(ModelBuilder modelBuilder)
        {
            //return;
            Member member = new Member();

            modelBuilder.Entity<CourseCategory>(x =>
            {
                x.HasData(
                new CourseCategory
                {
                    Id = 1,
                    IDNumber = "C01",
                    Name = "Dental"
                }, new CourseCategory
                {
                    Id = 2,
                    IDNumber = "C02",
                    Name = "Compliance Department"
                }, new CourseCategory
                {
                    Id = 3,
                    IDNumber = "C03",
                    Name = "Nursing Department"
                }, new CourseCategory
                {
                    Id = 4,
                    IDNumber = "C04",
                    Name = "Information Technology"                    
                }, new CourseCategory
                {
                    Id = 5,
                    IDNumber = "C05",
                    Name = "Legal Affairs"
                }, new CourseCategory
                {
                    Id = 6,
                    IDNumber = "C06",
                    Name = "Medical"
                }, new CourseCategory
                {
                    Id = 7,
                    IDNumber = "C04-1",
                    Name = "Programming",
                }, new CourseCategory
                {
                    Id = 8,
                    IDNumber = "C04-2",
                    Name = "Networking"
                });
            });

            modelBuilder.Entity<HumanName>(x =>
            {
                x.HasData(
                new HumanName
                {
                    Id = 1,
                    Text = "Test 1"                    
                }, new HumanName
                {
                    Id = 2,
                    Text = "Test 1"
                });
            });
            modelBuilder.Entity<Member>(x =>
            {
                x.HasData(
                new Member
                {
                    Id = 1,
                    MemberID = "102121",                    
                    //Name = new HumanName { Id = 1, Text = "Test 1"},
                    Gender = Enums.Gender.Male
                }, new Member
                {
                    Id = 2,
                    MemberID = "102122",
                    //Name = new HumanName { Id = 2, Text = "Test 2" },
                    
                    Gender = Enums.Gender.Male
                });
            });
        }
        #endregion
    }
}
