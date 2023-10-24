using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DigitalDungeon.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GamesInCatalog = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ReleaseYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndYear = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CoverImage = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Developer = table.Column<string>(type: "text", nullable: true),
                    AdminApproval = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "integer", nullable: false),
                    PlatformsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlatformId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformGames_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: true),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProfiles_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategories_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    PlatformId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteGames_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFavoriteGames_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGenres_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUserCategory",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "integer", nullable: false),
                    UserCategoriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUserCategory", x => new { x.GamesId, x.UserCategoriesId });
                    table.ForeignKey(
                        name: "FK_GameUserCategory_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUserCategory_UserCategories_UserCategoriesId",
                        column: x => x.UserCategoriesId,
                        principalTable: "UserCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUserGenre",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "integer", nullable: false),
                    UserGenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUserGenre", x => new { x.GamesId, x.UserGenresId });
                    table.ForeignKey(
                        name: "FK_GameUserGenre_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUserGenre_UserGenres_UserGenresId",
                        column: x => x.UserGenresId,
                        principalTable: "UserGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "6ab33abd-41de-42cd-85e1-57d0bf6a17fb", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "0b2928e0-27d5-4d5c-9cab-df642e3ede9f", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEJ7zaDn6DbqDnf0x6A2as9Oj0vLJvQEJQgGXPFZ4j3Of+HLw7JvmeCDx92Tf2BC/MQ==", null, false, "9c968de8-6b8d-4cfe-b7df-2b5d127e89e5", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Sci-Fi" },
                    { 3, "Historical" },
                    { 4, "Mystery" },
                    { 5, "Thriller" },
                    { 6, "Comedy" },
                    { 7, "Drama" },
                    { 8, "Horror" },
                    { 9, "Adventure" },
                    { 10, "War" },
                    { 11, "Survival" },
                    { 12, "Building/Construction" },
                    { 13, "Art & Creativity" },
                    { 14, "Technology & Science" },
                    { 15, "Superhero" },
                    { 16, "Anime & Manga" },
                    { 17, "Western" },
                    { 18, "Cartoon & Animation" },
                    { 19, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "RPG" },
                    { 4, "Simulation" },
                    { 5, "Strategy" },
                    { 6, "Sports" },
                    { 7, "Puzzle" },
                    { 8, "Horror" },
                    { 9, "Shooter" },
                    { 10, "Music/Rhythm" },
                    { 11, "Fighting" },
                    { 12, "MMO" },
                    { 13, "Educational" },
                    { 14, "Casual" },
                    { 15, "Card & Board Games" },
                    { 16, "Party/Mini-Games" },
                    { 17, "Battle Royale" },
                    { 18, "Sandbox" },
                    { 19, "Open World" },
                    { 20, "Narrative" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Description", "EndYear", "GamesInCatalog", "Image", "Name", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, "Sony's fourth home video game console, offering a diverse library of games and multimedia features.", null, 22, "https://s.yimg.com/uu/api/res/1.2/6JOzs1MvVruaXkzUevGl1w--~B/Zmk9ZmlsbDtoPTU2Mjt3PTg3NTthcHBpZD15dGFjaHlvbg--/https://o.aolcdn.com/hss/storage/midas/9750d914c6bd7f7c99ca0a962fd0336a/204374529/anniversary-29-ed.jpg.cf.webp", "PlayStation 4", new DateTime(2013, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Personal computer platform, providing a wide range of games across genres and capabilities.", null, 27, "https://thumbor.autonomous.ai/2UM4WvzjJYYsTGIT-WE_pclcnVE=/1600x900/smart/https://cdn.autonomous.ai/static/upload/images/new_post/inspiration-and-tips-for-your-ultimate-desk-gaming-pc-setup-645.jpg", "PC", new DateTime(1951, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Hybrid console offering both traditional home console and portable modes, featuring a diverse game library.", null, 5, "https://www.cnet.com/a/img/resize/11e6be46dff67e0081ea28218bd35c25dfb5664d/hub/2021/10/05/83c35cd5-4664-410d-b15a-5c5d706ba3e7/switch-oled-tabletop.jpg?auto=webp&width=1200", "Nintendo Switch", new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Microsoft's eighth-generation home video game console, providing a variety of gaming experiences.", null, 19, "https://cdn.mos.cms.futurecdn.net/9031a5c33a25d2609d046612e4941fb5-970-80.jpg.webp", "Xbox One", new DateTime(2013, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Sony's fifth home video game console, introducing advanced graphics and processing capabilities.", null, 9, "https://cdn.mos.cms.futurecdn.net/HkdMToxijoHfz4JwUgfh3G-970-80.jpg.webp", "PlayStation 5", new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Microsoft's ninth-generation home video game console, featuring high-performance gaming experiences.", null, 8, "https://cdn.mos.cms.futurecdn.net/uFicTu3Ti56psJpsTGQ64C-970-80.jpg.webp", "Xbox Series X", new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Gaming on mobile devices, offering a wide range of genres and casual gaming experiences.", null, 4, "https://i0.wp.com/www.michigandaily.com/wp-content/uploads/2021/03/mobilegames.jpg?resize=1200%2C800&ssl=1", "Mobile", null },
                    { 8, "Sony's third home video game console, known for its extensive game library and multimedia capabilities.", new DateTime(2017, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://www.thefactsite.com/wp-content/uploads/2022/06/sony-playstation-3-facts-740x370.webp", "PlayStation 3", new DateTime(2006, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Microsoft's seventh-generation home video game console, offering a diverse range of games and online services.", new DateTime(2016, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://guide-images.cdn.ifixit.com/igi/ElNxVpLPiAdTMYYi.standard", "Xbox 360", new DateTime(2005, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Nintendo's eighth-generation home video game console, featuring a touchscreen controller and unique gaming experiences.", new DateTime(2017, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://i.guim.co.uk/img/media/5fe037fa3a336fbfcb48a7b696df601567c7eac5/338_474_5497_3301/master/5497.jpg?width=620&dpr=1&s=none", "Wii U", new DateTime(2012, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Sony's second home video game console, known for its vast game library and continued support.", new DateTime(2013, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://www.copetti.org/images/consoles/ps2/international.71e8126f72c944c3b2887685a6583cb0ef47bba48e421618b1e12bdfefff42ae.png", "PlayStation 2", new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Microsoft's first home video game console, introducing Xbox Live and diverse gaming experiences.", new DateTime(2009, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://s.yimg.com/ny/api/res/1.2/8_d4UHnlHtSyRzYZHO0arg--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTU4MDtjZj13ZWJw/https://s.yimg.com/os/creatr-uploaded-images/2021-11/3426e150-463f-11ec-95d7-52c8a77ed51c", "Xbox", new DateTime(2001, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Nintendo's fifth home video game console, known for popular titles and innovative 3D gaming experiences.", new DateTime(2003, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://static.wikia.nocookie.net/nintendo/images/0/0c/Nintendo_64_Console_%26_Controller.png/revision/latest/scale-to-width-down/1000?cb=20201214023244&path-prefix=en", "Nintendo 64", new DateTime(1996, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Nintendo's fourth home video game console, featuring iconic titles and 16-bit gaming experiences.", new DateTime(2003, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/i.7RfU6LoQ5g/v0/-1x-1.jpg", "Super Nintendo Entertainment System (SNES)", new DateTime(1990, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Sega's fourth-generation home video game console, known for popularizing 16-bit gaming.", new DateTime(1997, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.istockphoto.com/id/458121653/photo/sega-genesis-game-console.jpg?s=1024x1024&w=is&k=20&c=JekrS4bxCZbPxbfvZ6rObQ8O9-szLVYKefv2bGiLyCI=", "Sega Genesis", new DateTime(1988, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AdminApproval", "CategoryId", "CoverImage", "Description", "Developer", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, true, 1, "https://cdn.akamai.steamstatic.com/steam/apps/292030/header.jpg?t=1693590732", "Embark on a perilous journey as Geralt of Rivia, a monster slayer for hire, in this action RPG set in a dark fantasy world filled with political intrigue and mythical creatures.", "CD Projekt", 3, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Witcher 3: Wild Hunt" },
                    { 2, true, 17, "https://news.xbox.com/en-us/wp-content/uploads/sites/2/2020/04/RDR_XBOX_1920X1080-WIRE.jpg", "Immerse yourself in the Wild West as Arthur Morgan, an outlaw and member of the Van der Linde gang, in this action-adventure game filled with stunning landscapes, intense gunfights, and a gripping narrative.", "Rockstar Games", 19, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2" },
                    { 3, true, 16, "https://i.ebayimg.com/images/g/l0kAAOSwT0NkDkQq/s-l1600.jpg", "Embark on an epic quest as Link to defeat the ancient evil Calamity Ganon and save the kingdom of Hyrule in this action-adventure game with a vast open world, innovative puzzles, and breathtaking visuals.", "Nintendo", 3, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" },
                    { 4, true, 14, "https://cdna.artstation.com/p/assets/images/images/033/037/886/4k/artur-tarnowski-malemain.jpg?1608208334", "Navigate the dystopian future of Night City as V, a mercenary seeking immortality, in this open-world action-adventure game with a gripping narrative, cybernetic enhancements, and a vibrant, neon-lit city.", "CD Projekt", 9, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" },
                    { 5, true, 10, "https://mp1st.com/wp-content/uploads/2023/01/ac-valhalla-weekly-free-item.jpg", "Experience the Viking Age as Eivor, a fierce warrior, and lead your clan to glory in this action RPG with a rich historical setting, intense combat, and the exploration of vast landscapes.", "Ubisoft", 3, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assassin's Creed Valhalla" },
                    { 6, true, 11, "https://www.semperludo.com/wp-content/uploads/2016/01/Cover.jpg", "Survive and thrive in the post-apocalyptic wasteland as the Sole Survivor in this action RPG with a rich narrative, extensive crafting system, and a world filled with mutated creatures and factions.", "Bethesda Game Studios", 3, new DateTime(2015, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout 4" },
                    { 7, true, 16, "https://www.hdwallpapers.in/thumbs/2022/tracer_hd_overwatch-t2.jpg", "Join the battle as one of the diverse cast of heroes in this team-based multiplayer first-person shooter. Work together with your team to achieve objectives and outsmart the opposing team.", "Blizzard Entertainment", 9, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwatch" },
                    { 8, true, 12, "https://i.stack.imgur.com/dqVlX.png", "Unleash your creativity and build anything you can imagine in this sandbox game. Explore vast landscapes, mine resources, and survive in a world where your only limit is your imagination.", "Mojang", 17, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft" },
                    { 9, true, 15, "https://cdn.vox-cdn.com/thumbor/KVk_5mYKZLSdLIqJfyoiDRSqiEs=/0x0:1357x1037/920x613/filters:focal(571x411:787x627):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/59469955/687474703a2f2f692e696d6775722e636f6d2f476c537665734d2e6a7067.0.jpg", "Embark on a journey with Kratos and his son Atreus in this action-adventure game inspired by Norse mythology. Experience intense combat, solve challenging puzzles, and uncover a powerful and emotional narrative.", "Santa Monica Studio", 3, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "God of War (2018)" },
                    { 10, true, 1, "https://www.relyonhorror.com/wp-content/uploads/2020/07/TLOU2-Cover-art-800.jpg", "Follow Ellie's journey in this emotionally charged action-adventure game set in a post-apocalyptic world. Navigate a world filled with danger, moral choices, and gripping storytelling.", "Naughty Dog", 3, new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us Part II" },
                    { 11, true, 16, "https://cdn.arstechnica.net/wp-content/uploads/2015/02/lol-640x360.png", "Enter the world of Runeterra and join the battle in this popular multiplayer online battle arena (MOBA) game. Choose from a diverse cast of champions and engage in strategic team-based gameplay.", "Riot Games", 9, new DateTime(2009, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "League of Legends" },
                    { 12, true, 6, "https://i.imgur.com/fb3gEHr.jpg", "Escape to a deserted island and create your paradise in this charming life simulation game. Customize your island, interact with anthropomorphic animals, and enjoy a relaxing virtual life.", "Nintendo", 13, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animal Crossing: New Horizons" },
                    { 13, true, 18, "https://www.dexerto.com/cdn-cgi/image/width=750,quality=75,format=auto/https://editors.dexerto.com/wp-content/uploads/2022/09/22/Genshin-Impact-voice-actors.jpg", "Embark on a journey across the fantasy world of Teyvat as the Traveler. Discover elemental powers, solve puzzles, and unravel the mysteries of this action role-playing game.", "miHoYo", 3, new DateTime(2020, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Genshin Impact" },
                    { 14, true, 16, "https://imageio.forbes.com/specials-images/imageserve/6404b3004f6c70fc388619bd/cs/960x0.jpg?format=jpg&width=1440", "Engage in intense multiplayer first-person shooter battles in this classic game. Team up with others or go solo as you compete in various game modes.", "Valve", 9, new DateTime(2012, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Counter-Strike: Global Offensive" },
                    { 15, true, 1, "https://skyrimromance.com/wp-content/uploads/2014/03/TES_V_Skyrim_Logo.png", "Explore the vast open world of Skyrim, filled with dragons, dungeons, and epic quests. Customize your character, learn powerful shouts, and shape the destiny of Tamriel.", "Bethesda Game Studios", 3, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Elder Scrolls V: Skyrim" },
                    { 16, true, 19, "https://library.sportingnews.com/styles/crop_style_16_9_mobile_2x/s3/2021-10/ea-fifa-22-cover-kylian-mbappe_1qeaco87s803l13iu0tnr84jhq.jpg?itok=1ZGp2cjd", "Immerse yourself in the world of football with the latest installment of the FIFA series. Experience realistic gameplay, stunning visuals, and compete in various football leagues.", "EA Vancouver", 6, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FIFA 22" },
                    { 17, true, 17, "https://pbs.twimg.com/media/EeSCgeoUwAAoou7?format=jpg&name=large", "Join Master Chief in the next chapter of the Halo series. Experience intense first-person shooter action, explore the mysterious ringworld, and battle against the Banished.", "343 Industries", 9, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halo Infinite" },
                    { 18, true, 16, "https://nichegamer.com/wp-content/uploads/2017/10/super-mario-odyssey-10-30-17-1.jpg", "Embark on a globe-trotting adventure with Mario and his new ally Cappy. Explore diverse kingdoms, solve puzzles, and rescue Princess Peach from Bowser's clutches.", "Nintendo", 3, new DateTime(2017, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Odyssey" },
                    { 19, true, 17, "https://www.callofduty.com/content/dam/atvi/callofduty/cod-touchui/blog/hero/mw-wz/WZ-Season-Three-Announce-TOUT.jpg", "Experience the thrill of battle royale warfare in Call of Duty: Warzone. Compete against other players, strategize with your squad, and be the last team standing.", "Infinity Ward", 9, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call of Duty: Warzone" },
                    { 20, true, 17, "https://505games.com/wp-content/uploads/2021/02/NMS_752x430.jpg", "Embark on a journey of exploration and survival in an infinite procedurally generated universe. Uncover the mysteries of the cosmos, trade with alien species, and chart your own course.", "Hello Games", 4, new DateTime(2016, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Man's Sky" },
                    { 21, true, 16, "https://img.redbull.com/images/w_1200/q_auto,f_auto/redbullcom/2014/10/09/1331683687434_2/dota-2-is-unlike-most-games-of-its-kind", "Engage in intense multiplayer battles in this popular multiplayer online battle arena (MOBA) game. Choose from a vast roster of heroes and compete in strategic team-based gameplay.", "Valve", 9, new DateTime(2013, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dota 2" },
                    { 22, true, 17, "https://fanatical.imgix.net/product/original/2db0a1c1-3719-4270-b610-a8a1f6c6efb1.jpeg?auto=compress,format&w=430&fit=crop&h=242", "Join the ranks of elite operators and engage in tactical shooter gameplay. Team up with friends, strategize, and participate in intense close-quarters combat.", "Ubisoft", 9, new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Clancy's Rainbow Six Siege" },
                    { 23, true, 11, "https://news.xbox.com/en-us/wp-content/uploads/sites/2/2021/03/Rust.jpg", "Survive and thrive in a harsh open-world environment in this multiplayer survival game. Form alliances, build bases, and contend with other players in a dynamic and challenging world.", "Facepunch Studios", 17, new DateTime(2018, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rust" },
                    { 24, true, 7, "https://www.metacritic.com/a/img/catalog/provider/6/12/6-1-734746-52.jpg", "Experience the life of a high school student and a phantom thief in this Japanese role-playing game. Unravel the mysteries of the Metaverse, forge bonds with friends", "Atlus", 3, new DateTime(2016, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Persona 5" },
                    { 25, true, 16, "https://i.insider.com/5fe2fb7bedf89200180936d9?width=1000&format=jpeg&auto=webp", "Join your crewmates in this multiplayer party game of teamwork and betrayal. Complete tasks on a spaceship, but beware of the Impostors among you who seek to eliminate the crew.", "Innersloth", 9, new DateTime(2018, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Among Us" },
                    { 26, true, 17, "https://media.nichegamer.com/wp-content/uploads/2018/01/20150927_SN_LostRiver_Large.jpg", "Dive into an alien underwater world and survive the dangers it holds. Collect resources, build submarines, and unravel the mysteries of the ocean planet.", "Unknown Worlds Entertainment", 4, new DateTime(2018, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subnautica" },
                    { 27, true, 12, "https://picfiles.alphacoders.com/228/228393.jpg", "Find tranquility in a beautiful, untouched wilderness. Survive, build your cabin, and explore a vibrant forest filled with wildlife and hidden secrets.", "FJRD Interactive", 4, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Among Trees" },
                    { 28, true, 16, "https://rhodycigar.com/wp-content/uploads/2023/04/Mortal-Kombat-11.jpg", "Engage in brutal and cinematic combat in the latest installment of the iconic fighting game series. Experience a gripping story and intense multiplayer battles.", "NetherRealm Studios", 11, new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mortal Kombat 11" },
                    { 29, true, 12, "https://static.wikia.nocookie.net/vsbattles/images/c/c4/Terraria.png/revision/latest/scale-to-width-down/1000?cb=20150703181451", "Unleash your creativity in this 2D sandbox adventure. Dig, build, and explore in a procedurally generated world filled with monsters, treasures, and secrets.", "Re-Logic", 17, new DateTime(2011, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terraria" },
                    { 30, true, 15, "https://staticg.sportskeeda.com/editor/2022/01/f6d10-16431584756845-1920.jpg", "Embark on a Star Wars story as Cal Kestis, a young Jedi Padawan who narrowly escaped the purge of Order 66. Explore the galaxy, master the lightsaber, and uncover the secrets of the Force.", "Respawn Entertainment", 3, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Jedi: Fallen Order" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "GameId", "GenreId", "IdentityUserId", "LastName" },
                values: new object[] { 1, "101 Main Street", "Admina", null, null, "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" });

            migrationBuilder.InsertData(
                table: "PlatformGames",
                columns: new[] { "Id", "GameId", "PlatformId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 1 },
                    { 3, 1, 4 },
                    { 4, 1, 3 },
                    { 5, 2, 2 },
                    { 6, 2, 1 },
                    { 7, 2, 4 },
                    { 8, 2, 6 },
                    { 9, 2, 5 },
                    { 10, 3, 3 },
                    { 11, 3, 10 },
                    { 12, 4, 2 },
                    { 13, 4, 1 },
                    { 14, 4, 4 },
                    { 15, 5, 2 },
                    { 16, 5, 1 },
                    { 17, 5, 5 },
                    { 18, 5, 4 },
                    { 19, 5, 6 },
                    { 20, 6, 2 },
                    { 21, 6, 1 },
                    { 22, 6, 4 },
                    { 23, 7, 2 },
                    { 24, 7, 1 },
                    { 25, 7, 4 },
                    { 26, 7, 3 },
                    { 27, 8, 2 },
                    { 28, 8, 1 },
                    { 29, 8, 4 },
                    { 30, 8, 3 },
                    { 31, 8, 7 },
                    { 32, 9, 1 },
                    { 33, 9, 5 },
                    { 34, 9, 2 },
                    { 35, 10, 1 },
                    { 36, 10, 2 },
                    { 37, 10, 5 },
                    { 38, 11, 2 },
                    { 39, 12, 3 },
                    { 40, 13, 2 },
                    { 41, 13, 1 },
                    { 42, 13, 5 },
                    { 43, 13, 7 },
                    { 44, 14, 2 },
                    { 45, 14, 7 },
                    { 46, 15, 2 },
                    { 47, 15, 8 },
                    { 48, 15, 9 },
                    { 49, 15, 1 },
                    { 50, 15, 4 },
                    { 51, 15, 6 },
                    { 52, 16, 2 },
                    { 53, 16, 1 },
                    { 54, 16, 5 },
                    { 55, 16, 4 },
                    { 56, 16, 6 },
                    { 57, 17, 2 },
                    { 58, 17, 6 },
                    { 59, 18, 3 },
                    { 60, 19, 2 },
                    { 61, 19, 1 },
                    { 62, 19, 5 },
                    { 63, 19, 4 },
                    { 64, 19, 6 },
                    { 65, 20, 2 },
                    { 66, 20, 1 },
                    { 67, 20, 4 },
                    { 68, 21, 2 },
                    { 69, 22, 2 },
                    { 70, 22, 1 },
                    { 71, 22, 5 },
                    { 72, 22, 4 },
                    { 73, 22, 6 },
                    { 74, 23, 2 },
                    { 75, 23, 1 },
                    { 76, 23, 4 },
                    { 77, 24, 8 },
                    { 78, 24, 1 },
                    { 79, 25, 2 },
                    { 80, 25, 7 },
                    { 81, 26, 2 },
                    { 82, 26, 1 },
                    { 83, 26, 4 },
                    { 84, 27, 2 },
                    { 85, 28, 2 },
                    { 86, 28, 1 },
                    { 87, 28, 5 },
                    { 88, 28, 4 },
                    { 89, 28, 6 },
                    { 90, 29, 2 },
                    { 91, 29, 1 },
                    { 92, 29, 4 },
                    { 93, 29, 7 },
                    { 94, 30, 2 },
                    { 95, 30, 1 },
                    { 96, 30, 5 },
                    { 97, 30, 3 },
                    { 98, 30, 6 }
                });

            migrationBuilder.InsertData(
                table: "UserCategories",
                columns: new[] { "Id", "CategoryId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 9, 1 },
                    { 3, 17, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserFavoriteGames",
                columns: new[] { "Id", "GameId", "PlatformId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 2, null, 1 },
                    { 2, 9, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGenres",
                columns: new[] { "Id", "GenreId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 16, 1 },
                    { 3, 19, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformsId",
                table: "GamePlatform",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUserCategory_UserCategoriesId",
                table: "GameUserCategory",
                column: "UserCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUserGenre_UserGenresId",
                table: "GameUserGenre",
                column: "UserGenresId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGames_GameId",
                table: "PlatformGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformGames_PlatformId",
                table: "PlatformGames",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_CategoryId",
                table: "UserCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_UserProfileId",
                table: "UserCategories",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteGames_GameId",
                table: "UserFavoriteGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteGames_PlatformId",
                table: "UserFavoriteGames",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteGames_UserProfileId",
                table: "UserFavoriteGames",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenres_GenreId",
                table: "UserGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenres_UserProfileId",
                table: "UserGenres",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_GameId",
                table: "UserProfiles",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_GenreId",
                table: "UserProfiles",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GameUserCategory");

            migrationBuilder.DropTable(
                name: "GameUserGenre");

            migrationBuilder.DropTable(
                name: "PlatformGames");

            migrationBuilder.DropTable(
                name: "UserFavoriteGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserCategories");

            migrationBuilder.DropTable(
                name: "UserGenres");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
