using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DigitalDungeon.Models;
using Microsoft.AspNetCore.Identity;

namespace DigitalDungeon.Data;
public class DigitalDungeonDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<PlatformGame> PlatformGames { get; set; }
    public DbSet<UserCategory> UserCategories { get; set; }
    public DbSet<UserFavoriteGame> UserFavoriteGames { get; set; }
    public DbSet<UserGenre> UserGenres { get; set; }

    public DigitalDungeonDbContext(DbContextOptions<DigitalDungeonDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Holds various roles that a user can have
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });


        // Hold login credentials for users
        // Ids for Identity Framework tables are Guids, not ints. Guid (Global Unique Identifier) can be generated
        // with Guid.NewGuid(). Will need to do this when create own data to seed.
        // Password is being hased before storage in the database, and we are retreiving it from the user-secrets
        // so that it is not stored in the GH repo. 
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        // Many-to-many table between roles and users. Defines which users have which roles
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { Id = 1, CategoryName = "Fantasy"},
            new Category { Id = 2, CategoryName = "Sci-Fi"},
            new Category { Id = 3, CategoryName = "Historical"},
            new Category { Id = 4, CategoryName = "Mystery"},
            new Category { Id = 5, CategoryName = "Thriller"},
            new Category { Id = 6, CategoryName = "Comedy"},
            new Category { Id = 7, CategoryName = "Drama"},
            new Category { Id = 8, CategoryName = "Horror"},
            new Category { Id = 9, CategoryName = "Adventure"},
            new Category { Id = 10, CategoryName = "War"},
            new Category { Id = 11, CategoryName = "Survival"},
            new Category { Id = 12, CategoryName = "Building/Construction"},
            new Category { Id = 13, CategoryName = "Art & Creativity"},
            new Category { Id = 14, CategoryName = "Technology & Science"},
            new Category { Id = 15, CategoryName = "Superhero"},
            new Category { Id = 16, CategoryName = "Anime & Manga"},
            new Category { Id = 17, CategoryName = "Western"},
            new Category { Id = 18, CategoryName = "Cartoon & Animation"},
            new Category { Id = 19, CategoryName = "Sports"}
        });

        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre { Id = 1, GenreName = "Action"},
            new Genre { Id = 2, GenreName = "Adventure"},
            new Genre { Id = 3, GenreName = "RPG"},
            new Genre { Id = 4, GenreName = "Simulation"},
            new Genre { Id = 5, GenreName = "Strategy"},
            new Genre { Id = 6, GenreName = "Sports"},
            new Genre { Id = 7, GenreName = "Puzzle"},
            new Genre { Id = 8, GenreName = "Horror"},
            new Genre { Id = 9, GenreName = "Shooter"},
            new Genre { Id = 10, GenreName = "Music/Rhythm"},
            new Genre { Id = 11, GenreName = "Fighting"},
            new Genre { Id = 12, GenreName = "MMO"},
            new Genre { Id = 13, GenreName = "Educational"},
            new Genre { Id = 14, GenreName = "Casual"},
            new Genre { Id = 15, GenreName = "Card & Board Games"},
            new Genre { Id = 16, GenreName = "Party/Mini-Games"},
            new Genre { Id = 17, GenreName = "Battle Royale"},
            new Genre { Id = 18, GenreName = "Sandbox"},
            new Genre { Id = 19, GenreName = "Open World"},
            new Genre { Id = 20, GenreName = "Narrative"}
        });

        // Games
        modelBuilder.Entity<Game>().HasData(new Game[]
        {
            new Game
            {
                Id = 1,
                Title = "The Witcher 3: Wild Hunt",
                CoverImage = "https://cdn.akamai.steamstatic.com/steam/apps/292030/header.jpg?t=1693590732",
                Description = "Embark on a perilous journey as Geralt of Rivia, a monster slayer for hire, in this action RPG set in a dark fantasy world filled with political intrigue and mythical creatures.",
                GenreId = 3,
                CategoryId = 1,
                ReleaseDate = DateTime.Parse("2015-05-19"),
                Developer = "CD Projekt",
                AdminApproval = true
            },

            new Game
            {
                Id = 2,
                Title = "Red Dead Redemption 2",
                CoverImage = "https://news.xbox.com/en-us/wp-content/uploads/sites/2/2020/04/RDR_XBOX_1920X1080-WIRE.jpg",
                Description = "Immerse yourself in the Wild West as Arthur Morgan, an outlaw and member of the Van der Linde gang, in this action-adventure game filled with stunning landscapes, intense gunfights, and a gripping narrative.",
                GenreId = 19,
                CategoryId = 17,
                ReleaseDate = DateTime.Parse("2018-10-26"),
                Developer = "Rockstar Games",
                AdminApproval = true
            },

            new Game
            {
                Id = 3,
                Title = "The Legend of Zelda: Breath of the Wild",
                CoverImage = "https://i.ebayimg.com/images/g/l0kAAOSwT0NkDkQq/s-l1600.jpg",
                Description = "Embark on an epic quest as Link to defeat the ancient evil Calamity Ganon and save the kingdom of Hyrule in this action-adventure game with a vast open world, innovative puzzles, and breathtaking visuals.",
                GenreId = 3,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2017-03-03"),
                Developer = "Nintendo",
                AdminApproval = true
            },

            new Game
            {
                Id = 4,
                Title = "Cyberpunk 2077",
                CoverImage = "https://cdna.artstation.com/p/assets/images/images/033/037/886/4k/artur-tarnowski-malemain.jpg?1608208334",
                Description = "Navigate the dystopian future of Night City as V, a mercenary seeking immortality, in this open-world action-adventure game with a gripping narrative, cybernetic enhancements, and a vibrant, neon-lit city.",
                GenreId = 9,
                CategoryId = 14,
                ReleaseDate = DateTime.Parse("2020-12-10"),
                Developer = "CD Projekt",
                AdminApproval = true
            },

            new Game
            {
                Id = 5,
                Title = "Assassin's Creed Valhalla",
                CoverImage = "https://mp1st.com/wp-content/uploads/2023/01/ac-valhalla-weekly-free-item.jpg",
                Description = "Experience the Viking Age as Eivor, a fierce warrior, and lead your clan to glory in this action RPG with a rich historical setting, intense combat, and the exploration of vast landscapes.",
                GenreId = 3,
                CategoryId = 10,
                ReleaseDate = DateTime.Parse("2020-11-10"),
                Developer = "Ubisoft",
                AdminApproval = true
            },

            new Game
            {
                Id = 6,
                Title = "Fallout 4",
                CoverImage = "https://www.semperludo.com/wp-content/uploads/2016/01/Cover.jpg",
                Description = "Survive and thrive in the post-apocalyptic wasteland as the Sole Survivor in this action RPG with a rich narrative, extensive crafting system, and a world filled with mutated creatures and factions.",
                GenreId = 3,
                CategoryId = 11,
                ReleaseDate = DateTime.Parse("2015-11-10"),
                Developer = "Bethesda Game Studios",
                AdminApproval = true
            },

            new Game
            {
                Id = 7,
                Title = "Overwatch",
                CoverImage = "https://www.hdwallpapers.in/thumbs/2022/tracer_hd_overwatch-t2.jpg",
                Description = "Join the battle as one of the diverse cast of heroes in this team-based multiplayer first-person shooter. Work together with your team to achieve objectives and outsmart the opposing team.",
                GenreId = 9,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2016-05-24"),
                Developer = "Blizzard Entertainment",
                AdminApproval = true
            },

            new Game
            {
                Id = 8,
                Title = "Minecraft",
                CoverImage = "https://i.stack.imgur.com/dqVlX.png",
                Description = "Unleash your creativity and build anything you can imagine in this sandbox game. Explore vast landscapes, mine resources, and survive in a world where your only limit is your imagination.",
                GenreId = 17,
                CategoryId = 12,
                ReleaseDate = DateTime.Parse("2011-11-18"),
                Developer = "Mojang",
                AdminApproval = true
            },

            new Game
            {
                Id = 9,
                Title = "God of War (2018)",
                CoverImage = "https://cdn.vox-cdn.com/thumbor/KVk_5mYKZLSdLIqJfyoiDRSqiEs=/0x0:1357x1037/920x613/filters:focal(571x411:787x627):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/59469955/687474703a2f2f692e696d6775722e636f6d2f476c537665734d2e6a7067.0.jpg",
                Description = "Embark on a journey with Kratos and his son Atreus in this action-adventure game inspired by Norse mythology. Experience intense combat, solve challenging puzzles, and uncover a powerful and emotional narrative.",
                GenreId = 3,
                CategoryId = 15,
                ReleaseDate = DateTime.Parse("2018-04-20"),
                Developer = "Santa Monica Studio",
                AdminApproval = true
            },

            new Game
            {
                Id = 10,
                Title = "The Last of Us Part II",
                CoverImage = "https://www.relyonhorror.com/wp-content/uploads/2020/07/TLOU2-Cover-art-800.jpg",
                Description = "Follow Ellie's journey in this emotionally charged action-adventure game set in a post-apocalyptic world. Navigate a world filled with danger, moral choices, and gripping storytelling.",
                GenreId = 3,
                CategoryId = 1,
                ReleaseDate = DateTime.Parse("2020-06-19"),
                Developer = "Naughty Dog",
                AdminApproval = true
            },

            new Game
            {
                Id = 11,
                Title = "League of Legends",
                CoverImage = "https://cdn.arstechnica.net/wp-content/uploads/2015/02/lol-640x360.png",
                Description = "Enter the world of Runeterra and join the battle in this popular multiplayer online battle arena (MOBA) game. Choose from a diverse cast of champions and engage in strategic team-based gameplay.",
                GenreId = 9,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2009-10-27"),
                Developer = "Riot Games",
                AdminApproval = true
            },

            new Game
            {
                Id = 12,
                Title = "Animal Crossing: New Horizons",
                CoverImage = "https://i.imgur.com/fb3gEHr.jpg",
                Description = "Escape to a deserted island and create your paradise in this charming life simulation game. Customize your island, interact with anthropomorphic animals, and enjoy a relaxing virtual life.",
                GenreId = 13,
                CategoryId = 6,
                ReleaseDate = DateTime.Parse("2020-03-20"),
                Developer = "Nintendo",
                AdminApproval = true
            },

            new Game
            {
                Id = 13,
                Title = "Genshin Impact",
                CoverImage = "https://www.dexerto.com/cdn-cgi/image/width=750,quality=75,format=auto/https://editors.dexerto.com/wp-content/uploads/2022/09/22/Genshin-Impact-voice-actors.jpg",
                Description = "Embark on a journey across the fantasy world of Teyvat as the Traveler. Discover elemental powers, solve puzzles, and unravel the mysteries of this action role-playing game.",
                GenreId = 3,
                CategoryId = 18,
                ReleaseDate = DateTime.Parse("2020-09-28"),
                Developer = "miHoYo",
                AdminApproval = true
            },

            new Game
            {
                Id = 14,
                Title = "Counter-Strike: Global Offensive",
                CoverImage = "https://imageio.forbes.com/specials-images/imageserve/6404b3004f6c70fc388619bd/cs/960x0.jpg?format=jpg&width=1440",
                Description = "Engage in intense multiplayer first-person shooter battles in this classic game. Team up with others or go solo as you compete in various game modes.",
                GenreId = 9,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2012-08-21"),
                Developer = "Valve",
                AdminApproval = true
            },

            new Game
            {
                Id = 15,
                Title = "The Elder Scrolls V: Skyrim",
                CoverImage = "https://skyrimromance.com/wp-content/uploads/2014/03/TES_V_Skyrim_Logo.png",
                Description = "Explore the vast open world of Skyrim, filled with dragons, dungeons, and epic quests. Customize your character, learn powerful shouts, and shape the destiny of Tamriel.",
                GenreId = 3,
                CategoryId = 1,
                ReleaseDate = DateTime.Parse("2011-11-11"),
                Developer = "Bethesda Game Studios",
                AdminApproval = true
            },

            new Game
            {
                Id = 16,
                Title = "FIFA 22",
                CoverImage = "https://library.sportingnews.com/styles/crop_style_16_9_mobile_2x/s3/2021-10/ea-fifa-22-cover-kylian-mbappe_1qeaco87s803l13iu0tnr84jhq.jpg?itok=1ZGp2cjd",
                Description = "Immerse yourself in the world of football with the latest installment of the FIFA series. Experience realistic gameplay, stunning visuals, and compete in various football leagues.",
                GenreId = 6,
                CategoryId = 19,
                ReleaseDate = DateTime.Parse("2021-10-01"),
                Developer = "EA Vancouver",
                AdminApproval = true
            },

            new Game
            {
                Id = 17,
                Title = "Halo Infinite",
                CoverImage = "https://pbs.twimg.com/media/EeSCgeoUwAAoou7?format=jpg&name=large",
                Description = "Join Master Chief in the next chapter of the Halo series. Experience intense first-person shooter action, explore the mysterious ringworld, and battle against the Banished.",
                GenreId = 9,
                CategoryId = 17,
                ReleaseDate = DateTime.Parse("2021-12-08"),
                Developer = "343 Industries",
                AdminApproval = true
            },

            new Game
            {
                Id = 18,
                Title = "Super Mario Odyssey",
                CoverImage = "https://nichegamer.com/wp-content/uploads/2017/10/super-mario-odyssey-10-30-17-1.jpg",
                Description = "Embark on a globe-trotting adventure with Mario and his new ally Cappy. Explore diverse kingdoms, solve puzzles, and rescue Princess Peach from Bowser's clutches.",
                GenreId = 3,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2017-10-27"),
                Developer = "Nintendo",
                AdminApproval = true
            },

            new Game
            {
                Id = 19,
                Title = "Call of Duty: Warzone",
                CoverImage = "https://www.callofduty.com/content/dam/atvi/callofduty/cod-touchui/blog/hero/mw-wz/WZ-Season-Three-Announce-TOUT.jpg",
                Description = "Experience the thrill of battle royale warfare in Call of Duty: Warzone. Compete against other players, strategize with your squad, and be the last team standing.",
                GenreId = 9,
                CategoryId = 17,
                ReleaseDate = DateTime.Parse("2020-03-10"),
                Developer = "Infinity Ward",
                AdminApproval = true
            },

            new Game
            {
                Id = 20,
                Title = "No Man's Sky",
                CoverImage = "https://505games.com/wp-content/uploads/2021/02/NMS_752x430.jpg",
                Description = "Embark on a journey of exploration and survival in an infinite procedurally generated universe. Uncover the mysteries of the cosmos, trade with alien species, and chart your own course.",
                GenreId = 4,
                CategoryId = 17,
                ReleaseDate = DateTime.Parse("2016-08-09"),
                Developer = "Hello Games",
                AdminApproval = true
            },

            new Game
            {
                Id = 21,
                Title = "Dota 2",
                CoverImage = "https://img.redbull.com/images/w_1200/q_auto,f_auto/redbullcom/2014/10/09/1331683687434_2/dota-2-is-unlike-most-games-of-its-kind",
                Description = "Engage in intense multiplayer battles in this popular multiplayer online battle arena (MOBA) game. Choose from a vast roster of heroes and compete in strategic team-based gameplay.",
                GenreId = 9,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2013-07-09"),
                Developer = "Valve",
                AdminApproval = true
            },

            new Game
            {
                Id = 22,
                Title = "Tom Clancy's Rainbow Six Siege",
                CoverImage = "https://fanatical.imgix.net/product/original/2db0a1c1-3719-4270-b610-a8a1f6c6efb1.jpeg?auto=compress,format&w=430&fit=crop&h=242",
                Description = "Join the ranks of elite operators and engage in tactical shooter gameplay. Team up with friends, strategize, and participate in intense close-quarters combat.",
                GenreId = 9,
                CategoryId = 17,
                ReleaseDate = DateTime.Parse("2015-12-01"),
                Developer = "Ubisoft",
                AdminApproval = true
            },

            new Game
            {
                Id = 23,
                Title = "Rust",
                CoverImage = "https://news.xbox.com/en-us/wp-content/uploads/sites/2/2021/03/Rust.jpg",
                Description = "Survive and thrive in a harsh open-world environment in this multiplayer survival game. Form alliances, build bases, and contend with other players in a dynamic and challenging world.",
                GenreId = 17,
                CategoryId = 11,
                ReleaseDate = DateTime.Parse("2018-02-08"),
                Developer = "Facepunch Studios",
                AdminApproval = true
            },

            new Game
            {
                Id = 24,
                Title = "Persona 5",
                CoverImage = "https://www.metacritic.com/a/img/catalog/provider/6/12/6-1-734746-52.jpg",
                Description = "Experience the life of a high school student and a phantom thief in this Japanese role-playing game. Unravel the mysteries of the Metaverse, forge bonds with friends",
                GenreId = 3,
                CategoryId = 7,
                ReleaseDate = DateTime.Parse("2016-09-15"),
                Developer = "Atlus",
                AdminApproval = true
            },

            new Game
            {
                Id = 25,
                Title = "Among Us",
                CoverImage = "https://i.insider.com/5fe2fb7bedf89200180936d9?width=1000&format=jpeg&auto=webp",
                Description = "Join your crewmates in this multiplayer party game of teamwork and betrayal. Complete tasks on a spaceship, but beware of the Impostors among you who seek to eliminate the crew.",
                GenreId = 9,
                CategoryId = 16,
                ReleaseDate = DateTime.Parse("2018-11-16"),
                Developer = "Innersloth",
                AdminApproval = true
            },

        new Game
            {
                Id = 26,
                Title = "Subnautica",
                CoverImage = "https://media.nichegamer.com/wp-content/uploads/2018/01/20150927_SN_LostRiver_Large.jpg",
                Description = "Dive into an alien underwater world and survive the dangers it holds. Collect resources, build submarines, and unravel the mysteries of the ocean planet.",
                GenreId = 4,
                CategoryId = 17,
                ReleaseDate = DateTime.Parse("2018-01-23"),
                Developer = "Unknown Worlds Entertainment",
                AdminApproval = true
        },

        new Game
        {
            Id = 27,
            Title = "Among Trees",
            CoverImage = "https://picfiles.alphacoders.com/228/228393.jpg",
            Description = "Find tranquility in a beautiful, untouched wilderness. Survive, build your cabin, and explore a vibrant forest filled with wildlife and hidden secrets.",
            GenreId = 4,
            CategoryId = 12,
            ReleaseDate = DateTime.Parse("2020-06-13"),
            Developer = "FJRD Interactive",
            AdminApproval = true
        },

        new Game
        {
            Id = 28,
            Title = "Mortal Kombat 11",
            CoverImage = "https://rhodycigar.com/wp-content/uploads/2023/04/Mortal-Kombat-11.jpg",
            Description = "Engage in brutal and cinematic combat in the latest installment of the iconic fighting game series. Experience a gripping story and intense multiplayer battles.",
            GenreId = 11,
            CategoryId = 16,
            ReleaseDate = DateTime.Parse("2019-04-23"),
            Developer = "NetherRealm Studios",
            AdminApproval = true
        },

        new Game
        {
            Id = 29,
            Title = "Terraria",
            CoverImage = "https://static.wikia.nocookie.net/vsbattles/images/c/c4/Terraria.png/revision/latest/scale-to-width-down/1000?cb=20150703181451",
            Description = "Unleash your creativity in this 2D sandbox adventure. Dig, build, and explore in a procedurally generated world filled with monsters, treasures, and secrets.",
            GenreId = 17,
            CategoryId = 12,
            ReleaseDate = DateTime.Parse("2011-05-16"),
            Developer = "Re-Logic",
            AdminApproval = true
        },

        new Game
        {
            Id = 30,
            Title = "Star Wars Jedi: Fallen Order",
            CoverImage = "https://staticg.sportskeeda.com/editor/2022/01/f6d10-16431584756845-1920.jpg",
            Description = "Embark on a Star Wars story as Cal Kestis, a young Jedi Padawan who narrowly escaped the purge of Order 66. Explore the galaxy, master the lightsaber, and uncover the secrets of the Force.",
            GenreId = 3,
            CategoryId = 15,
            ReleaseDate = DateTime.Parse("2019-11-15"),
            Developer = "Respawn Entertainment",
            AdminApproval = true
        }
    });

    // Platforms
