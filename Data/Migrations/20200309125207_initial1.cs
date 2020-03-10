using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMSData.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    AliasAR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PhoneResidence = table.Column<string>(nullable: true),
                    PhoneOffice = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Shift = table.Column<string>(nullable: true),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HumanName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ReferenceTable = table.Column<string>(nullable: true),
                    ReferenceColumn = table.Column<string>(nullable: true),
                    ReferenceEntityID = table.Column<string>(nullable: true),
                    Family = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Use = table.Column<int>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    Given = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LookupCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    AliasAR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    AliasAR = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookups_LookupCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "LookupCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PeriodId = table.Column<int>(nullable: true),
                    System = table.Column<int>(nullable: true),
                    Rank = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Use = table.Column<int>(nullable: true),
                    RankElement = table.Column<int>(nullable: false),
                    ContactDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPoints_ContactDetail_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactPoints_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookupValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Parameter1 = table.Column<string>(nullable: true),
                    Parameter2 = table.Column<string>(nullable: true),
                    XML1 = table.Column<string>(nullable: true),
                    XML2 = table.Column<string>(nullable: true),
                    LookupId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupValues_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookupValues_Lookups_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ParentID = table.Column<int>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAR = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCategories_CourseCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    ShortNameAR = table.Column<string>(nullable: true),
                    Visibility = table.Column<int>(nullable: false),
                    DurationId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    CertificateId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAR = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Period_DurationId",
                        column: x => x.DurationId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TitleAR = table.Column<string>(nullable: true),
                    Visibility = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SectionID = table.Column<int>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TitleAR = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionAR = table.Column<string>(nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTopics_CourseCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ReferenceTable = table.Column<string>(nullable: true),
                    ReferenceColumn = table.Column<string>(nullable: true),
                    ReferenceEntityID = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    Creation = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Hash = table.Column<byte[]>(nullable: true),
                    Size = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    CourseTopicsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_CourseTopics_CourseTopicsId",
                        column: x => x.CourseTopicsId,
                        principalTable: "CourseTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MemberID = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    NameId = table.Column<int>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    AliasAR = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    DateofBirth = table.Column<string>(nullable: true),
                    DateofBirthHijri = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    PictureId = table.Column<int>(nullable: true),
                    NationalityIDId = table.Column<int>(nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    ContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_HumanName_NameId",
                        column: x => x.NameId,
                        principalTable: "HumanName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Nationalities_NationalityIDId",
                        column: x => x.NationalityIDId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Attachments_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Use = table.Column<int>(nullable: true),
                    PeriodId = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annotations_Members_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastEditDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    LastEditBy = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameAR = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    AliasAR = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Description", "DescriptionAR", "IDNumber", "ImageId", "IsActive", "LastEditBy", "LastEditDate", "Name", "NameAR", "ParentCategoryId", "ParentID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C01", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dental", null, null, 0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C02", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compliance Department", null, null, 0 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C03", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursing Department", null, null, 0 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C04", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", null, null, 0 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C05", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legal Affairs", null, null, 0 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C06", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical", null, null, 0 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C04-1", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming", null, null, 0 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, "C04-2", null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Networking", null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "HumanName",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "Family", "Given", "IsActive", "LastEditBy", "LastEditDate", "Prefix", "ReferenceColumn", "ReferenceEntityID", "ReferenceTable", "Suffix", "Text", "Use" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Test 1", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Test 1", null }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Alias", "AliasAR", "ContactId", "CreateDate", "CreatedBy", "DateofBirth", "DateofBirthHijri", "Gender", "IsActive", "LastEditBy", "LastEditDate", "MaritalStatus", "MemberID", "NameId", "NationalityIDId", "Password", "PictureId", "Remarks" },
                values: new object[,]
                {
                    { 1, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, 0, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "102121", null, null, null, null, null },
                    { 2, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, 0, false, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "102122", null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MemberId",
                table: "Addresses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PeriodId",
                table: "Addresses",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_AuthorId",
                table: "Annotations",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CourseId",
                table: "Attachments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CourseTopicsId",
                table: "Attachments",
                column: "CourseTopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoints_ContactDetailId",
                table: "ContactPoints",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoints_PeriodId",
                table: "ContactPoints",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_ImageId",
                table: "CourseCategories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_ParentCategoryId",
                table: "CourseCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DurationId",
                table: "Courses",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ImageId",
                table: "Courses",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CourseId",
                table: "CourseSections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTopics_ImageId",
                table: "CourseTopics",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTopics_ParentCategoryId",
                table: "CourseTopics",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_MemberId",
                table: "Designations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_CategoryId",
                table: "Lookups",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupValues_ContactId",
                table: "LookupValues",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupValues_LookupId",
                table: "LookupValues",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ContactId",
                table: "Members",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_NameId",
                table: "Members",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_NationalityIDId",
                table: "Members",
                column: "NationalityIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PictureId",
                table: "Members",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCategories_Attachments_ImageId",
                table: "CourseCategories",
                column: "ImageId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Attachments_CertificateId",
                table: "Courses",
                column: "CertificateId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Attachments_ImageId",
                table: "Courses",
                column: "ImageId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTopics_Attachments_ImageId",
                table: "CourseTopics",
                column: "ImageId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Period_DurationId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Courses_CourseId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_CourseTopics_CourseTopicsId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ContactPoints");

            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "LookupValues");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "HumanName");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "LookupCategories");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseTopics");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Attachments");
        }
    }
}
