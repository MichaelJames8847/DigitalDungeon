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
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
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
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "07e7a8df-c87a-43ba-8e70-761dfaec5a69", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "8539b938-9c0d-4ea1-bab6-3b20d2167f9a", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEKRfVATHOLxWUSdBvbuwNA2mxDtHa8EwvVZAUaZaJYg0VXv2dwjl8wIww4XJznyAtA==", null, false, "b68cabb7-d71a-4afc-b185-45d9d3134518", false, "Administrator" });

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
                    { 15, "Sega's fourth-generation home video game console, known for popularizing 16-bit gaming.", new DateTime(1997, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://media.istockphoto.com/id/458121653/photo/sega-genesis-game-console.jpg?s=1024x1024&w=is&k=20&c=JekrS4bxCZbPxbfvZ6rObQ8O9-szLVYKefv2bGiLyCI=", "Sega Genesis", new DateTime(1988, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Nintendo's compact disc-based console offering a variety of memorable titles.", new DateTime(2007, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 658, "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/GameCube-Console-Set.png/1200px-GameCube-Console-Set.png", "GameCube", new DateTime(2001, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Sony's first foray into the handheld gaming market, featuring impressive visuals and multimedia capabilities.", new DateTime(2014, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1367, "https://m.media-amazon.com/images/I/615gWr9r13L.jpg", "PlayStation Portable (PSP)", new DateTime(2004, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "SEGA's last home console, known for its innovative games and pioneering online capabilities.", new DateTime(2001, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 620, "https://upload.wikimedia.org/wikipedia/commons/8/81/Dreamcast-Console-Set.jpg", "Dreamcast", new DateTime(1998, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "SEGA's CD-based console known for its arcade ports and unique titles.", new DateTime(2000, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1094, "https://upload.wikimedia.org/wikipedia/commons/2/20/Sega-Saturn-Console-Set-Mk1.png", "Sega Saturn", new DateTime(1994, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Nintendo's greatest handheld gaming console!", new DateTime(2010, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "https://i.kinja-img.com/image/upload/c_fill,f_auto,fl_progressive,g_center,h_675,pg_1,q_80,w_1200/2f4efdaea6323025a083e58ef3ed8207.jpg", "GameBoy Advance", new DateTime(2001, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                    { 29, true, 12, "https://upload.wikimedia.org/wikipedia/en/thumb/1/1a/Terraria_Steam_artwork.jpg/220px-Terraria_Steam_artwork.jpg", "Unleash your creativity in this 2D sandbox adventure. Dig, build, and explore in a procedurally generated world filled with monsters, treasures, and secrets.", "Re-Logic", 17, new DateTime(2011, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terraria" },
                    { 30, true, 15, "https://staticg.sportskeeda.com/editor/2022/01/f6d10-16431584756845-1920.jpg", "Embark on a Star Wars story as Cal Kestis, a young Jedi Padawan who narrowly escaped the purge of Order 66. Explore the galaxy, master the lightsaber, and uncover the secrets of the Force.", "Respawn Entertainment", 3, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Jedi: Fallen Order" },
                    { 31, true, 2, "https://www.gameinformer.com/sites/default/files/styles/full/public/2021/05/05/42f3c027/wallpaper.jpg", "Relive the legend of Commander Shepard in the acclaimed Mass Effect trilogy with modernized graphics and gameplay.", "BioWare", 2, new DateTime(2021, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mass Effect: Legendary Edition" },
                    { 32, true, 9, "https://images4.alphacoders.com/782/782781.png", "Build the farm of your dreams, learn to live off the land, and turn overgrown fields into a thriving home.", "ConcernedApe", 4, new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stardew Valley" },
                    { 33, true, 1, "https://cdn.mobygames.com/covers/7779490-sekiro-shadows-die-twice-xbox-one-front-cover.jpg", "Become the 'one-armed wolf' and embark on a dangerous journey to rescue your kidnapped lord and seek revenge on your enemies.", "FromSoftware", 1, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sekiro: Shadows Die Twice" },
                    { 34, true, 1, "https://files.kstatecollegian.com/2016/04/c0bbe758-529f-4fce-ab50-bd88f75149da.jpg", "Confront a world filled with darkness and despair in this challenging action RPG.", "FromSoftware", 3, new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dark Souls III" },
                    { 35, true, 2, "https://www.virtuosgames.com/wp-content/uploads/2020/06/Horizon-Zero-Dawn-intruder-alert-HD-Wallpapers-copy_0.jpg.webp", "Discover a world ruled by robotic creatures in this post-apocalyptic open-world RPG.", "Guerrilla Games", 19, new DateTime(2017, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horizon Zero Dawn" },
                    { 36, true, 3, "https://img.redbull.com/images/q_auto,f_auto/redbullcom/2016/07/29/1331809222237_2/civilization-vi-changes-a-lot", "Build an empire to withstand the test of time in this strategy game.", "Firaxis Games", 5, new DateTime(2016, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Civilization VI" },
                    { 37, true, 8, "https://cdn.gfinityesports.com/images/ncavvykf/gfinityesports/1fc5cb641d67c39c7f6be4d6b624e884e15e05da-2000x1000.jpg?rect=48,0,1905,1000&w=1200&h=630&auto=format", "Survive deadly hunting games or be the killer in this multiplayer horror game.", "Behaviour Interactive", 8, new DateTime(2016, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dead by Daylight" },
                    { 38, true, 19, "https://cdn.mobygames.com/covers/9632468-rocket-league-playstation-4-front-cover.jpg", "Play a high-powered hybrid of arcade soccer and vehicular mayhem.", "Psyonix", 6, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocket League" },
                    { 39, true, 2, "https://thealternativeafterstory.files.wordpress.com/2020/07/detroit-become-human-1920x1080-connor-kara-markus-2018-playstation-4-13448.jpg?w=750", "Navigate a world on the brink of chaos as androids start feeling emotions.", "Quantic Dream", 20, new DateTime(2018, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Detroit: Become Human" },
                    { 40, true, 3, "https://fanatical.imgix.net/product/original/a00d342a-f87c-4809-853c-f26ef038b39b.jpeg?auto=compress,format&w=430&fit=crop&h=242", "Command one of the game's factions and conquer the realm in this strategy game set in ancient China.", "Creative Assembly", 5, new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Total War: Three Kingdoms" },
                    { 41, true, 8, "https://miro.medium.com/v2/resize:fit:720/format:webp/1*1P8vqZutMNLsQPDRKZ7EXw.png", "Team up with friends to hunt ghosts and discover the type haunting a location.", "Kinetic Games", 8, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phasmophobia" },
                    { 42, true, 1, "https://thumbnails.pcgamingwiki.com/1/14/Final_Fantasy_XV_cover.jpg/300px-Final_Fantasy_XV_cover.jpg", "Join Prince Noctis and his friends on a journey of discovery, love, and despair.", "Square Enix", 3, new DateTime(2016, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final Fantasy XV" },
                    { 43, true, 2, "https://gepig.com/game_cover_460w/6007.jpg", "Enter the arena in this free-to-play Battle Royale game.", "Respawn Entertainment", 17, new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apex Legends" },
                    { 44, true, 1, "https://media.wired.com/photos/5f6cf5ec6f32a729dc0b3a89/master/w_1600,c_limit/Culture_inline_Hades_PackArt.jpg", "Defy the god of death as you hack and slash your way out of the Underworld in this rogue-like dungeon crawler.", "Supergiant Games", 1, new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hades" },
                    { 45, true, 12, "https://upload.wikimedia.org/wikipedia/en/thumb/7/7f/Sims4_Rebrand.png/220px-Sims4_Rebrand.png", "Create and control people, customize their appearances, personalities, and build and furnish their homes.", "Maxis", 4, new DateTime(2014, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Sims 4" },
                    { 46, true, 15, "https://upload.wikimedia.org/wikipedia/en/thumb/8/80/Street_Fighter_V_box_artwork.png/220px-Street_Fighter_V_box_artwork.png", "Experience the intensity of head-to-head battle in the latest edition of the Street Fighter series.", "Capcom", 11, new DateTime(2016, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Street Fighter V" },
                    { 47, true, 19, "https://upload.wikimedia.org/wikipedia/en/thumb/8/87/Forza_Horizon_4_cover.jpg/220px-Forza_Horizon_4_cover.jpg", "Race, stunt, and explore a shared open world in one of the most diverse Forza experiences ever.", "Playground Games", 6, new DateTime(2018, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forza Horizon 4" },
                    { 48, true, 4, "https://upload.wikimedia.org/wikipedia/en/thumb/a/a7/Red_Dead_Redemption.jpg/220px-Red_Dead_Redemption.jpg", "An open-world western game that follows former outlaw John Marston as he hunts down his former gang members.", "Rockstar San Diego", 2, new DateTime(2010, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption" },
                    { 49, true, 9, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0f/Celeste_box_art_full.png/220px-Celeste_box_art_full.png", "Navigate a series of challenging platforming levels on Celeste mountain in this critically acclaimed indie title.", "Maddy Makes Games", 1, new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celeste" },
                    { 50, true, 1, "https://upload.wikimedia.org/wikipedia/en/thumb/1/1b/Monster_Hunter_World_cover_art.jpg/220px-Monster_Hunter_World_cover_art.jpg", "Join the hunt and track down ferocious beasts in vast, living ecosystems.", "Capcom", 1, new DateTime(2018, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monster Hunter: World" },
                    { 51, true, 2, "https://www.godisageek.com/wp-content/uploads/apps.45033.14417244363263575.acb13d5f-45b0-4587-8107-3e760e953737-790x444.jpg", "The sequel to Knights of the Old Republic, delving deeper into the Star Wars lore with a darker narrative and more refined gameplay mechanics.", "Obsidian Entertainment", 3, new DateTime(2004, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Knights of the Old Republic 2: The Sith Lords" },
                    { 52, true, 7, "https://upload.wikimedia.org/wikipedia/en/thumb/1/1f/Dead_cells_cover_art.png/220px-Dead_cells_cover_art.png", "Explore an ever-changing castle filled with cunning foes in this rogue-like, Metroidvania-inspired action platformer.", "Motion Twin", 1, new DateTime(2018, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dead Cells" },
                    { 53, true, 2, "https://mms.businesswire.com/media/20221208006107/en/1660328/4/SWJS_Survivor_Key_Art_Standard%281%29.jpg?download=1", "A hypothetical Star Wars game where Jedi must survive against insurmountable odds.", "Hypothetical Studios", 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Jedi Survivor" },
                    { 54, true, 3, "https://mp1st.com/wp-content/uploads/2021/06/Ghost-of-Tsushima-PC-version.jpg", "Defend your homeland and honor as Jin Sakai during the Mongol invasion of Tsushima in 1274.", "Sucker Punch Productions", 1, new DateTime(2020, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghost of Tsushima" },
                    { 55, true, 2, "https://upload.wikimedia.org/wikipedia/en/thumb/2/22/Death_Stranding.jpg/220px-Death_Stranding.jpg", "Traverse a ravaged American landscape carrying valuable cargo and connecting isolated communities in a post-apocalyptic world.", "Kojima Productions", 2, new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Death Stranding" },
                    { 56, true, 5, "https://cdnb.artstation.com/p/assets/images/images/037/623/545/large/yellowfly-control-key-art-final-portrait.jpg?1620859445", "Navigate a shape-shifting building as Jesse Faden, searching for answers to supernatural mysteries.", "Remedy Entertainment", 1, new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control" },
                    { 57, true, 4, "https://image.api.playstation.com/cdn/EP0965/CUSA05051_00/hDQ0Na70halrmQjBhAJiHfIGCpuouSxs.png?w=620&thumb=false", "Join a group of friends on a trip to an abandoned island, only to encounter supernatural events.", "Night School Studio", 2, new DateTime(2016, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oxenfree" },
                    { 58, true, 4, "https://cdn.mobygames.com/covers/1774827-firewatch-windows-apps-front-cover.png", "Isolated in the Wyoming wilderness, unravel a mystery while working as a fire lookout.", "Campo Santo", 2, new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Firewatch" },
                    { 59, true, 16, "https://upload.wikimedia.org/wikipedia/commons/f/f1/Undertale_cover.jpg?20200103120235", "Navigate the monster-filled underworld and make decisions that will influence the story's outcome.", "Toby Fox", 7, new DateTime(2015, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Undertale" },
                    { 60, true, 5, "https://upload.wikimedia.org/wikipedia/en/5/50/INSIDE_Xbox_One_cover_art.png", "Control a young boy in a dystopic world, solving environmental puzzles and avoiding death.", "Playdead", 1, new DateTime(2016, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inside" },
                    { 61, true, 1, "https://upload.wikimedia.org/wikipedia/en/c/c2/Final_Fantasy_VII_Box_Art.jpg", "Join Cloud Strife and his allies against the corrupt Shinra megacorporation in this iconic JRPG.", "Square", 3, new DateTime(1997, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final Fantasy VII" },
                    { 62, true, 2, "https://images.pushsquare.com/fc8b1298ef3e0/metal-gear-solid-cover.cover_300x.jpg", "Sneak your way through a nuclear facility in Alaska with Solid Snake in this tactical espionage action game.", "Konami", 1, new DateTime(1998, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metal Gear Solid" },
                    { 63, true, 18, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/4c8bec71-cdc3-43cd-a782-9db62157a7cf/d556ki3-ac2771ea-95b9-4f27-a809-7051aaabef80.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzRjOGJlYzcxLWNkYzMtNDNjZC1hNzgyLTlkYjYyMTU3YTdjZlwvZDU1NmtpMy1hYzI3NzFlYS05NWI5LTRmMjctYTgwOS03MDUxYWFhYmVmODAuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.dsndnL5fGBdxMYUNjjc5_oiZ2gClbMNHX2E5eX5bN0w", "Join Mario on a quest to save the princess while navigating a series of diverse worlds.", "Nintendo", 1, new DateTime(1988, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Bros. 3" },
                    { 64, true, 1, "https://www.rpgfan.com/wp-content/uploads/2020/07/Castlevania-Symphony-of-the-Night-Cover-Art-001.jpg", "Explore Dracula's castle as Alucard, seeking to defeat the dark lord.", "Konami", 2, new DateTime(1997, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Castlevania: Symphony of the Night" },
                    { 65, true, 8, "https://cdn.mobygames.com/covers/4480917-resident-evil-4-playstation-2-front-cover.jpg", "Save the president's daughter from a mysterious cult in this action-packed survival horror game.", "Capcom", 1, new DateTime(2005, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil 4" },
                    { 66, true, 5, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/2e3851a3-ebc6-487d-95bd-490844510fac/d3089lp-3ae10c8c-6363-43bc-b8ef-4ef4cbb6cb1b.jpg/v1/fill/w_900,h_669,q_75,strp/street_fighter_2_snesbox_cover_by_hellstinger64_d3089lp-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NjY5IiwicGF0aCI6IlwvZlwvMmUzODUxYTMtZWJjNi00ODdkLTk1YmQtNDkwODQ0NTEwZmFjXC9kMzA4OWxwLTNhZTEwYzhjLTYzNjMtNDNiYy1iOGVmLTRlZjRjYmI2Y2IxYi5qcGciLCJ3aWR0aCI6Ijw9OTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.Fm7WLxAGjPuR7j6fp0y8FPW4rKgVbn62eMe1WFtbfP0", "Engage in fierce one-on-one battles with fighters from around the globe in this iconic fighting game.", "Capcom", 11, new DateTime(1991, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Street Fighter II" },
                    { 67, true, 2, "https://i.redd.it/xtwtloes2z331.jpg", "Join a group of adventurers traveling through time to prevent a global catastrophe.", "Square", 3, new DateTime(1995, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chrono Trigger" },
                    { 68, true, 2, "https://upload.wikimedia.org/wikipedia/en/f/f1/Mega_Man_X_Coverart.png", "Take control of Mega Man X to defeat the rogue Reploids and their leader Sigma.", "Capcom", 1, new DateTime(1993, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mega Man X" },
                    { 69, true, 4, "https://upload.wikimedia.org/wikipedia/en/9/95/Silent_Hill_2.jpg", "Navigate the foggy town of Silent Hill as James Sunderland, searching for your deceased wife.", "Konami", 8, new DateTime(2001, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silent Hill 2" },
                    { 70, true, 1, "https://upload.wikimedia.org/wikipedia/en/1/17/Baldur%27s_Gate_II_-_Shadows_of_Amn_Coverart.png", "Continue the journey in the Forgotten Realms in this classic role-playing game, facing powerful foes and moral decisions.", "BioWare", 3, new DateTime(2000, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baldur's Gate II: Shadows of Amn" },
                    { 71, true, 2, "https://cdn.mobygames.com/promos/527284-metroid-prime-other.jpg", "Explore the alien world of Tallon IV in first-person perspective as Samus Aran, battling space pirates and ancient creatures.", "Retro Studios", 1, new DateTime(2002, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metroid Prime" },
                    { 72, true, 1, "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Delve into the dungeons and battle the forces of evil in this action RPG.", "Blizzard North", 3, new DateTime(2000, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diablo II" },
                    { 73, true, 2, "https://upload.wikimedia.org/wikipedia/en/f/fa/Half-Life_Cover_Art.jpg", "Navigate the research facility Black Mesa after an experiment goes awry, battling aliens and military troops.", "Valve", 9, new DateTime(1998, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Half-Life" },
                    { 74, true, 3, "https://upload.wikimedia.org/wikipedia/en/8/86/Sands_of_time_cover.jpg", "Navigate through palaces and rewind time with a mystical dagger in this action-adventure game.", "Ubisoft Montreal", 2, new DateTime(2003, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prince of Persia: The Sands of Time" },
                    { 75, true, 2, "https://images.nintendolife.com/b056f83e2b311/us.large.jpg", "Guide Samus Aran on planet Zebes in her quest to rescue a baby Metroid from space pirates.", "Nintendo", 2, new DateTime(1994, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Metroid" },
                    { 76, true, 2, "https://upload.wikimedia.org/wikipedia/en/thumb/9/93/StarCraft_box_art.jpg/220px-StarCraft_box_art.jpg", "Engage in interstellar warfare as one of three unique factions: the Terrans, the Protoss, and the Zerg.", "Blizzard Entertainment", 5, new DateTime(1998, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "StarCraft" },
                    { 77, true, 6, "https://upload.wikimedia.org/wikipedia/en/1/1c/LeChuck%27s_Revenge_artwork.jpg", "Join Guybrush Threepwood in his comedic quest to find the mysterious treasure of Big Whoop.", "Lucasfilm Games", 2, new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monkey Island 2: LeChuck's Revenge" },
                    { 78, true, 3, "https://upload.wikimedia.org/wikipedia/en/5/56/Age_of_Empires_II_-_The_Age_of_Kings_Coverart.png", "Lead one of the several civilizations through multiple ages, from the Dark Age to the Imperial Age, and build the greatest empire.", "Ensemble Studios", 5, new DateTime(1999, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Age of Empires II" },
                    { 79, true, 1, "https://upload.wikimedia.org/wikipedia/en/4/4c/Quake1cover.jpg", "Dive into this first-person shooter that's recognized as one of the pioneers of the genre, featuring fast-paced combat and dark gothic atmosphere.", "id Software", 9, new DateTime(1996, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quake" },
                    { 80, true, 12, "https://upload.wikimedia.org/wikipedia/en/d/d4/SimCity_2000_Coverart.png", "Design, build, and manage your very own city in this detailed and captivating city-building simulation game.", "Maxis", 4, new DateTime(1993, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SimCity 2000" },
                    { 81, true, 1, "https://upload.wikimedia.org/wikipedia/en/0/05/Final_Fantasy_VI.jpg", "Embark on an epic journey with a diverse group of characters to stop the malevolent Kefka and save the world.", "Square", 3, new DateTime(1994, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final Fantasy VI" },
                    { 82, null, 15, "https://upload.wikimedia.org/wikipedia/en/0/00/Batman_Arkham_City_Game_Cover.jpg", "In a sprawling open-air prison, Batman confronts some of his most notorious foes while unraveling a deeper conspiracy.", null, 19, new DateTime(2011, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman: Arkham City" },
                    { 83, true, 15, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/1ea08e12-847b-4c43-8433-ff86b833fd7b/dfzv6g2-5a1db4b8-b4aa-46b5-91c4-efbed9c8a53b.jpg/v1/fill/w_890,h_501,q_75,strp/marvel_s_spider_man__2018_video_game__cover__by_blue_leader97_dfzv6g2-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTAxIiwicGF0aCI6IlwvZlwvMWVhMDhlMTItODQ3Yi00YzQzLTg0MzMtZmY4NmI4MzNmZDdiXC9kZnp2NmcyLTVhMWRiNGI4LWI0YWEtNDZiNS05MWM0LWVmYmVkOWM4YTUzYi5qcGciLCJ3aWR0aCI6Ijw9ODkwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.hNBEgPHMdqbOvPWk3EU3FTDq0Jb0j-qNSvQHa1tKxo0", "An action-adventure game that lets players swing through New York City as the iconic superhero Spider-Man.", "Insomniac Games", 1, new DateTime(2018, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel's Spider-Man" },
                    { 84, true, 1, "https://upload.wikimedia.org/wikipedia/en/3/3a/Diablo_Coverart.png", "Descend into the depths of Tristram's Cathedral to defeat the Lord of Terror, Diablo, in this action RPG.", "Blizzard North", 3, new DateTime(1996, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diablo" },
                    { 85, true, 2, "https://upload.wikimedia.org/wikipedia/en/9/91/Systemshock2box.jpg", "Awaken on the starship Von Braun and unravel the mysteries aboard while battling hostile entities.", "Looking Glass Studios, Irrational Games", 3, new DateTime(1999, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "System Shock 2" },
                    { 86, true, 8, "https://upload.wikimedia.org/wikipedia/en/2/29/Doom_II_-_Hell_on_Earth_Coverart.png", "Continue the fight against the demonic invasion as the Doom Slayer in this iconic first-person shooter sequel.", "id Software", 9, new DateTime(1994, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doom II" },
                    { 87, true, 15, "https://i0.wp.com/insider-gaming.com/wp-content/uploads/2023/02/marvels-wolverine-e1675357857901.jpg?fit=1920%2C1079&ssl=1", "An upcoming action game focused on the Marvel superhero Wolverine, promising a deep narrative and brutal gameplay.", "Insomniac Games", 1, null, "Marvel's Wolverine" },
                    { 88, true, 15, "https://upload.wikimedia.org/wikipedia/en/b/b6/Marvel_Vs_Capcom_3_box_artwork.jpg", "The third installment in the crossover fighting game series, featuring characters from both Marvel comics and Capcom games.", "Capcom", 11, new DateTime(2011, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel vs. Capcom 3" },
                    { 89, true, 5, "https://upload.wikimedia.org/wikipedia/en/4/4c/Maxpaynebox.jpg", "Avenge your murdered family and navigate the dark underbelly of New York's criminal world, all while experiencing the innovative bullet-time shooting mechanics.", "Remedy Entertainment", 1, new DateTime(2001, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max Payne" },
                    { 90, null, 2, "https://upload.wikimedia.org/wikipedia/en/8/83/Fallout_3_cover_art.PNG", "In a post-apocalyptic Washington D.C., the player emerges from an underground bunker and ventures into the wasteland to find their missing father.", null, 19, new DateTime(2008, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout 3" },
                    { 91, true, 18, "https://upload.wikimedia.org/wikipedia/en/1/12/Banjo_Kazooie_Cover.png", "Join Banjo and his friend Kazooie in this platforming adventure to save Banjo's sister from the wicked witch Gruntilda.", "Rare", 2, new DateTime(1998, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banjo-Kazooie" },
                    { 92, null, 1, "https://images.igdb.com/igdb/image/upload/t_cover_big_2x/co3klz.jpg", "Play through the final chapters of the Dragon Ball Z story, from the Other World Tournament saga to the Kid Buu saga.", null, 3, new DateTime(2004, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball Z: Buu's Fury" },
                    { 93, true, 2, "https://upload.wikimedia.org/wikipedia/en/4/42/Dxcover.jpg", "Step into the shoes of JC Denton, an augmented agent, in this action RPG that offers multiple ways to approach objectives.", "Ion Storm", 3, new DateTime(2000, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deus Ex" },
                    { 94, null, 1, "https://upload.wikimedia.org/wikipedia/en/e/ed/Kingdom_Hearts_II_%28PS2%29.jpg", "Sora returns to embark on another journey through Disney worlds to combat a new enemy known as the Nobodies.", null, 3, new DateTime(2005, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kingdom Hearts 2" },
                    { 95, true, 10, "https://preview.redd.it/why-does-red-alert-1-have-different-cover-art-for-na-vs-eu-v0-lhrgm7x80aja1.png?width=437&format=png&auto=webp&s=e57109d7c7228e55a62aad0263954306495aa5bd", "Engage in strategic warfare in an alternate history where Einstein tampers with the timeline.", "Westwood Studios", 5, new DateTime(1996, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Command & Conquer: Red Alert" },
                    { 96, null, 1, "https://cdn.vox-cdn.com/thumbor/gwd1KaHU9P3JAROPViQS200wFe8=/0x0:1089x1440/1400x1400/filters:focal(458x770:632x944):format(jpeg)/cdn.vox-cdn.com/uploads/chorus_image/image/54929207/far_cry_5_last_supper_art_1089.0.jpg", "In the fictional Hope County, Montana, the player takes on a doomsday cult known as the Project at Eden's Gate and its charismatic leader.", null, 19, new DateTime(2018, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Far Cry 5" },
                    { 97, true, 2, "https://upload.wikimedia.org/wikipedia/en/d/d1/WingCommanderBox-front.jpg", "Take command of a space fighter in this space combat simulator set in an interstellar war.", "Origin Systems", 1, new DateTime(1990, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wing Commander" },
                    { 98, true, 4, "https://upload.wikimedia.org/wikipedia/en/6/6a/MystCover.png", "Navigate through an interactive landscape and solve puzzles in this groundbreaking point-and-click adventure.", "Cyan", 2, new DateTime(1993, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myst" },
                    { 99, true, 3, "https://upload.wikimedia.org/wikipedia/en/e/ec/Civilization_box_cover.jpg", "Begin in the ancient world and lead your civilization to greatness through centuries in this strategy game.", "MicroProse", 5, new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Civilization" },
                    { 100, null, 5, "https://volumearchives.files.wordpress.com/2016/09/p1_2181074_cbf7574c.jpg?w=1200", "In a cyberpunk future where augmentations divide society, Adam Jensen investigates terrorist attacks with complex conspiracies.", null, 2, new DateTime(2016, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deus Ex: Mankind Divided" },
                    { 101, null, 2, "https://upload.wikimedia.org/wikipedia/en/thumb/3/35/Far_cry_6_cover.jpg/220px-Far_cry_6_cover.jpg", "Set on Yara, a fictional Caribbean island, the player takes on the role of a guerilla fighter aiming to overthrow the oppressive regime of dictator Antón Castillo.", null, 19, new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Far Cry 6" },
                    { 102, true, 15, "https://www.gamespot.com/a/uploads/scale_medium/mig/9/0/6/5/2219065-mkdc_generic_fob.jpg", "A crossover fighting game featuring characters from both the Mortal Kombat series and the DC Universe.", "Midway Games", 11, new DateTime(2008, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mortal Kombat vs. DC Universe" },
                    { 103, null, 15, "https://i0.wp.com/batman-news.com/wp-content/uploads/2013/05/486263.jpg?fit=3000%2C3800&quality=80&strip=info&ssl=1", "A prequel to the series, a young Batman encounters many of his foes for the first time on Christmas Eve.", null, 19, new DateTime(2013, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman: Arkham Origins" },
                    { 104, null, 1, "https://upload.wikimedia.org/wikipedia/en/8/85/Kingdom_Hearts.jpg", "Sora teams up with Donald and Goofy to travel through various Disney worlds and battle the Heartless in order to find his missing friends.", null, 3, new DateTime(2002, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kingdom Hearts" },
                    { 105, true, 15, "https://cdn.shortpixel.ai/spai/q_glossy+w_998+to_webp+ret_img/thecosmiccircus.com/wp-content/uploads/2023/07/Marvels-Spiderman-2-banner-e1690742326962-800x445.jpg", "The sequel to Marvel's Spider-Man, continuing the story of Peter Parker and introducing more characters from the Spider-Man universe.", "Insomniac Games", 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel's Spider-Man 2" },
                    { 106, null, 15, "https://upload.wikimedia.org/wikipedia/en/4/42/Batman_Arkham_Asylum_Videogame_Cover.jpg", "Batman becomes trapped on Arkham Island and must face off against the Joker and a host of other villains he's helped incarcerate.", null, 2, new DateTime(2009, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman: Arkham Asylum" },
                    { 107, true, 5, "https://upload.wikimedia.org/wikipedia/en/4/40/NTSC_Resident_Evil_2_Cover.png", "Navigate through a zombie-infested Raccoon City, playing as both Leon S. Kennedy and Claire Redfield.", "Capcom", 8, new DateTime(1998, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil 2" },
                    { 108, true, 3, "https://upload.wikimedia.org/wikipedia/en/thumb/7/79/The_Oregon_Trail_cover.jpg/220px-The_Oregon_Trail_cover.jpg", "Lead a group of settlers as they travel westward on the historical Oregon Trail in this educational game.", "MECC", 13, new DateTime(1985, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Oregon Trail" },
                    { 109, true, 15, "https://upload.wikimedia.org/wikipedia/en/thumb/c/c0/Avengers_2020_cover_art.png/220px-Avengers_2020_cover_art.png", "An action-adventure game that combines cinematic storytelling with single-player and cooperative gameplay, centered around the iconic Marvel superheroes.", "Crystal Dynamics", 1, new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvel's Avengers" },
                    { 110, true, 5, "https://cdn.mobygames.com/336a5252-abcd-11ed-93d8-02420a000198.webp", "Punch and kick your way through city streets to confront the evil Mr. X in this classic beat 'em up.", "Sega", 1, new DateTime(1992, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Streets of Rage 2" },
                    { 111, null, 6, "https://howlongtobeat.com/games/ARK_Survival_Evolved_header.jpg?width=250", "Stranded on a mysterious island, it's up to you to tame wild dinosaurs, craft tools, and build shelters to survive.", null, 19, new DateTime(2017, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARK: Survival Evolved" },
                    { 112, true, 6, "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Solve puzzles in a comedic adventure where three unlikely friends must stop an evil purple tentacle.", "LucasArts", 14, new DateTime(1993, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Day of the Tentacle" },
                    { 113, null, 2, "https://upload.wikimedia.org/wikipedia/en/thumb/3/34/Fallout_New_Vegas.jpg/220px-Fallout_New_Vegas.jpg", "In post-apocalyptic Mojave Desert, the player takes on the role of a courier seeking vengeance and getting embroiled in factional wars.", null, 19, new DateTime(2010, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fallout: New Vegas" },
                    { 114, null, 1, "https://upload.wikimedia.org/wikipedia/en/5/5c/Kingdom_Hearts_III_box_art.jpg", "Sora and his allies face off against the real Organization XIII in the final battle to thwart Master Xehanort's plan.", null, 3, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kingdom Hearts 3" },
                    { 115, null, 1, "https://upload.wikimedia.org/wikipedia/en/e/e4/Dragon_Ball_Z_Kakarot_logo.png", "Relive the story of Goku in this action RPG that recounts the most memorable events and battles of the Dragon Ball Z saga.", null, 3, new DateTime(2020, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball Z: Kakarot" },
                    { 116, null, 4, "https://upload.wikimedia.org/wikipedia/en/a/a0/DKRboxart.jpg", "Join Diddy Kong and friends in a racing adventure to defeat the intergalactic villain, Wizpig, through various challenges.", null, 11, new DateTime(1997, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diddy Kong Racing" },
                    { 117, true, 18, "https://upload.wikimedia.org/wikipedia/en/6/6a/Super_Mario_64_box_cover.jpg", "Join Mario as he embarks on a 3D platforming adventure through Princess Peach's castle, collecting Power Stars and battling iconic foes to rescue the princess from the clutches of Bowser.", "Nintendo EAD", 2, new DateTime(1996, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario 64" },
                    { 118, true, 1, "https://upload.wikimedia.org/wikipedia/en/5/57/The_Legend_of_Zelda_Ocarina_of_Time.jpg", "Journey with Link through the land of Hyrule in a quest to stop Ganondorf, the Gerudo king, from obtaining the sacred relic known as the Triforce. Utilize the Ocarina to manipulate time, solve puzzles, and face foes in this timeless action-adventure classic.", "Nintendo EAD", 2, new DateTime(1998, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Ocarina of Time" },
                    { 119, true, 2, "https://upload.wikimedia.org/wikipedia/en/5/5c/Halo-_Reach_box_art.png", "Dive into the dramatic events leading up to the original Halo trilogy as Noble Team, a squad of Spartan soldiers, makes its last stand to defend the planet Reach against the relentless Covenant alien force. Experience intense firefights, a compelling narrative, and the tragic tale of sacrifice and heroism.", "Bungie", 9, new DateTime(2010, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halo: Reach" },
                    { 120, true, 14, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/21fba9c1-3f97-4480-b363-c4af09608082/d354rhg-8839c08f-a577-48d1-8596-088ec6ff54cf.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzIxZmJhOWMxLTNmOTctNDQ4MC1iMzYzLWM0YWYwOTYwODA4MlwvZDM1NHJoZy04ODM5YzA4Zi1hNTc3LTQ4ZDEtODU5Ni0wODhlYzZmZjU0Y2YuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.CNqNVaVPbwKm7SbyOjFpf2cw9eNE9WCPyBe_Xc9BmHc", "Trapped in the Aperture Science labs and guided by the malevolent A.I. GLaDOS, players must navigate a series of deadly test chambers using the innovative portal gun. This unique device creates spatial shortcuts, challenging players to think in new dimensions while uncovering the facility's dark secrets.", "Valve Corporation", 7, new DateTime(2007, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portal" },
                    { 121, true, 2, "https://i.insider.com/650222fa992da60019ebdfa7?width=1127&format=jpeg", "An upcoming space-faring RPG set in a new universe, created by Bethesda Game Studios.", "Bethesda Game Studios", 3, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Starfield" },
                    { 122, true, 1, "https://upload.wikimedia.org/wikipedia/en/d/de/Lies_of_p_cover_art.jpg", "An action RPG inspired by the classic tale 'Pinocchio', where you navigate a decaying city in search of your creator.", "Round8 Studio", 3, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lies of P" },
                    { 123, true, 5, "https://upload.wikimedia.org/wikipedia/en/2/2f/Payday_-_The_Heist_%28video_game_box_art%29.jpg", "A cooperative first-person shooter where players take on the role of bank robbers, executing heists and evading the police.", "Overkill Software", 9, new DateTime(2011, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payday" },
                    { 124, true, 5, "https://cdn.cloudflare.steamstatic.com/steam/apps/218620/header.jpg?t=1697648752", "The sequel to Payday, this cooperative first-person shooter allows players to plan and execute detailed heists, facing tougher challenges and more varied missions.", "Overkill Software", 9, new DateTime(2013, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payday 2" },
                    { 125, true, 5, "https://upload.wikimedia.org/wikipedia/en/7/7c/Payday_3_cover_art.jpg", "The third installment in the Payday series, offering more complex heists, better AI, and a refined experience for players.", "Starbreeze Studios", 9, new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payday 3" },
                    { 126, true, 15, "https://vgboxart.com/boxes/360/3279-crackdown.jpg", "An open-world action game where players assume the role of a super-powered agent tasked with taking down criminal syndicates in a futuristic city.", "Realtime Worlds", 1, new DateTime(2007, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crackdown" },
                    { 127, true, 15, "https://thumbnails.pcgamingwiki.com/3/3b/Overwatch_2_cover.jpg/300px-Overwatch_2_cover.jpg", "A team-based first-person shooter sequel that introduces new maps, heroes, and a new game mode called Push.", "Blizzard Entertainment", 9, new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overwatch 2" },
                    { 128, true, 18, "https://upload.wikimedia.org/wikipedia/en/a/ae/DonkeyKong64CoverArt.jpg", "A 3D platformer featuring the famous ape, Donkey Kong, and his friends, as they try to stop King K. Rool.", "Rare", 2, new DateTime(1999, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donkey Kong 64" },
                    { 129, true, 2, "https://m.media-amazon.com/images/I/71dEfKyEz5L.jpg", "A rail shooter where players control Fox McCloud in his Arwing fighter to combat the forces of Andross and save the Lylat system.", "Nintendo", 9, new DateTime(1997, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Starfox 64" },
                    { 130, true, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQm7nIPQFcCUv6e16hjyca_vxHn4ESWIQEu9A&usqp=CAU", "An action RPG set in a vast, interconnected world, blending open-world exploration with intricate combat, and produced in collaboration with George R.R. Martin.", "FromSoftware", 3, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elden Ring" },
                    { 131, true, 18, "https://upload.wikimedia.org/wikipedia/en/7/76/SuperMarioGalaxy.jpg", "A 3D platformer where Mario travels through various galaxies to save Princess Peach from Bowser, featuring unique gravity-based gameplay mechanics.", "Nintendo", 2, new DateTime(2007, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Super Mario Galaxy" },
                    { 132, true, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQne0pmK1qNCTq5FOd3abDcCcfiKSyhXcL3Ew&usqp=CAU", "A challenging action RPG set in the gothic city of Yharnam, plagued by a mysterious illness. Players take on the role of the Hunter to uncover its secrets.", "FromSoftware", 3, new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloodborne" },
                    { 133, true, 7, "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg", "A post-apocalyptic action-adventure game following Joel and Ellie as they journey across a United States overrun by fungal-infected humans.", "Naughty Dog", 2, new DateTime(2013, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us" },
                    { 134, true, 5, "https://upload.wikimedia.org/wikipedia/en/thumb/b/be/GTA3boxcover.jpg/220px-GTA3boxcover.jpg", "The game that ushered in a 3D open-world experience in the Grand Theft Auto series, as players navigate the criminal underworld of Liberty City.", "Rockstar North", 1, new DateTime(2001, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto 3" },
                    { 135, true, 5, "https://upload.wikimedia.org/wikipedia/en/thumb/b/b7/Grand_Theft_Auto_IV_cover.jpg/220px-Grand_Theft_Auto_IV_cover.jpg", "An open-world action-adventure game focusing on the life of Niko Bellic as he arrives in Liberty City and becomes entwined in the world of crime.", "Rockstar North", 1, new DateTime(2008, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grand Theft Auto 4" },
                    { 136, true, 1, "https://upload.wikimedia.org/wikipedia/en/a/a7/Ffxboxart.jpg", "A JRPG following the journey of Tidus and Yuna as they aim to save the world of Spira from an endless cycle of destruction caused by the creature Sin.", "Square Enix", 3, new DateTime(2001, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final Fantasy X" },
                    { 137, true, 1, "https://upload.wikimedia.org/wikipedia/en/f/f8/Shadow_of_the_Colossus_%282005%29_cover.jpg", "An atmospheric action-adventure game where players must defeat colossal creatures known as colossi to resurrect a girl named Mono.", "Team Ico", 2, new DateTime(2005, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shadow of the Colossus" },
                    { 138, true, 2, "https://upload.wikimedia.org/wikipedia/en/thumb/e/e7/The_Outer_Worlds_cover_art.png/220px-The_Outer_Worlds_cover_art.png", "A first-person RPG set in an alternate future space colony, offering players a chance to influence the story based on choices and play style.", "Obsidian Entertainment", 3, new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Outer Worlds" },
                    { 139, true, 2, "https://upload.wikimedia.org/wikipedia/en/6/6d/BioShock_cover.jpg", "Set in the underwater city of Rapture, players explore a dystopian world while facing off against mutated inhabitants and gaining special abilities.", "Irrational Games", 9, new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bioshock" },
                    { 140, true, 2, "https://upload.wikimedia.org/wikipedia/en/a/a3/Official_cover_art_for_Bioshock_Infinite.jpg", "Taking place in the floating city of Columbia, this game expands upon the series' narrative and introduces new characters and gameplay mechanics.", "Irrational Games", 9, new DateTime(2013, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bioshock Infinite" },
                    { 141, true, 7, "https://150044068.v2.pressablecdn.com/wp-content/uploads/0d4244c2fd3525dca5278a1bfa6e6a50608d690ec473e4597f53b76c8211aed4_product_card_v2_mobile_slider_639-639x330.jpg", "A detective role-playing game with a heavy focus on narrative and dialogue choices, set in a unique and gritty urban fantasy world.", "ZA/UM", 3, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco Elysium" },
                    { 142, true, 10, "https://upload.wikimedia.org/wikipedia/en/thumb/c/c1/Red_Dead_Revolver_Coverart.jpg/220px-Red_Dead_Revolver_Coverart.jpg", "A third-person shooter set in the Wild West, tracing the story of Red Harlow and his quest for vengeance.", "Rockstar San Diego", 9, new DateTime(2004, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Revolver" },
                    { 143, true, 6, "https://upload.wikimedia.org/wikipedia/en/6/65/Dishonored_box_art_Bethesda.jpg", "A stealth action-adventure game that lets players take on the role of Corvo, a disgraced guard framed for murder, in a steampunk-inspired city.", "Arkane Studios", 1, new DateTime(2012, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dishonored" },
                    { 144, true, 6, "https://wallpapers.com/images/featured/dishonored-2-pictures-sm14jc0lashvkpci.jpg", "The sequel to Dishonored, allowing players to choose between playing as Corvo or his daughter Emily in a tale of revenge and political intrigue.", "Arkane Studios", 1, new DateTime(2016, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dishonored 2" },
                    { 145, true, 18, "https://cubiccreativity.files.wordpress.com/2022/02/pokemon-red-and-blue-header.jpg", "The original Pokemon games that introduced the world to the beloved franchise, allowing players to capture, train, and battle Pokemon.", "Game Freak", 3, new DateTime(1996, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pokemon Red/Blue" },
                    { 146, true, 5, "https://upload.wikimedia.org/wikipedia/en/8/8f/Metal_Gear_Solid_V_The_Phantom_Pain_cover.png", "An open-world stealth game following Venom Snake as he seeks revenge against those who destroyed his forces during the events of Ground Zeroes.", "Kojima Productions", 1, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metal Gear Solid V: The Phantom Pain" },
                    { 147, true, 2, "https://imageio.forbes.com/specials-images/imageserve/6516be8aa27b6dd6a0e67651/kotor2/960x0.png?format=png&width=1440", "A role-playing game set in the Star Wars universe, taking place thousands of years before the original films, allowing players to shape the fate of the galaxy.", "BioWare", 3, new DateTime(2003, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars: Knights of the Old Republic" },
                    { 148, true, 1, "https://www.giantbomb.com/a/uploads/scale_small/8/87790/1814881-box_dbztlog2.png", "Continue the DBZ saga, spanning from the Frieza saga to the end of the Cell Games.", "Webfoot Technologies", 3, new DateTime(2003, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragon Ball Z: The Legacy of Goku II" },
                    { 149, true, 1, "https://preview.redd.it/nrwhtr50v0t51.jpg?width=256&format=pjpg&auto=webp&s=894462d80ac59ad63eb4d78c2afd1643da3ea949", "In a fantasy world, grow from a young boy into a legendary hero. Every choice impacts your path, reputation, and the evolution of the world around you.", "Lionhead Studios", 19, new DateTime(2004, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fable" },
                    { 150, true, 1, "https://upload.wikimedia.org/wikipedia/en/f/f1/Fableiii.jpg", "Lead a revolution to take control of Albion, then make choices as king or queen that will lead to a thriving nation or its downfall.", "Lionhead Studios", 19, new DateTime(2010, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fable III" }
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
                    { 98, 30, 6 },
                    { 99, 31, 2 },
                    { 100, 31, 1 },
                    { 101, 31, 2 },
                    { 102, 31, 4 },
                    { 103, 31, 5 },
                    { 104, 31, 6 },
                    { 105, 32, 1 },
                    { 106, 32, 2 },
                    { 107, 32, 3 },
                    { 108, 32, 4 },
                    { 109, 32, 5 },
                    { 110, 32, 6 },
                    { 111, 33, 1 },
                    { 112, 33, 2 },
                    { 113, 33, 4 },
                    { 114, 33, 5 },
                    { 115, 33, 6 },
                    { 116, 34, 1 },
                    { 117, 34, 2 },
                    { 118, 34, 4 },
                    { 119, 34, 5 },
                    { 120, 34, 6 },
                    { 121, 35, 1 },
                    { 122, 35, 2 },
                    { 123, 35, 5 },
                    { 124, 36, 1 },
                    { 125, 36, 2 },
                    { 126, 36, 3 },
                    { 127, 36, 4 },
                    { 128, 36, 5 },
                    { 129, 36, 6 },
                    { 130, 37, 1 },
                    { 131, 37, 2 },
                    { 132, 37, 3 },
                    { 133, 37, 4 },
                    { 134, 37, 5 },
                    { 135, 37, 6 },
                    { 136, 38, 1 },
                    { 137, 38, 2 },
                    { 138, 38, 3 },
                    { 139, 38, 4 },
                    { 140, 38, 5 },
                    { 141, 38, 6 },
                    { 142, 39, 1 },
                    { 143, 39, 2 },
                    { 144, 39, 5 },
                    { 145, 40, 2 },
                    { 146, 41, 2 },
                    { 147, 42, 1 },
                    { 148, 42, 2 },
                    { 149, 42, 4 },
                    { 150, 42, 5 },
                    { 151, 43, 1 },
                    { 152, 43, 2 },
                    { 153, 43, 3 },
                    { 154, 43, 4 },
                    { 155, 43, 5 },
                    { 156, 43, 6 },
                    { 157, 44, 1 },
                    { 158, 44, 2 },
                    { 159, 44, 3 },
                    { 160, 44, 4 },
                    { 161, 44, 5 },
                    { 162, 44, 6 },
                    { 163, 45, 1 },
                    { 164, 45, 2 },
                    { 165, 45, 4 },
                    { 166, 45, 5 },
                    { 167, 45, 6 },
                    { 168, 46, 1 },
                    { 169, 46, 2 },
                    { 170, 47, 2 },
                    { 171, 47, 4 },
                    { 172, 47, 5 },
                    { 173, 47, 6 },
                    { 174, 48, 1 },
                    { 175, 48, 8 },
                    { 176, 48, 9 },
                    { 177, 49, 1 },
                    { 178, 49, 2 },
                    { 179, 49, 3 },
                    { 180, 49, 4 },
                    { 181, 49, 5 },
                    { 182, 49, 6 },
                    { 183, 50, 1 },
                    { 184, 50, 2 },
                    { 185, 50, 4 },
                    { 186, 50, 5 },
                    { 187, 50, 6 },
                    { 188, 51, 2 },
                    { 189, 51, 8 },
                    { 190, 51, 9 },
                    { 191, 51, 11 },
                    { 192, 52, 1 },
                    { 193, 52, 2 },
                    { 194, 52, 3 },
                    { 195, 52, 4 },
                    { 196, 52, 5 },
                    { 197, 52, 6 },
                    { 198, 54, 1 },
                    { 199, 54, 5 },
                    { 200, 55, 1 },
                    { 201, 55, 2 },
                    { 202, 55, 5 },
                    { 203, 56, 1 },
                    { 204, 56, 2 },
                    { 205, 56, 4 },
                    { 206, 56, 5 },
                    { 207, 56, 6 },
                    { 208, 57, 1 },
                    { 209, 57, 2 },
                    { 210, 57, 3 },
                    { 211, 57, 4 },
                    { 212, 57, 5 },
                    { 213, 57, 6 },
                    { 214, 58, 1 },
                    { 215, 58, 2 },
                    { 216, 58, 3 },
                    { 217, 58, 4 },
                    { 218, 59, 1 },
                    { 219, 59, 2 },
                    { 220, 59, 3 },
                    { 221, 59, 7 },
                    { 222, 60, 1 },
                    { 223, 60, 2 },
                    { 224, 60, 3 },
                    { 225, 60, 4 },
                    { 226, 60, 5 },
                    { 227, 60, 6 },
                    { 228, 61, 1 },
                    { 229, 61, 2 },
                    { 230, 61, 3 },
                    { 231, 61, 8 },
                    { 232, 61, 12 },
                    { 233, 62, 8 },
                    { 234, 62, 2 },
                    { 235, 62, 12 },
                    { 236, 63, 3 },
                    { 237, 63, 14 },
                    { 238, 63, 15 },
                    { 239, 64, 1 },
                    { 240, 64, 2 },
                    { 241, 64, 8 },
                    { 242, 64, 12 },
                    { 243, 65, 1 },
                    { 244, 65, 2 },
                    { 245, 65, 3 },
                    { 246, 65, 4 },
                    { 247, 65, 5 },
                    { 248, 65, 6 },
                    { 249, 65, 8 },
                    { 250, 65, 9 },
                    { 251, 65, 10 },
                    { 252, 65, 16 },
                    { 253, 66, 2 },
                    { 254, 66, 3 },
                    { 255, 66, 14 },
                    { 256, 66, 15 },
                    { 257, 67, 2 },
                    { 258, 67, 3 },
                    { 259, 67, 14 },
                    { 260, 67, 8 },
                    { 261, 68, 2 },
                    { 262, 68, 3 },
                    { 263, 68, 14 },
                    { 264, 69, 2 },
                    { 265, 69, 8 },
                    { 266, 69, 9 },
                    { 267, 69, 12 },
                    { 268, 70, 2 },
                    { 269, 70, 3 },
                    { 270, 70, 1 },
                    { 271, 70, 4 },
                    { 272, 71, 16 },
                    { 273, 71, 10 },
                    { 274, 72, 2 },
                    { 275, 72, 1 },
                    { 276, 72, 4 },
                    { 277, 72, 5 },
                    { 278, 72, 6 },
                    { 279, 72, 3 },
                    { 280, 73, 2 },
                    { 281, 74, 2 },
                    { 282, 74, 8 },
                    { 283, 74, 12 },
                    { 284, 74, 9 },
                    { 285, 74, 11 },
                    { 286, 75, 3 },
                    { 287, 75, 14 },
                    { 288, 47, 2 },
                    { 289, 77, 2 },
                    { 290, 77, 1 },
                    { 291, 77, 8 },
                    { 292, 77, 9 },
                    { 293, 78, 2 },
                    { 294, 79, 2 },
                    { 295, 79, 1 },
                    { 296, 79, 4 },
                    { 297, 79, 5 },
                    { 298, 79, 6 },
                    { 299, 79, 3 },
                    { 300, 80, 2 },
                    { 301, 80, 12 },
                    { 302, 80, 15 },
                    { 303, 80, 14 },
                    { 304, 81, 2 },
                    { 305, 81, 3 },
                    { 306, 81, 14 },
                    { 307, 81, 12 },
                    { 308, 82, 2 },
                    { 309, 82, 1 },
                    { 310, 82, 4 },
                    { 311, 82, 8 },
                    { 312, 82, 9 },
                    { 313, 83, 1 },
                    { 314, 83, 5 },
                    { 315, 84, 2 },
                    { 316, 85, 2 },
                    { 317, 86, 2 },
                    { 318, 86, 8 },
                    { 319, 86, 9 },
                    { 320, 86, 4 },
                    { 321, 86, 1 },
                    { 322, 86, 3 },
                    { 323, 87, 5 },
                    { 324, 87, 6 },
                    { 325, 88, 2 },
                    { 326, 88, 8 },
                    { 327, 88, 9 },
                    { 328, 88, 1 },
                    { 329, 89, 2 },
                    { 330, 89, 8 },
                    { 331, 89, 12 },
                    { 332, 89, 9 },
                    { 333, 89, 11 },
                    { 334, 90, 2 },
                    { 335, 90, 8 },
                    { 336, 90, 9 },
                    { 337, 90, 4 },
                    { 338, 91, 9 },
                    { 339, 91, 4 },
                    { 340, 91, 13 },
                    { 341, 92, 20 },
                    { 342, 93, 2 },
                    { 343, 94, 2 },
                    { 344, 94, 1 },
                    { 345, 94, 5 },
                    { 346, 94, 12 },
                    { 347, 94, 3 },
                    { 348, 95, 2 },
                    { 349, 95, 19 },
                    { 350, 95, 15 },
                    { 351, 96, 2 },
                    { 352, 96, 1 },
                    { 353, 96, 4 },
                    { 354, 96, 5 },
                    { 355, 96, 6 },
                    { 356, 97, 2 },
                    { 357, 98, 2 },
                    { 358, 98, 3 },
                    { 359, 98, 18 },
                    { 360, 99, 2 },
                    { 361, 100, 2 },
                    { 362, 100, 1 },
                    { 363, 100, 4 },
                    { 364, 100, 8 },
                    { 365, 100, 9 },
                    { 366, 101, 2 },
                    { 367, 101, 1 },
                    { 368, 101, 4 },
                    { 369, 101, 5 },
                    { 370, 101, 6 },
                    { 371, 101, 3 },
                    { 372, 102, 8 },
                    { 373, 102, 9 },
                    { 374, 103, 2 },
                    { 375, 103, 8 },
                    { 376, 103, 9 },
                    { 377, 103, 1 },
                    { 378, 103, 4 },
                    { 379, 104, 2 },
                    { 380, 104, 1 },
                    { 381, 104, 5 },
                    { 382, 104, 12 },
                    { 383, 104, 3 },
                    { 384, 105, 5 },
                    { 385, 106, 2 },
                    { 386, 106, 8 },
                    { 387, 106, 9 },
                    { 388, 106, 1 },
                    { 389, 106, 4 },
                    { 390, 107, 12 },
                    { 391, 107, 2 },
                    { 392, 107, 18 },
                    { 393, 107, 16 },
                    { 394, 108, 2 },
                    { 395, 108, 7 },
                    { 396, 109, 1 },
                    { 397, 109, 4 },
                    { 398, 109, 2 },
                    { 399, 109, 5 },
                    { 400, 109, 6 },
                    { 401, 110, 15 },
                    { 402, 110, 3 },
                    { 403, 110, 2 },
                    { 404, 111, 2 },
                    { 405, 111, 1 },
                    { 406, 111, 4 },
                    { 407, 111, 3 },
                    { 408, 111, 5 },
                    { 409, 111, 6 },
                    { 410, 111, 7 },
                    { 411, 112, 2 },
                    { 412, 112, 1 },
                    { 413, 112, 8 },
                    { 414, 113, 2 },
                    { 415, 113, 8 },
                    { 416, 113, 9 },
                    { 417, 113, 4 },
                    { 418, 114, 1 },
                    { 419, 114, 4 },
                    { 420, 114, 2 },
                    { 421, 114, 5 },
                    { 422, 114, 6 },
                    { 423, 115, 1 },
                    { 424, 115, 4 },
                    { 425, 115, 2 },
                    { 426, 115, 5 },
                    { 427, 115, 6 },
                    { 428, 116, 13 },
                    { 429, 117, 13 },
                    { 430, 117, 3 },
                    { 431, 118, 13 },
                    { 432, 118, 16 },
                    { 433, 119, 9 },
                    { 434, 119, 4 },
                    { 435, 119, 6 },
                    { 436, 119, 2 },
                    { 437, 120, 2 },
                    { 438, 120, 8 },
                    { 439, 120, 9 },
                    { 440, 120, 4 },
                    { 441, 121, 2 },
                    { 442, 121, 6 },
                    { 443, 122, 2 },
                    { 444, 122, 5 },
                    { 445, 122, 6 },
                    { 446, 123, 2 },
                    { 447, 123, 8 },
                    { 448, 123, 9 },
                    { 449, 124, 2 },
                    { 450, 124, 1 },
                    { 451, 124, 4 },
                    { 452, 124, 8 },
                    { 453, 124, 9 },
                    { 454, 124, 3 },
                    { 455, 125, 2 },
                    { 456, 125, 5 },
                    { 457, 125, 6 },
                    { 458, 125, 3 },
                    { 459, 126, 9 },
                    { 460, 126, 4 },
                    { 461, 127, 1 },
                    { 462, 127, 2 },
                    { 463, 127, 4 },
                    { 464, 127, 5 },
                    { 465, 127, 6 },
                    { 466, 127, 3 },
                    { 467, 128, 13 },
                    { 468, 129, 13 },
                    { 469, 130, 1 },
                    { 470, 130, 2 },
                    { 471, 130, 4 },
                    { 472, 130, 5 },
                    { 473, 130, 6 },
                    { 474, 131, 10 },
                    { 475, 131, 11 },
                    { 476, 132, 1 },
                    { 477, 133, 1 },
                    { 478, 133, 8 },
                    { 479, 134, 8 },
                    { 480, 134, 11 },
                    { 481, 134, 9 },
                    { 482, 134, 2 },
                    { 483, 134, 7 },
                    { 484, 135, 8 },
                    { 485, 135, 9 },
                    { 486, 135, 2 },
                    { 487, 136, 11 },
                    { 488, 136, 8 },
                    { 489, 136, 1 },
                    { 490, 136, 3 },
                    { 491, 136, 2 },
                    { 492, 137, 11 },
                    { 493, 137, 8 },
                    { 494, 137, 1 },
                    { 495, 138, 1 },
                    { 496, 138, 2 },
                    { 497, 138, 4 },
                    { 498, 138, 3 },
                    { 499, 139, 8 },
                    { 500, 139, 9 },
                    { 501, 139, 2 },
                    { 502, 139, 1 },
                    { 503, 139, 4 },
                    { 504, 140, 8 },
                    { 505, 140, 9 },
                    { 506, 140, 2 },
                    { 507, 140, 1 },
                    { 508, 140, 4 },
                    { 509, 141, 2 },
                    { 510, 141, 1 },
                    { 511, 141, 5 },
                    { 512, 141, 4 },
                    { 513, 141, 6 },
                    { 514, 141, 3 },
                    { 515, 142, 11 },
                    { 516, 142, 9 },
                    { 517, 142, 8 },
                    { 518, 142, 2 },
                    { 519, 143, 8 },
                    { 520, 143, 9 },
                    { 521, 143, 2 },
                    { 522, 143, 1 },
                    { 523, 143, 4 },
                    { 524, 144, 1 },
                    { 525, 144, 4 },
                    { 526, 144, 2 },
                    { 527, 145, 20 },
                    { 528, 146, 8 },
                    { 529, 146, 9 },
                    { 530, 146, 1 },
                    { 531, 146, 4 },
                    { 532, 146, 2 },
                    { 533, 147, 9 },
                    { 534, 147, 2 },
                    { 535, 147, 7 },
                    { 536, 148, 20 },
                    { 537, 149, 9 },
                    { 538, 149, 2 },
                    { 539, 150, 9 },
                    { 540, 150, 2 },
                    { 541, 53, 6 },
                    { 542, 53, 5 },
                    { 543, 53, 2 }
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