modelBuilder.Entity<Platform>().HasData(new Platform[]
{
    new Platform
    {
        Id = 1,
        Name = "PlayStation 4",
        GamesInCatalog = 22,
        Image = "https://s.yimg.com/uu/api/res/1.2/6JOzs1MvVruaXkzUevGl1w--~B/Zmk9ZmlsbDtoPTU2Mjt3PTg3NTthcHBpZD15dGFjaHlvbg--/https://o.aolcdn.com/hss/storage/midas/9750d914c6bd7f7c99ca0a962fd0336a/204374529/anniversary-29-ed.jpg.cf.webp",
        Description = "Sony's fourth home video game console, offering a diverse library of games and multimedia features.",
        ReleaseYear = DateTime.Parse("2013-11-15"),
        EndYear = null
    },

    new Platform
    {
        Id = 2,
        Name = "PC",
        GamesInCatalog = 27,
        Image = "https://thumbor.autonomous.ai/2UM4WvzjJYYsTGIT-WE_pclcnVE=/1600x900/smart/https://cdn.autonomous.ai/static/upload/images/new_post/inspiration-and-tips-for-your-ultimate-desk-gaming-pc-setup-645.jpg",
        Description = "Personal computer platform, providing a wide range of games across genres and capabilities.",
        ReleaseYear = DateTime.Parse("1951-4-12"),
        EndYear = null
    },

    new Platform
    {
        Id = 3,
        Name = "Nintendo Switch",
        GamesInCatalog = 5,
        Image = "https://www.cnet.com/a/img/resize/11e6be46dff67e0081ea28218bd35c25dfb5664d/hub/2021/10/05/83c35cd5-4664-410d-b15a-5c5d706ba3e7/switch-oled-tabletop.jpg?auto=webp&width=1200",
        Description = "Hybrid console offering both traditional home console and portable modes, featuring a diverse game library.",
        ReleaseYear = DateTime.Parse("2017-03-03"),
        EndYear = null
    },

    new Platform
    {
        Id = 4,
        Name = "Xbox One",
        GamesInCatalog = 19,
        Image = "https://cdn.mos.cms.futurecdn.net/9031a5c33a25d2609d046612e4941fb5-970-80.jpg.webp",
        Description = "Microsoft's eighth-generation home video game console, providing a variety of gaming experiences.",
        ReleaseYear = DateTime.Parse("2013-11-22"),
        EndYear = null
    },

    new Platform
    {
        Id = 5,
        Name = "PlayStation 5",
        GamesInCatalog = 9,
        Image = "https://cdn.mos.cms.futurecdn.net/HkdMToxijoHfz4JwUgfh3G-970-80.jpg.webp",
        Description = "Sony's fifth home video game console, introducing advanced graphics and processing capabilities.",
        ReleaseYear = DateTime.Parse("2020-11-12"),
        EndYear = null
    },

    new Platform
    {
        Id = 6,
        Name = "Xbox Series X",
        GamesInCatalog = 8,
        Image = "https://cdn.mos.cms.futurecdn.net/uFicTu3Ti56psJpsTGQ64C-970-80.jpg.webp",
        Description = "Microsoft's ninth-generation home video game console, featuring high-performance gaming experiences.",
        ReleaseYear = DateTime.Parse("2020-11-10"),
        EndYear = null
    },

    new Platform
    {
        Id = 7,
        Name = "Mobile",
        GamesInCatalog = 4,
        Image = "https://i0.wp.com/www.michigandaily.com/wp-content/uploads/2021/03/mobilegames.jpg?resize=1200%2C800&ssl=1",
        Description = "Gaming on mobile devices, offering a wide range of genres and casual gaming experiences.",
        ReleaseYear = null,
        EndYear = null
    },

    new Platform
    {
        Id = 8,
        Name = "PlayStation 3",
        GamesInCatalog = 2,
        Image = "https://www.thefactsite.com/wp-content/uploads/2022/06/sony-playstation-3-facts-740x370.webp",
        Description = "Sony's third home video game console, known for its extensive game library and multimedia capabilities.",
        ReleaseYear = DateTime.Parse("2006-11-17"),
        EndYear = DateTime.Parse("2017-05-29")
    },

    new Platform
    {
        Id = 9,
        Name = "Xbox 360",
        GamesInCatalog = 1,
        Image = "https://guide-images.cdn.ifixit.com/igi/ElNxVpLPiAdTMYYi.standard",
        Description = "Microsoft's seventh-generation home video game console, offering a diverse range of games and online services.",
        ReleaseYear = DateTime.Parse("2005-11-22"),
        EndYear = DateTime.Parse("2016-04-20")
    },

    new Platform
    {
        Id = 10,
        Name = "Wii U",
        GamesInCatalog = 1,
        Image = "https://i.guim.co.uk/img/media/5fe037fa3a336fbfcb48a7b696df601567c7eac5/338_474_5497_3301/master/5497.jpg?width=620&dpr=1&s=none",
        Description = "Nintendo's eighth-generation home video game console, featuring a touchscreen controller and unique gaming experiences.",
        ReleaseYear = DateTime.Parse("2012-11-18"),
        EndYear = DateTime.Parse("2017-01-31")
    },

    new Platform
    {
        Id = 11,
        Name = "PlayStation 2",
        GamesInCatalog = 0,
        Image = "https://www.copetti.org/images/consoles/ps2/international.71e8126f72c944c3b2887685a6583cb0ef47bba48e421618b1e12bdfefff42ae.png",
        Description = "Sony's second home video game console, known for its vast game library and continued support.",
        ReleaseYear = DateTime.Parse("2000-03-04"),
        EndYear = DateTime.Parse("2013-01-04")
    },

    new Platform
    {
        Id = 12,
        Name = "Xbox",
        GamesInCatalog = 0,
        Image = "https://s.yimg.com/ny/api/res/1.2/8_d4UHnlHtSyRzYZHO0arg--/YXBwaWQ9aGlnaGxhbmRlcjt3PTk2MDtoPTU4MDtjZj13ZWJw/https://s.yimg.com/os/creatr-uploaded-images/2021-11/3426e150-463f-11ec-95d7-52c8a77ed51c",
        Description = "Microsoft's first home video game console, introducing Xbox Live and diverse gaming experiences.",
        ReleaseYear = DateTime.Parse("2001-11-15"),
        EndYear = DateTime.Parse("2009-04-15")
    },

    new Platform
    {
        Id = 13,
        Name = "Nintendo 64",
        GamesInCatalog = 0,
        Image = "https://static.wikia.nocookie.net/nintendo/images/0/0c/Nintendo_64_Console_%26_Controller.png/revision/latest/scale-to-width-down/1000?cb=20201214023244&path-prefix=en",
        Description = "Nintendo's fifth home video game console, known for popular titles and innovative 3D gaming experiences.",
        ReleaseYear = DateTime.Parse("1996-09-26"),
        EndYear = DateTime.Parse("2003-11-30")
    },

    new Platform
    {
        Id = 14,
        Name = "Super Nintendo Entertainment System (SNES)",
        GamesInCatalog = 0,
        Image = "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/i.7RfU6LoQ5g/v0/-1x-1.jpg",
        Description = "Nintendo's fourth home video game console, featuring iconic titles and 16-bit gaming experiences.",
        ReleaseYear = DateTime.Parse("1990-08-23"),
        EndYear = DateTime.Parse("2003-09-30")
    },

    new Platform
    {
        Id = 15,
        Name = "Sega Genesis",
        GamesInCatalog = 0,
        Image = "https://media.istockphoto.com/id/458121653/photo/sega-genesis-game-console.jpg?s=1024x1024&w=is&k=20&c=JekrS4bxCZbPxbfvZ6rObQ8O9-szLVYKefv2bGiLyCI=",
        Description = "Sega's fourth-generation home video game console, known for popularizing 16-bit gaming.",
        ReleaseYear = DateTime.Parse("1988-08-14"),
        EndYear = DateTime.Parse("1997-05-30")
    }
});

    modelBuilder.Entity<PlatformGame>().HasData(new PlatformGame[]
    {
        new PlatformGame
        { Id = 1, PlatformId = 2, GameId = 1},
        new PlatformGame
        { Id = 2, PlatformId = 1, GameId = 1},
        new PlatformGame
        { Id = 3, PlatformId = 4, GameId = 1},
        new PlatformGame
        { Id = 4, PlatformId = 3, GameId = 1},
        new PlatformGame
        { Id = 5, PlatformId = 2, GameId = 2},
        new PlatformGame
        { Id = 6, PlatformId = 1, GameId = 2},
        new PlatformGame
        { Id = 7, PlatformId = 4, GameId = 2},
        new PlatformGame
        { Id = 8, PlatformId = 6, GameId = 2},
        new PlatformGame
        { Id = 9, PlatformId = 5, GameId = 2},
        new PlatformGame
        { Id = 10, PlatformId = 3, GameId = 3},
        new PlatformGame
        { Id = 11, PlatformId = 10, GameId = 3},
        new PlatformGame
        { Id = 12, PlatformId = 2, GameId = 4},
        new PlatformGame
        { Id = 13, PlatformId = 1, GameId = 4},
        new PlatformGame
        { Id = 14, PlatformId = 4, GameId = 4},
        new PlatformGame
        { Id = 15, PlatformId = 2, GameId = 5},
        new PlatformGame
        { Id = 16, PlatformId = 1, GameId = 5},
        new PlatformGame
        { Id = 17, PlatformId = 5, GameId = 5},
        new PlatformGame
        { Id = 18, PlatformId = 4, GameId = 5},
        new PlatformGame
        { Id = 19, PlatformId = 6, GameId = 5},
        new PlatformGame
        { Id = 20, PlatformId = 2, GameId = 6},
        new PlatformGame
        { Id = 21, PlatformId = 1, GameId = 6},
        new PlatformGame
        { Id = 22, PlatformId = 4, GameId = 6},
        new PlatformGame
        { Id = 23, PlatformId = 2, GameId = 7},
        new PlatformGame
        { Id = 24, PlatformId = 1, GameId = 7},
        new PlatformGame
        { Id = 25, PlatformId = 4, GameId = 7},
        new PlatformGame
        { Id = 26, PlatformId = 3, GameId = 7},
        new PlatformGame
        { Id = 27, PlatformId = 2, GameId = 8},
        new PlatformGame
        { Id = 28, PlatformId = 1, GameId = 8},
        new PlatformGame
        { Id = 29, PlatformId = 4, GameId = 8},
        new PlatformGame
        { Id = 30, PlatformId = 3, GameId = 8},
        new PlatformGame
        { Id = 31, PlatformId = 7, GameId = 8},
        new PlatformGame
        { Id = 32, PlatformId = 1, GameId = 9},
        new PlatformGame
        { Id = 33, PlatformId = 5, GameId = 9},
        new PlatformGame
        { Id = 34, PlatformId = 2, GameId = 9},
        new PlatformGame
        { Id = 35, PlatformId = 1, GameId = 10},
        new PlatformGame
        { Id = 36, PlatformId = 2, GameId = 10},
        new PlatformGame
        { Id = 37, PlatformId = 5, GameId = 10},
        new PlatformGame
        { Id = 38, PlatformId = 2, GameId = 11},
        new PlatformGame
        { Id = 39, PlatformId = 3, GameId = 12},
        new PlatformGame
        { Id = 40, PlatformId = 2, GameId = 13},
        new PlatformGame
        { Id = 41, PlatformId = 1, GameId = 13},
        new PlatformGame
        { Id = 42, PlatformId = 5, GameId = 13},
        new PlatformGame
        { Id = 43, PlatformId = 7, GameId = 13},
        new PlatformGame
        { Id = 44, PlatformId = 2, GameId = 14},
        new PlatformGame
        { Id = 45, PlatformId = 7, GameId = 14},
        new PlatformGame
        { Id = 46, PlatformId = 2, GameId = 15},
        new PlatformGame
        { Id = 47, PlatformId = 8, GameId = 15},
        new PlatformGame
        { Id = 48, PlatformId = 9, GameId = 15},
        new PlatformGame
        { Id = 49, PlatformId = 1, GameId = 15},
        new PlatformGame
        { Id = 50, PlatformId = 4, GameId = 15},
        new PlatformGame
        { Id = 51, PlatformId = 6, GameId = 15},
        new PlatformGame
        { Id = 52, PlatformId = 2, GameId = 16},
        new PlatformGame
        { Id = 53, PlatformId = 1, GameId = 16},
        new PlatformGame
        { Id = 54, PlatformId = 5, GameId = 16},
        new PlatformGame
        { Id = 55, PlatformId = 4, GameId = 16},
        new PlatformGame
        { Id = 56, PlatformId = 6, GameId = 16},
        new PlatformGame
        { Id = 57, PlatformId = 2, GameId = 17},
        new PlatformGame
        { Id = 58, PlatformId = 6, GameId = 17},
        new PlatformGame
        { Id = 59, PlatformId = 3, GameId = 18},
        new PlatformGame
        { Id = 60, PlatformId = 2, GameId = 19},
        new PlatformGame
        { Id = 61, PlatformId = 1, GameId = 19},
        new PlatformGame
        { Id = 62, PlatformId = 5, GameId = 19},
        new PlatformGame
        { Id = 63, PlatformId = 4, GameId = 19},
        new PlatformGame
        { Id = 64, PlatformId = 6, GameId = 19},
        new PlatformGame
        { Id = 65, PlatformId = 2, GameId = 20},
        new PlatformGame
        { Id = 66, PlatformId = 1, GameId = 20},
        new PlatformGame
        { Id = 67, PlatformId = 4, GameId = 20},
        new PlatformGame
        { Id = 68, PlatformId = 2, GameId = 21},
        new PlatformGame
        { Id = 69, PlatformId = 2, GameId = 22},
        new PlatformGame
        { Id = 70, PlatformId = 1, GameId = 22},
        new PlatformGame
        { Id = 71, PlatformId = 5, GameId = 22},
        new PlatformGame
        { Id = 72, PlatformId = 4, GameId = 22},
        new PlatformGame
        { Id = 73, PlatformId = 6, GameId = 22},
        new PlatformGame
        { Id = 74, PlatformId = 2, GameId = 23},
        new PlatformGame
        { Id = 75, PlatformId = 1, GameId = 23},
        new PlatformGame
        { Id = 76, PlatformId = 4, GameId = 23},
        new PlatformGame
        { Id = 77, PlatformId = 8, GameId = 24},
        new PlatformGame
        { Id = 78, PlatformId = 1, GameId = 24},
        new PlatformGame
        { Id = 79, PlatformId = 2, GameId = 25},
        new PlatformGame
        { Id = 80, PlatformId = 7, GameId = 25},
        new PlatformGame
        { Id = 81, PlatformId = 2, GameId = 26},
        new PlatformGame
        { Id = 82, PlatformId = 1, GameId = 26},
        new PlatformGame
        { Id = 83, PlatformId = 4, GameId = 26},
        new PlatformGame
        { Id = 84, PlatformId = 2, GameId = 27},
        new PlatformGame
        { Id = 85, PlatformId = 2, GameId = 28},
        new PlatformGame
        { Id = 86, PlatformId = 1, GameId = 28},
        new PlatformGame
        { Id = 87, PlatformId = 5, GameId = 28},
        new PlatformGame
        { Id = 88, PlatformId = 4, GameId = 28},
        new PlatformGame
        { Id = 89, PlatformId = 6, GameId = 28},
        new PlatformGame
        { Id = 90, PlatformId = 2, GameId = 29},
        new PlatformGame
        { Id = 91, PlatformId = 1, GameId = 29},
        new PlatformGame
        { Id = 92, PlatformId = 4, GameId = 29},
        new PlatformGame
        { Id = 93, PlatformId = 7, GameId = 29},
        new PlatformGame
        { Id = 94, PlatformId = 2, GameId = 30},
        new PlatformGame
        { Id = 95, PlatformId = 1, GameId = 30},
        new PlatformGame
        { Id = 96, PlatformId = 5, GameId = 30},
        new PlatformGame
        { Id = 97, PlatformId = 3, GameId = 30},
        new PlatformGame
        { Id = 98, PlatformId = 6, GameId = 30}
    });

    modelBuilder.Entity<UserCategory>().HasData(new UserCategory[]
    {
        new UserCategory 
        { Id = 1, CategoryId = 1, UserProfileId = 1},
        new UserCategory
        { Id = 2, CategoryId = 9, UserProfileId = 1},
        new UserCategory
        { Id = 3, CategoryId = 17, UserProfileId = 1}
    });

    modelBuilder.Entity<UserGenre>().HasData(new UserGenre[]
    {
        new UserGenre
        { Id = 1, GenreId = 3, UserProfileId = 1},
        new UserGenre
        { Id = 2, GenreId = 16, UserProfileId = 1},
        new UserGenre
        { Id = 3, GenreId = 19, UserProfileId = 1}
    });

    modelBuilder.Entity<UserFavoriteGame>().HasData(new UserFavoriteGame[]
    {
        new UserFavoriteGame
        { Id = 1, UserProfileId = 1, GameId = 2},
        new UserFavoriteGame
        { Id = 2, UserProfileId = 1, GameId = 9}
    });
}
}