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
            CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/1/1a/Terraria_Steam_artwork.jpg/220px-Terraria_Steam_artwork.jpg",
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
        },

        new Game
    {
        Id = 31,
        Title = "Mass Effect: Legendary Edition",
        CoverImage = "https://www.gameinformer.com/sites/default/files/styles/full/public/2021/05/05/42f3c027/wallpaper.jpg",
        Description = "Relive the legend of Commander Shepard in the acclaimed Mass Effect trilogy with modernized graphics and gameplay.",
        GenreId = 2, // Adventure
        CategoryId = 2, // Sci-Fi
        ReleaseDate = DateTime.Parse("2021-05-14"),
        Developer = "BioWare",
        AdminApproval = true
    },
    new Game
    {
        Id = 32,
        Title = "Stardew Valley",
        CoverImage = "https://images4.alphacoders.com/782/782781.png",
        Description = "Build the farm of your dreams, learn to live off the land, and turn overgrown fields into a thriving home.",
        GenreId = 4, // Simulation
        CategoryId = 9, // Adventure
        ReleaseDate = DateTime.Parse("2016-02-26"),
        Developer = "ConcernedApe",
        AdminApproval = true
    },
    new Game
    {
        Id = 33,
        Title = "Sekiro: Shadows Die Twice",
        CoverImage = "https://cdn.mobygames.com/covers/7779490-sekiro-shadows-die-twice-xbox-one-front-cover.jpg",
        Description = "Become the 'one-armed wolf' and embark on a dangerous journey to rescue your kidnapped lord and seek revenge on your enemies.",
        GenreId = 1, // Action
        CategoryId = 1, // Fantasy
        ReleaseDate = DateTime.Parse("2019-03-22"),
        Developer = "FromSoftware",
        AdminApproval = true
    },

     new Game
    {
        Id = 34,
        Title = "Dark Souls III",
        CoverImage = "https://files.kstatecollegian.com/2016/04/c0bbe758-529f-4fce-ab50-bd88f75149da.jpg",
        Description = "Confront a world filled with darkness and despair in this challenging action RPG.",
        GenreId = 3, // RPG
        CategoryId = 1, // Fantasy
        ReleaseDate = DateTime.Parse("2016-03-24"),
        Developer = "FromSoftware",
        AdminApproval = true
    },
    new Game
    {
        Id = 35,
        Title = "Horizon Zero Dawn",
        CoverImage = "https://www.virtuosgames.com/wp-content/uploads/2020/06/Horizon-Zero-Dawn-intruder-alert-HD-Wallpapers-copy_0.jpg.webp",
        Description = "Discover a world ruled by robotic creatures in this post-apocalyptic open-world RPG.",
        GenreId = 19, // Open World
        CategoryId = 2, // Sci-Fi
        ReleaseDate = DateTime.Parse("2017-02-28"),
        Developer = "Guerrilla Games",
        AdminApproval = true
    },
    new Game
    {
        Id = 36,
        Title = "Civilization VI",
        CoverImage = "https://img.redbull.com/images/q_auto,f_auto/redbullcom/2016/07/29/1331809222237_2/civilization-vi-changes-a-lot",
        Description = "Build an empire to withstand the test of time in this strategy game.",
        GenreId = 5, // Strategy
        CategoryId = 3, // Historical
        ReleaseDate = DateTime.Parse("2016-10-21"),
        Developer = "Firaxis Games",
        AdminApproval = true
    },
    new Game
    {
        Id = 37,
        Title = "Dead by Daylight",
        CoverImage = "https://cdn.gfinityesports.com/images/ncavvykf/gfinityesports/1fc5cb641d67c39c7f6be4d6b624e884e15e05da-2000x1000.jpg?rect=48,0,1905,1000&w=1200&h=630&auto=format",
        Description = "Survive deadly hunting games or be the killer in this multiplayer horror game.",
        GenreId = 8, // Horror
        CategoryId = 8, // Horror
        ReleaseDate = DateTime.Parse("2016-06-14"),
        Developer = "Behaviour Interactive",
        AdminApproval = true
    },
    new Game
    {
        Id = 38,
        Title = "Rocket League",
        CoverImage = "https://cdn.mobygames.com/covers/9632468-rocket-league-playstation-4-front-cover.jpg",
        Description = "Play a high-powered hybrid of arcade soccer and vehicular mayhem.",
        GenreId = 6, // Sports
        CategoryId = 19, // Sports
        ReleaseDate = DateTime.Parse("2015-07-07"),
        Developer = "Psyonix",
        AdminApproval = true
    },

     new Game
    {
        Id = 39,
        Title = "Detroit: Become Human",
        CoverImage = "https://thealternativeafterstory.files.wordpress.com/2020/07/detroit-become-human-1920x1080-connor-kara-markus-2018-playstation-4-13448.jpg?w=750",
        Description = "Navigate a world on the brink of chaos as androids start feeling emotions.",
        GenreId = 20, // Narrative
        CategoryId = 2, // Sci-Fi
        ReleaseDate = DateTime.Parse("2018-05-25"),
        Developer = "Quantic Dream",
        AdminApproval = true
    },
    new Game
    {
        Id = 40,
        Title = "Total War: Three Kingdoms",
        CoverImage = "https://fanatical.imgix.net/product/original/a00d342a-f87c-4809-853c-f26ef038b39b.jpeg?auto=compress,format&w=430&fit=crop&h=242",
        Description = "Command one of the game's factions and conquer the realm in this strategy game set in ancient China.",
        GenreId = 5, // Strategy
        CategoryId = 3, // Historical
        ReleaseDate = DateTime.Parse("2019-05-23"),
        Developer = "Creative Assembly",
        AdminApproval = true
    },
    new Game
    {
        Id = 41,
        Title = "Phasmophobia",
        CoverImage = "https://miro.medium.com/v2/resize:fit:720/format:webp/1*1P8vqZutMNLsQPDRKZ7EXw.png", // Actual cover art might be different.
        Description = "Team up with friends to hunt ghosts and discover the type haunting a location.",
        GenreId = 8, // Horror
        CategoryId = 8, // Horror
        ReleaseDate = DateTime.Parse("2020-09-18"),
        Developer = "Kinetic Games",
        AdminApproval = true
    },
    new Game
    {
        Id = 42,
        Title = "Final Fantasy XV",
        CoverImage = "https://thumbnails.pcgamingwiki.com/1/14/Final_Fantasy_XV_cover.jpg/300px-Final_Fantasy_XV_cover.jpg",
        Description = "Join Prince Noctis and his friends on a journey of discovery, love, and despair.",
        GenreId = 3, // RPG
        CategoryId = 1, // Fantasy
        ReleaseDate = DateTime.Parse("2016-11-29"),
        Developer = "Square Enix",
        AdminApproval = true
    },
    new Game
    {
        Id = 43,
        Title = "Apex Legends",
        CoverImage = "https://gepig.com/game_cover_460w/6007.jpg",
        Description = "Enter the arena in this free-to-play Battle Royale game.",
        GenreId = 17, // Battle Royale
        CategoryId = 2, // Sci-Fi
        ReleaseDate = DateTime.Parse("2019-02-04"),
        Developer = "Respawn Entertainment",
        AdminApproval = true
    },
    new Game
    {
        Id = 44,
        Title = "Hades",
        CoverImage = "https://media.wired.com/photos/5f6cf5ec6f32a729dc0b3a89/master/w_1600,c_limit/Culture_inline_Hades_PackArt.jpg",
        Description = "Defy the god of death as you hack and slash your way out of the Underworld in this rogue-like dungeon crawler.",
        GenreId = 1, // Action
        CategoryId = 1, // Fantasy
        ReleaseDate = DateTime.Parse("2020-09-17"),
        Developer = "Supergiant Games",
        AdminApproval = true
    },
    new Game
    {
        Id = 45,
        Title = "The Sims 4",
        CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7f/Sims4_Rebrand.png/220px-Sims4_Rebrand.png",
        Description = "Create and control people, customize their appearances, personalities, and build and furnish their homes.",
        GenreId = 4, // Simulation
        CategoryId = 12, // Building/Construction
        ReleaseDate = DateTime.Parse("2014-09-02"),
        Developer = "Maxis",
        AdminApproval = true
    },
    new Game
    {
        Id = 46,
        Title = "Street Fighter V",
        CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/8/80/Street_Fighter_V_box_artwork.png/220px-Street_Fighter_V_box_artwork.png",
        Description = "Experience the intensity of head-to-head battle in the latest edition of the Street Fighter series.",
        GenreId = 11, // Fighting
        CategoryId = 15, // Superhero (might not perfectly fit but for the sake of diversity)
        ReleaseDate = DateTime.Parse("2016-02-16"),
        Developer = "Capcom",
        AdminApproval = true
    },
    new Game
    {
        Id = 47,
        Title = "Forza Horizon 4",
        CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/8/87/Forza_Horizon_4_cover.jpg/220px-Forza_Horizon_4_cover.jpg",
        Description = "Race, stunt, and explore a shared open world in one of the most diverse Forza experiences ever.",
        GenreId = 6, // Sports
        CategoryId = 19, // Sports
        ReleaseDate = DateTime.Parse("2018-10-02"),
        Developer = "Playground Games",
        AdminApproval = true
    },

new Game
{
    Id = 48,
    Title = "Red Dead Redemption",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a7/Red_Dead_Redemption.jpg/220px-Red_Dead_Redemption.jpg",
    Description = "An open-world western game that follows former outlaw John Marston as he hunts down his former gang members.",
    GenreId = 2, // Adventure
    CategoryId = 4, // Western
    ReleaseDate = DateTime.Parse("2010-05-18"),
    Developer = "Rockstar San Diego",
    AdminApproval = true
},
new Game
{
    Id = 49,
    Title = "Celeste",
    CoverImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0f/Celeste_box_art_full.png/220px-Celeste_box_art_full.png",
    Description = "Navigate a series of challenging platforming levels on Celeste mountain in this critically acclaimed indie title.",
    GenreId = 1, // Action
    CategoryId = 9, // Adventure
    ReleaseDate = DateTime.Parse("2018-01-25"),
    Developer = "Maddy Makes Games",
    AdminApproval = true
},
new Game
{
    Id = 50,
    Title = "Monster Hunter: World",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/1/1b/Monster_Hunter_World_cover_art.jpg/220px-Monster_Hunter_World_cover_art.jpg",
    Description = "Join the hunt and track down ferocious beasts in vast, living ecosystems.",
    GenreId = 1, // Action
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2018-01-26"),
    Developer = "Capcom",
    AdminApproval = true
},

new Game
{
    Id = 51,
    Title = "Star Wars: Knights of the Old Republic 2: The Sith Lords",
    CoverImage = "https://www.godisageek.com/wp-content/uploads/apps.45033.14417244363263575.acb13d5f-45b0-4587-8107-3e760e953737-790x444.jpg",
    Description = "The sequel to Knights of the Old Republic, delving deeper into the Star Wars lore with a darker narrative and more refined gameplay mechanics.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2004-12-06"),
    Developer = "Obsidian Entertainment",
    AdminApproval = true
},

new Game
{
    Id = 52,
    Title = "Dead Cells",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/1/1f/Dead_cells_cover_art.png/220px-Dead_cells_cover_art.png",
    Description = "Explore an ever-changing castle filled with cunning foes in this rogue-like, Metroidvania-inspired action platformer.",
    GenreId = 1, // Action
    CategoryId = 7, // Drama (given the dark and evolving narrative)
    ReleaseDate = DateTime.Parse("2018-08-07"),
    Developer = "Motion Twin",
    AdminApproval = true
},
new Game
{
    Id = 53,
    Title = "Star Wars: Jedi Survivor",
    CoverImage = "https://mms.businesswire.com/media/20221208006107/en/1660328/4/SWJS_Survivor_Key_Art_Standard%281%29.jpg?download=1",
    Description = "A hypothetical Star Wars game where Jedi must survive against insurmountable odds.",
    GenreId = 1, // Action
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2023-01-01"), // Placeholder date
    Developer = "Hypothetical Studios",
    AdminApproval = true
},
new Game
{
    Id = 54,
    Title = "Ghost of Tsushima",
    CoverImage = "https://mp1st.com/wp-content/uploads/2021/06/Ghost-of-Tsushima-PC-version.jpg",
    Description = "Defend your homeland and honor as Jin Sakai during the Mongol invasion of Tsushima in 1274.",
    GenreId = 1, // Action
    CategoryId = 3, // Historical
    ReleaseDate = DateTime.Parse("2020-07-17"),
    Developer = "Sucker Punch Productions",
    AdminApproval = true
},
new Game
{
    Id = 55,
    Title = "Death Stranding",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/2/22/Death_Stranding.jpg/220px-Death_Stranding.jpg",
    Description = "Traverse a ravaged American landscape carrying valuable cargo and connecting isolated communities in a post-apocalyptic world.",
    GenreId = 2, // Adventure
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2019-11-08"),
    Developer = "Kojima Productions",
    AdminApproval = true
},
new Game
{
    Id = 56,
    Title = "Control",
    CoverImage = "https://cdnb.artstation.com/p/assets/images/images/037/623/545/large/yellowfly-control-key-art-final-portrait.jpg?1620859445",
    Description = "Navigate a shape-shifting building as Jesse Faden, searching for answers to supernatural mysteries.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2019-08-27"),
    Developer = "Remedy Entertainment",
    AdminApproval = true
},
new Game
{
    Id = 57,
    Title = "Oxenfree",
    CoverImage = "https://image.api.playstation.com/cdn/EP0965/CUSA05051_00/hDQ0Na70halrmQjBhAJiHfIGCpuouSxs.png?w=620&thumb=false",
    Description = "Join a group of friends on a trip to an abandoned island, only to encounter supernatural events.",
    GenreId = 2, // Adventure
    CategoryId = 4, // Mystery
    ReleaseDate = DateTime.Parse("2016-01-15"),
    Developer = "Night School Studio",
    AdminApproval = true
},
new Game
{
    Id = 58,
    Title = "Firewatch",
    CoverImage = "https://cdn.mobygames.com/covers/1774827-firewatch-windows-apps-front-cover.png",
    Description = "Isolated in the Wyoming wilderness, unravel a mystery while working as a fire lookout.",
    GenreId = 2, // Adventure
    CategoryId = 4, // Mystery
    ReleaseDate = DateTime.Parse("2016-02-09"),
    Developer = "Campo Santo",
    AdminApproval = true
},
new Game
{
    Id = 59,
    Title = "Undertale",
    CoverImage = "https://upload.wikimedia.org/wikipedia/commons/f/f1/Undertale_cover.jpg?20200103120235",
    Description = "Navigate the monster-filled underworld and make decisions that will influence the story's outcome.",
    GenreId = 7, // Puzzle
    CategoryId = 16, // Anime & Manga (given its inspiration and style)
    ReleaseDate = DateTime.Parse("2015-09-15"),
    Developer = "Toby Fox",
    AdminApproval = true
},
new Game
{
    Id = 60,
    Title = "Inside",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/5/50/INSIDE_Xbox_One_cover_art.png",
    Description = "Control a young boy in a dystopic world, solving environmental puzzles and avoiding death.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2016-06-29"),
    Developer = "Playdead",
    AdminApproval = true
},

new Game
{
    Id = 61,
    Title = "Final Fantasy VII",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/c/c2/Final_Fantasy_VII_Box_Art.jpg",
    Description = "Join Cloud Strife and his allies against the corrupt Shinra megacorporation in this iconic JRPG.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("1997-01-31"),
    Developer = "Square",
    AdminApproval = true
},
new Game
{
    Id = 62,
    Title = "Metal Gear Solid",
    CoverImage = "https://images.pushsquare.com/fc8b1298ef3e0/metal-gear-solid-cover.cover_300x.jpg",
    Description = "Sneak your way through a nuclear facility in Alaska with Solid Snake in this tactical espionage action game.",
    GenreId = 1, // Action
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1998-09-03"),
    Developer = "Konami",
    AdminApproval = true
},
new Game
{
    Id = 63,
    Title = "Super Mario Bros. 3",
    CoverImage = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/4c8bec71-cdc3-43cd-a782-9db62157a7cf/d556ki3-ac2771ea-95b9-4f27-a809-7051aaabef80.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzRjOGJlYzcxLWNkYzMtNDNjZC1hNzgyLTlkYjYyMTU3YTdjZlwvZDU1NmtpMy1hYzI3NzFlYS05NWI5LTRmMjctYTgwOS03MDUxYWFhYmVmODAuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.dsndnL5fGBdxMYUNjjc5_oiZ2gClbMNHX2E5eX5bN0w",
    Description = "Join Mario on a quest to save the princess while navigating a series of diverse worlds.",
    GenreId = 1, // Action
    CategoryId = 18, // Cartoon & Animation
    ReleaseDate = DateTime.Parse("1988-10-23"),
    Developer = "Nintendo",
    AdminApproval = true
},
new Game
{
    Id = 64,
    Title = "Castlevania: Symphony of the Night",
    CoverImage = "https://www.rpgfan.com/wp-content/uploads/2020/07/Castlevania-Symphony-of-the-Night-Cover-Art-001.jpg",
    Description = "Explore Dracula's castle as Alucard, seeking to defeat the dark lord.",
    GenreId = 2, // Adventure
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("1997-03-20"),
    Developer = "Konami",
    AdminApproval = true
},
new Game
{
    Id = 65,
    Title = "Resident Evil 4",
    CoverImage = "https://cdn.mobygames.com/covers/4480917-resident-evil-4-playstation-2-front-cover.jpg",
    Description = "Save the president's daughter from a mysterious cult in this action-packed survival horror game.",
    GenreId = 1, // Action
    CategoryId = 8, // Horror
    ReleaseDate = DateTime.Parse("2005-01-11"),
    Developer = "Capcom",
    AdminApproval = true
},
new Game
{
    Id = 66,
    Title = "Street Fighter II",
    CoverImage = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/2e3851a3-ebc6-487d-95bd-490844510fac/d3089lp-3ae10c8c-6363-43bc-b8ef-4ef4cbb6cb1b.jpg/v1/fill/w_900,h_669,q_75,strp/street_fighter_2_snesbox_cover_by_hellstinger64_d3089lp-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NjY5IiwicGF0aCI6IlwvZlwvMmUzODUxYTMtZWJjNi00ODdkLTk1YmQtNDkwODQ0NTEwZmFjXC9kMzA4OWxwLTNhZTEwYzhjLTYzNjMtNDNiYy1iOGVmLTRlZjRjYmI2Y2IxYi5qcGciLCJ3aWR0aCI6Ijw9OTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.Fm7WLxAGjPuR7j6fp0y8FPW4rKgVbn62eMe1WFtbfP0",
    Description = "Engage in fierce one-on-one battles with fighters from around the globe in this iconic fighting game.",
    GenreId = 11, // Fighting
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("1991-03-12"),
    Developer = "Capcom",
    AdminApproval = true
},
new Game
{
    Id = 67,
    Title = "Chrono Trigger",
    CoverImage = "https://i.redd.it/xtwtloes2z331.jpg",
    Description = "Join a group of adventurers traveling through time to prevent a global catastrophe.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1995-03-11"),
    Developer = "Square",
    AdminApproval = true
},
new Game
{
    Id = 68,
    Title = "Mega Man X",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/f/f1/Mega_Man_X_Coverart.png",
    Description = "Take control of Mega Man X to defeat the rogue Reploids and their leader Sigma.",
    GenreId = 1, // Action
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1993-12-17"),
    Developer = "Capcom",
    AdminApproval = true
},
new Game
{
    Id = 69,
    Title = "Silent Hill 2",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/9/95/Silent_Hill_2.jpg",
    Description = "Navigate the foggy town of Silent Hill as James Sunderland, searching for your deceased wife.",
    GenreId = 8, // Horror
    CategoryId = 4, // Mystery
    ReleaseDate = DateTime.Parse("2001-09-24"),
    Developer = "Konami",
    AdminApproval = true
},
new Game
{
    Id = 70,
    Title = "Baldur's Gate II: Shadows of Amn",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/1/17/Baldur%27s_Gate_II_-_Shadows_of_Amn_Coverart.png",
    Description = "Continue the journey in the Forgotten Realms in this classic role-playing game, facing powerful foes and moral decisions.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2000-09-21"),
    Developer = "BioWare",
    AdminApproval = true
},
new Game
{
    Id = 71,
    Title = "Metroid Prime",
    CoverImage = "https://cdn.mobygames.com/promos/527284-metroid-prime-other.jpg",
    Description = "Explore the alien world of Tallon IV in first-person perspective as Samus Aran, battling space pirates and ancient creatures.",
    GenreId = 1, // Action
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2002-11-17"),
    Developer = "Retro Studios",
    AdminApproval = true
},
new Game
{
    Id = 72,
    Title = "Diablo II",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
    Description = "Delve into the dungeons and battle the forces of evil in this action RPG.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2000-06-29"),
    Developer = "Blizzard North",
    AdminApproval = true
},
new Game
{
    Id = 73,
    Title = "Half-Life",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/f/fa/Half-Life_Cover_Art.jpg",
    Description = "Navigate the research facility Black Mesa after an experiment goes awry, battling aliens and military troops.",
    GenreId = 9, // Shooter
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1998-11-19"),
    Developer = "Valve",
    AdminApproval = true
},
new Game
{
    Id = 74,
    Title = "Prince of Persia: The Sands of Time",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/8/86/Sands_of_time_cover.jpg",
    Description = "Navigate through palaces and rewind time with a mystical dagger in this action-adventure game.",
    GenreId = 2, // Adventure
    CategoryId = 3, // Historical
    ReleaseDate = DateTime.Parse("2003-11-06"),
    Developer = "Ubisoft Montreal",
    AdminApproval = true
},
new Game
{
    Id = 75,
    Title = "Super Metroid",
    CoverImage = "https://images.nintendolife.com/b056f83e2b311/us.large.jpg",
    Description = "Guide Samus Aran on planet Zebes in her quest to rescue a baby Metroid from space pirates.",
    GenreId = 2, // Adventure
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1994-03-19"),
    Developer = "Nintendo",
    AdminApproval = true
},
new Game
{
    Id = 76,
    Title = "StarCraft",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/9/93/StarCraft_box_art.jpg/220px-StarCraft_box_art.jpg",
    Description = "Engage in interstellar warfare as one of three unique factions: the Terrans, the Protoss, and the Zerg.",
    GenreId = 5, // Strategy
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1998-03-31"),
    Developer = "Blizzard Entertainment",
    AdminApproval = true
},
new Game
{
    Id = 77,
    Title = "Monkey Island 2: LeChuck's Revenge",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/1/1c/LeChuck%27s_Revenge_artwork.jpg",
    Description = "Join Guybrush Threepwood in his comedic quest to find the mysterious treasure of Big Whoop.",
    GenreId = 2, // Adventure
    CategoryId = 6, // Comedy
    ReleaseDate = DateTime.Parse("1991-12-01"),
    Developer = "Lucasfilm Games",
    AdminApproval = true
},
new Game
{
    Id = 78,
    Title = "Age of Empires II",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/5/56/Age_of_Empires_II_-_The_Age_of_Kings_Coverart.png",
    Description = "Lead one of the several civilizations through multiple ages, from the Dark Age to the Imperial Age, and build the greatest empire.",
    GenreId = 5, // Strategy
    CategoryId = 3, // Historical
    ReleaseDate = DateTime.Parse("1999-09-30"),
    Developer = "Ensemble Studios",
    AdminApproval = true
},
new Game
{
    Id = 79,
    Title = "Quake",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/4/4c/Quake1cover.jpg",
    Description = "Dive into this first-person shooter that's recognized as one of the pioneers of the genre, featuring fast-paced combat and dark gothic atmosphere.",
    GenreId = 9, // Shooter
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("1996-06-22"),
    Developer = "id Software",
    AdminApproval = true
},
new Game
{
    Id = 80,
    Title = "SimCity 2000",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/d/d4/SimCity_2000_Coverart.png",
    Description = "Design, build, and manage your very own city in this detailed and captivating city-building simulation game.",
    GenreId = 4, // Simulation
    CategoryId = 12, // Building/Construction
    ReleaseDate = DateTime.Parse("1993-02-01"),
    Developer = "Maxis",
    AdminApproval = true
},
new Game
{
    Id = 81,
    Title = "Final Fantasy VI",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/0/05/Final_Fantasy_VI.jpg",
    Description = "Embark on an epic journey with a diverse group of characters to stop the malevolent Kefka and save the world.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("1994-04-02"),
    Developer = "Square",
    AdminApproval = true
},
new Game
{
    Id = 82,
    Title = "Batman: Arkham City",
    Description = "In a sprawling open-air prison, Batman confronts some of his most notorious foes while unraveling a deeper conspiracy.",
    ReleaseDate = DateTime.Parse("2011-10-18"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/0/00/Batman_Arkham_City_Game_Cover.jpg",
    CategoryId = 15, // Superhero
    GenreId = 19  // Open World
},
new Game
{
    Id = 83,
    Title = "Marvel's Spider-Man",
    CoverImage = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/1ea08e12-847b-4c43-8433-ff86b833fd7b/dfzv6g2-5a1db4b8-b4aa-46b5-91c4-efbed9c8a53b.jpg/v1/fill/w_890,h_501,q_75,strp/marvel_s_spider_man__2018_video_game__cover__by_blue_leader97_dfzv6g2-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTAxIiwicGF0aCI6IlwvZlwvMWVhMDhlMTItODQ3Yi00YzQzLTg0MzMtZmY4NmI4MzNmZDdiXC9kZnp2NmcyLTVhMWRiNGI4LWI0YWEtNDZiNS05MWM0LWVmYmVkOWM4YTUzYi5qcGciLCJ3aWR0aCI6Ijw9ODkwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.hNBEgPHMdqbOvPWk3EU3FTDq0Jb0j-qNSvQHa1tKxo0",
    Description = "An action-adventure game that lets players swing through New York City as the iconic superhero Spider-Man.",
    GenreId = 1, // Action
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2018-09-07"),
    Developer = "Insomniac Games",
    AdminApproval = true
},
new Game
{
    Id = 84,
    Title = "Diablo",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/3/3a/Diablo_Coverart.png",
    Description = "Descend into the depths of Tristram's Cathedral to defeat the Lord of Terror, Diablo, in this action RPG.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("1996-12-31"),
    Developer = "Blizzard North",
    AdminApproval = true
},
new Game
{
    Id = 85,
    Title = "System Shock 2",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/9/91/Systemshock2box.jpg",
    Description = "Awaken on the starship Von Braun and unravel the mysteries aboard while battling hostile entities.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1999-08-11"),
    Developer = "Looking Glass Studios, Irrational Games",
    AdminApproval = true
},
new Game
{
    Id = 86,
    Title = "Doom II",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/2/29/Doom_II_-_Hell_on_Earth_Coverart.png",
    Description = "Continue the fight against the demonic invasion as the Doom Slayer in this iconic first-person shooter sequel.",
    GenreId = 9, // Shooter
    CategoryId = 8, // Horror
    ReleaseDate = DateTime.Parse("1994-10-10"),
    Developer = "id Software",
    AdminApproval = true
},
new Game
{
    Id = 87,
    Title = "Marvel's Wolverine",
    CoverImage = "https://i0.wp.com/insider-gaming.com/wp-content/uploads/2023/02/marvels-wolverine-e1675357857901.jpg?fit=1920%2C1079&ssl=1",
    Description = "An upcoming action game focused on the Marvel superhero Wolverine, promising a deep narrative and brutal gameplay.",
    GenreId = 1, // Action
    CategoryId = 15, // Superhero
    ReleaseDate = null, // Placeholder date as the game is announced but not released as of my last update
    Developer = "Insomniac Games",
    AdminApproval = true
},
new Game
{
    Id = 88,
    Title = "Marvel vs. Capcom 3",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/b/b6/Marvel_Vs_Capcom_3_box_artwork.jpg",
    Description = "The third installment in the crossover fighting game series, featuring characters from both Marvel comics and Capcom games.",
    GenreId = 11, // Fighting
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2011-02-15"),
    Developer = "Capcom",
    AdminApproval = true
},
new Game
{
    Id = 89,
    Title = "Max Payne",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/4/4c/Maxpaynebox.jpg",
    Description = "Avenge your murdered family and navigate the dark underbelly of New York's criminal world, all while experiencing the innovative bullet-time shooting mechanics.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2001-07-23"),
    Developer = "Remedy Entertainment",
    AdminApproval = true
},
new Game
{
    Id = 90,
    Title = "Fallout 3",
    Description = "In a post-apocalyptic Washington D.C., the player emerges from an underground bunker and ventures into the wasteland to find their missing father.",
    ReleaseDate = DateTime.Parse("2008-10-28"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/8/83/Fallout_3_cover_art.PNG",
    CategoryId = 2, // Sci-Fi
    GenreId = 19 // Open World
},
new Game
{
    Id = 91,
    Title = "Banjo-Kazooie",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/1/12/Banjo_Kazooie_Cover.png",
    Description = "Join Banjo and his friend Kazooie in this platforming adventure to save Banjo's sister from the wicked witch Gruntilda.",
    GenreId = 2, // Adventure
    CategoryId = 18, // Cartoon & Animation
    ReleaseDate = DateTime.Parse("1998-06-29"),
    Developer = "Rare",
    AdminApproval = true
},
new Game
{
    Id = 92,
    Title = "Dragon Ball Z: Buu's Fury",
    Description = "Play through the final chapters of the Dragon Ball Z story, from the Other World Tournament saga to the Kid Buu saga.",
    ReleaseDate = DateTime.Parse("2004-09-14"),
    CoverImage = "https://images.igdb.com/igdb/image/upload/t_cover_big_2x/co3klz.jpg",
    CategoryId = 1, // Fantasy
    GenreId = 3   // RPG
},
new Game
{
    Id = 93,
    Title = "Deus Ex",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/4/42/Dxcover.jpg",
    Description = "Step into the shoes of JC Denton, an augmented agent, in this action RPG that offers multiple ways to approach objectives.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2000-06-26"),
    Developer = "Ion Storm",
    AdminApproval = true
},
new Game
{
    Id = 94,
    Title = "Kingdom Hearts 2",
    Description = "Sora returns to embark on another journey through Disney worlds to combat a new enemy known as the Nobodies.",
    ReleaseDate = DateTime.Parse("2005-12-22"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/e/ed/Kingdom_Hearts_II_%28PS2%29.jpg",
    CategoryId = 1, // Fantasy
    GenreId = 3  // RPG
},
new Game
{
    Id = 95,
    Title = "Command & Conquer: Red Alert",
    CoverImage = "https://preview.redd.it/why-does-red-alert-1-have-different-cover-art-for-na-vs-eu-v0-lhrgm7x80aja1.png?width=437&format=png&auto=webp&s=e57109d7c7228e55a62aad0263954306495aa5bd",
    Description = "Engage in strategic warfare in an alternate history where Einstein tampers with the timeline.",
    GenreId = 5, // Strategy
    CategoryId = 10, // War
    ReleaseDate = DateTime.Parse("1996-10-31"),
    Developer = "Westwood Studios",
    AdminApproval = true
},
new Game
{
    Id = 96,
    Title = "Far Cry 5",
    Description = "In the fictional Hope County, Montana, the player takes on a doomsday cult known as the Project at Eden's Gate and its charismatic leader.",
    ReleaseDate = DateTime.Parse("2018-03-27"),
    CoverImage = "https://cdn.vox-cdn.com/thumbor/gwd1KaHU9P3JAROPViQS200wFe8=/0x0:1089x1440/1400x1400/filters:focal(458x770:632x944):format(jpeg)/cdn.vox-cdn.com/uploads/chorus_image/image/54929207/far_cry_5_last_supper_art_1089.0.jpg",
    CategoryId = 1, // Fantasy
    GenreId = 19  // Open World
},
new Game
{
    Id = 97,
    Title = "Wing Commander",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/d/d1/WingCommanderBox-front.jpg",
    Description = "Take command of a space fighter in this space combat simulator set in an interstellar war.",
    GenreId = 1, // Action
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1990-09-26"),
    Developer = "Origin Systems",
    AdminApproval = true
},
new Game
{
    Id = 98,
    Title = "Myst",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/6/6a/MystCover.png",
    Description = "Navigate through an interactive landscape and solve puzzles in this groundbreaking point-and-click adventure.",
    GenreId = 2, // Adventure
    CategoryId = 4, // Mystery
    ReleaseDate = DateTime.Parse("1993-09-24"),
    Developer = "Cyan",
    AdminApproval = true
},
new Game
{
    Id = 99,
    Title = "Civilization",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/e/ec/Civilization_box_cover.jpg",
    Description = "Begin in the ancient world and lead your civilization to greatness through centuries in this strategy game.",
    GenreId = 5, // Strategy
    CategoryId = 3, // Historical
    ReleaseDate = DateTime.Parse("1991-09-01"),
    Developer = "MicroProse",
    AdminApproval = true
},
new Game
{
    Id = 100,
    Title = "Deus Ex: Mankind Divided",
    Description = "In a cyberpunk future where augmentations divide society, Adam Jensen investigates terrorist attacks with complex conspiracies.",
    ReleaseDate = DateTime.Parse("2016-08-23"),
    CoverImage = "https://volumearchives.files.wordpress.com/2016/09/p1_2181074_cbf7574c.jpg?w=1200",
    CategoryId = 5, // Sci-Fi
    GenreId = 2   // Action-Adventure
},
new Game
{
    Id = 101,
    Title = "Far Cry 6",
    Description = "Set on Yara, a fictional Caribbean island, the player takes on the role of a guerilla fighter aiming to overthrow the oppressive regime of dictator Antón Castillo.",
    ReleaseDate = DateTime.Parse("2021-10-07"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/3/35/Far_cry_6_cover.jpg/220px-Far_cry_6_cover.jpg",
    CategoryId = 2, // Sci-Fi
    GenreId = 19,  // Open World
},
new Game
{
    Id = 102,
    Title = "Mortal Kombat vs. DC Universe",
    CoverImage = "https://www.gamespot.com/a/uploads/scale_medium/mig/9/0/6/5/2219065-mkdc_generic_fob.jpg",
    Description = "A crossover fighting game featuring characters from both the Mortal Kombat series and the DC Universe.",
    GenreId = 11, // Fighting
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2008-11-16"),
    Developer = "Midway Games",
    AdminApproval = true
},
new Game
{
    Id = 103,
    Title = "Batman: Arkham Origins",
    Description = "A prequel to the series, a young Batman encounters many of his foes for the first time on Christmas Eve.",
    ReleaseDate = DateTime.Parse("2013-10-25"),
    CoverImage = "https://i0.wp.com/batman-news.com/wp-content/uploads/2013/05/486263.jpg?fit=3000%2C3800&quality=80&strip=info&ssl=1",
    CategoryId = 15, // Superhero
    GenreId = 19,  // Open World
},
new Game
{
    Id = 104,
    Title = "Kingdom Hearts",
    Description = "Sora teams up with Donald and Goofy to travel through various Disney worlds and battle the Heartless in order to find his missing friends.",
    ReleaseDate = DateTime.Parse("2002-03-28"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/8/85/Kingdom_Hearts.jpg",
    CategoryId = 1, // Fantasy
    GenreId = 3  // RPG
},
new Game
{
    Id = 105,
    Title = "Marvel's Spider-Man 2",
    CoverImage = "https://cdn.shortpixel.ai/spai/q_glossy+w_998+to_webp+ret_img/thecosmiccircus.com/wp-content/uploads/2023/07/Marvels-Spiderman-2-banner-e1690742326962-800x445.jpg",
    Description = "The sequel to Marvel's Spider-Man, continuing the story of Peter Parker and introducing more characters from the Spider-Man universe.",
    GenreId = 1, // Action
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2023-01-01"), // Placeholder date as the game is announced but not released as of my last update
    Developer = "Insomniac Games",
    AdminApproval = true
},
new Game
{
    Id = 106,
    Title = "Batman: Arkham Asylum",
    Description = "Batman becomes trapped on Arkham Island and must face off against the Joker and a host of other villains he's helped incarcerate.",
    ReleaseDate = DateTime.Parse("2009-08-25"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/4/42/Batman_Arkham_Asylum_Videogame_Cover.jpg",
    CategoryId = 15, // Superhero
    GenreId = 2  // Adventure
},
new Game
{
    Id = 107,
    Title = "Resident Evil 2",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/4/40/NTSC_Resident_Evil_2_Cover.png",
    Description = "Navigate through a zombie-infested Raccoon City, playing as both Leon S. Kennedy and Claire Redfield.",
    GenreId = 8, // Horror
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("1998-01-21"),
    Developer = "Capcom",
    AdminApproval = true
},
new Game
{
    Id = 108,
    Title = "The Oregon Trail",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/7/79/The_Oregon_Trail_cover.jpg/220px-The_Oregon_Trail_cover.jpg",
    Description = "Lead a group of settlers as they travel westward on the historical Oregon Trail in this educational game.",
    GenreId = 13, // Educational
    CategoryId = 3, // Historical
    ReleaseDate = DateTime.Parse("1985-12-03"),
    Developer = "MECC",
    AdminApproval = true
},
new Game
{
    Id = 109,
    Title = "Marvel's Avengers",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c0/Avengers_2020_cover_art.png/220px-Avengers_2020_cover_art.png",
    Description = "An action-adventure game that combines cinematic storytelling with single-player and cooperative gameplay, centered around the iconic Marvel superheroes.",
    GenreId = 1, // Action
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2020-09-04"),
    Developer = "Crystal Dynamics",
    AdminApproval = true
},
new Game
{
    Id = 110,
    Title = "Streets of Rage 2",
    CoverImage = "https://cdn.mobygames.com/336a5252-abcd-11ed-93d8-02420a000198.webp",
    Description = "Punch and kick your way through city streets to confront the evil Mr. X in this classic beat 'em up.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("1992-12-20"),
    Developer = "Sega",
    AdminApproval = true
},
new Game
{
    Id = 111,
    Title = "ARK: Survival Evolved",
    Description = "Stranded on a mysterious island, it's up to you to tame wild dinosaurs, craft tools, and build shelters to survive.",
    ReleaseDate = DateTime.Parse("2017-08-29"),
    CoverImage = "https://howlongtobeat.com/games/ARK_Survival_Evolved_header.jpg?width=250",
    CategoryId = 6, // Adventure
    GenreId = 19,  // Open World
},
new Game
{
    Id = 112,
    Title = "Day of the Tentacle",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
    Description = "Solve puzzles in a comedic adventure where three unlikely friends must stop an evil purple tentacle.",
    GenreId = 14, // Casual
    CategoryId = 6, // Comedy
    ReleaseDate = DateTime.Parse("1993-06-25"),
    Developer = "LucasArts",
    AdminApproval = true
},
new Game
{
    Id = 113,
    Title = "Fallout: New Vegas",
    Description = "In post-apocalyptic Mojave Desert, the player takes on the role of a courier seeking vengeance and getting embroiled in factional wars.",
    ReleaseDate = DateTime.Parse("2010-10-19"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/3/34/Fallout_New_Vegas.jpg/220px-Fallout_New_Vegas.jpg",
    CategoryId = 2, // Sci-Fi
    GenreId = 19  // Open World
},
new Game
{
    Id = 114,
    Title = "Kingdom Hearts 3",
    Description = "Sora and his allies face off against the real Organization XIII in the final battle to thwart Master Xehanort's plan.",
    ReleaseDate = DateTime.Parse("2019-01-25"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/5/5c/Kingdom_Hearts_III_box_art.jpg",
    CategoryId = 1, // Fantasy
    GenreId = 3  // RPG
},
new Game
{
    Id = 115,
    Title = "Dragon Ball Z: Kakarot",
    Description = "Relive the story of Goku in this action RPG that recounts the most memorable events and battles of the Dragon Ball Z saga.",
    ReleaseDate = DateTime.Parse("2020-01-17"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/e/e4/Dragon_Ball_Z_Kakarot_logo.png",
    CategoryId = 1, // Fantasy
    GenreId = 3   // RPG
},
new Game
{
    Id = 116,
    Title = "Diddy Kong Racing",
    Description = "Join Diddy Kong and friends in a racing adventure to defeat the intergalactic villain, Wizpig, through various challenges.",
    ReleaseDate = DateTime.Parse("1997-11-24"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/a/a0/DKRboxart.jpg",
    CategoryId = 4, // Racing
    GenreId = 11,  // Kart Racing
},
new Game
{
    Id = 117,
    Title = "Super Mario 64",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/6/6a/Super_Mario_64_box_cover.jpg",
    Description = "Join Mario as he embarks on a 3D platforming adventure through Princess Peach's castle, collecting Power Stars and battling iconic foes to rescue the princess from the clutches of Bowser.",
    GenreId = 2, // Adventure
    CategoryId = 18, // Cartoon & Animation
    ReleaseDate = DateTime.Parse("1996-06-23"),
    Developer = "Nintendo EAD",
    AdminApproval = true
},
new Game
{
    Id = 118,
    Title = "The Legend of Zelda: Ocarina of Time",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/5/57/The_Legend_of_Zelda_Ocarina_of_Time.jpg",
    Description = "Journey with Link through the land of Hyrule in a quest to stop Ganondorf, the Gerudo king, from obtaining the sacred relic known as the Triforce. Utilize the Ocarina to manipulate time, solve puzzles, and face foes in this timeless action-adventure classic.",
    GenreId = 2, // Adventure
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("1998-11-21"),
    Developer = "Nintendo EAD",
    AdminApproval = true
},

new Game
{
    Id = 119,
    Title = "Halo: Reach",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/5/5c/Halo-_Reach_box_art.png",
    Description = "Dive into the dramatic events leading up to the original Halo trilogy as Noble Team, a squad of Spartan soldiers, makes its last stand to defend the planet Reach against the relentless Covenant alien force. Experience intense firefights, a compelling narrative, and the tragic tale of sacrifice and heroism.",
    GenreId = 9, // Shooter
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2010-09-14"),
    Developer = "Bungie",
    AdminApproval = true
},
new Game
{
    Id = 120,
    Title = "Portal",
    CoverImage = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/21fba9c1-3f97-4480-b363-c4af09608082/d354rhg-8839c08f-a577-48d1-8596-088ec6ff54cf.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzIxZmJhOWMxLTNmOTctNDQ4MC1iMzYzLWM0YWYwOTYwODA4MlwvZDM1NHJoZy04ODM5YzA4Zi1hNTc3LTQ4ZDEtODU5Ni0wODhlYzZmZjU0Y2YuanBnIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.CNqNVaVPbwKm7SbyOjFpf2cw9eNE9WCPyBe_Xc9BmHc",
    Description = "Trapped in the Aperture Science labs and guided by the malevolent A.I. GLaDOS, players must navigate a series of deadly test chambers using the innovative portal gun. This unique device creates spatial shortcuts, challenging players to think in new dimensions while uncovering the facility's dark secrets.",
    GenreId = 7, // Puzzle
    CategoryId = 14, // Technology & Science
    ReleaseDate = DateTime.Parse("2007-10-10"),
    Developer = "Valve Corporation",
    AdminApproval = true
},
new Game
{
    Id = 121,
    Title = "Starfield",
    CoverImage = "https://i.insider.com/650222fa992da60019ebdfa7?width=1127&format=jpeg",
    Description = "An upcoming space-faring RPG set in a new universe, created by Bethesda Game Studios.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2023-09-06"),
    Developer = "Bethesda Game Studios",
    AdminApproval = true
},
new Game
{
    Id = 122,
    Title = "Lies of P",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/d/de/Lies_of_p_cover_art.jpg",
    Description = "An action RPG inspired by the classic tale 'Pinocchio', where you navigate a decaying city in search of your creator.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2023-09-19"),
    Developer = "Round8 Studio",
    AdminApproval = true
},
new Game
{
    Id = 123,
    Title = "Payday",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/2/2f/Payday_-_The_Heist_%28video_game_box_art%29.jpg",
    Description = "A cooperative first-person shooter where players take on the role of bank robbers, executing heists and evading the police.",
    GenreId = 9, // Shooter
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2011-10-20"),
    Developer = "Overkill Software",
    AdminApproval = true
},
new Game
{
    Id = 124,
    Title = "Payday 2",
    CoverImage = "https://cdn.cloudflare.steamstatic.com/steam/apps/218620/header.jpg?t=1697648752",
    Description = "The sequel to Payday, this cooperative first-person shooter allows players to plan and execute detailed heists, facing tougher challenges and more varied missions.",
    GenreId = 9, // Shooter
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2013-08-13"),
    Developer = "Overkill Software",
    AdminApproval = true
},
new Game
{
    Id = 125,
    Title = "Payday 3",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/7/7c/Payday_3_cover_art.jpg",
    Description = "The third installment in the Payday series, offering more complex heists, better AI, and a refined experience for players.",
    GenreId = 9, // Shooter
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2023-09-21"), // As of my last update, the game had not been released.
    Developer = "Starbreeze Studios",
    AdminApproval = true
},
new Game
{
    Id = 126,
    Title = "Crackdown",
    CoverImage = "https://vgboxart.com/boxes/360/3279-crackdown.jpg",
    Description = "An open-world action game where players assume the role of a super-powered agent tasked with taking down criminal syndicates in a futuristic city.",
    GenreId = 1, // Action
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2007-02-20"),
    Developer = "Realtime Worlds",
    AdminApproval = true
},
new Game
{
    Id = 127,
    Title = "Overwatch 2",
    CoverImage = "https://thumbnails.pcgamingwiki.com/3/3b/Overwatch_2_cover.jpg/300px-Overwatch_2_cover.jpg",
    Description = "A team-based first-person shooter sequel that introduces new maps, heroes, and a new game mode called Push.",
    GenreId = 9, // Shooter
    CategoryId = 15, // Superhero
    ReleaseDate = DateTime.Parse("2022-10-04"),
    Developer = "Blizzard Entertainment",
    AdminApproval = true
},
new Game
{
    Id = 128,
    Title = "Donkey Kong 64",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/a/ae/DonkeyKong64CoverArt.jpg",
    Description = "A 3D platformer featuring the famous ape, Donkey Kong, and his friends, as they try to stop King K. Rool.",
    GenreId = 2, // Adventure
    CategoryId = 18, // Cartoon & Animation
    ReleaseDate = DateTime.Parse("1999-11-22"),
    Developer = "Rare",
    AdminApproval = true
},
new Game
{
    Id = 129,
    Title = "Starfox 64",
    CoverImage = "https://m.media-amazon.com/images/I/71dEfKyEz5L.jpg",
    Description = "A rail shooter where players control Fox McCloud in his Arwing fighter to combat the forces of Andross and save the Lylat system.",
    GenreId = 9, // Shooter
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("1997-06-30"),
    Developer = "Nintendo",
    AdminApproval = true
},
new Game
{
    Id = 130,
    Title = "Elden Ring",
    CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQm7nIPQFcCUv6e16hjyca_vxHn4ESWIQEu9A&usqp=CAU",
    Description = "An action RPG set in a vast, interconnected world, blending open-world exploration with intricate combat, and produced in collaboration with George R.R. Martin.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2022-02-25"),
    Developer = "FromSoftware",
    AdminApproval = true
},
new Game
{
    Id = 131,
    Title = "Super Mario Galaxy",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/7/76/SuperMarioGalaxy.jpg",
    Description = "A 3D platformer where Mario travels through various galaxies to save Princess Peach from Bowser, featuring unique gravity-based gameplay mechanics.",
    GenreId = 2, // Adventure
    CategoryId = 18, // Cartoon & Animation
    ReleaseDate = DateTime.Parse("2007-11-12"),
    Developer = "Nintendo",
    AdminApproval = true
},
new Game
{
    Id = 132,
    Title = "Bloodborne",
    CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQne0pmK1qNCTq5FOd3abDcCcfiKSyhXcL3Ew&usqp=CAU",
    Description = "A challenging action RPG set in the gothic city of Yharnam, plagued by a mysterious illness. Players take on the role of the Hunter to uncover its secrets.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2015-03-24"),
    Developer = "FromSoftware",
    AdminApproval = true
},
new Game
{
    Id = 133,
    Title = "The Last of Us",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg",
    Description = "A post-apocalyptic action-adventure game following Joel and Ellie as they journey across a United States overrun by fungal-infected humans.",
    GenreId = 2, // Adventure
    CategoryId = 7, // Drama
    ReleaseDate = DateTime.Parse("2013-06-14"),
    Developer = "Naughty Dog",
    AdminApproval = true
},
new Game
{
    Id = 134,
    Title = "Grand Theft Auto 3",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/b/be/GTA3boxcover.jpg/220px-GTA3boxcover.jpg",
    Description = "The game that ushered in a 3D open-world experience in the Grand Theft Auto series, as players navigate the criminal underworld of Liberty City.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2001-10-22"),
    Developer = "Rockstar North",
    AdminApproval = true
},
new Game
{
    Id = 135,
    Title = "Grand Theft Auto 4",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b7/Grand_Theft_Auto_IV_cover.jpg/220px-Grand_Theft_Auto_IV_cover.jpg",
    Description = "An open-world action-adventure game focusing on the life of Niko Bellic as he arrives in Liberty City and becomes entwined in the world of crime.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2008-04-29"),
    Developer = "Rockstar North",
    AdminApproval = true
},
new Game
{
    Id = 136,
    Title = "Final Fantasy X",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/a/a7/Ffxboxart.jpg",
    Description = "A JRPG following the journey of Tidus and Yuna as they aim to save the world of Spira from an endless cycle of destruction caused by the creature Sin.",
    GenreId = 3, // RPG
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2001-07-19"),
    Developer = "Square Enix",
    AdminApproval = true
},
new Game
{
    Id = 137,
    Title = "Shadow of the Colossus",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/f/f8/Shadow_of_the_Colossus_%282005%29_cover.jpg",
    Description = "An atmospheric action-adventure game where players must defeat colossal creatures known as colossi to resurrect a girl named Mono.",
    GenreId = 2, // Adventure
    CategoryId = 1, // Fantasy
    ReleaseDate = DateTime.Parse("2005-10-18"),
    Developer = "Team Ico",
    AdminApproval = true
},
new Game
{
    Id = 138,
    Title = "The Outer Worlds",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/e/e7/The_Outer_Worlds_cover_art.png/220px-The_Outer_Worlds_cover_art.png",
    Description = "A first-person RPG set in an alternate future space colony, offering players a chance to influence the story based on choices and play style.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2019-10-25"),
    Developer = "Obsidian Entertainment",
    AdminApproval = true
},
new Game
{
    Id = 139,
    Title = "Bioshock",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/6/6d/BioShock_cover.jpg",
    Description = "Set in the underwater city of Rapture, players explore a dystopian world while facing off against mutated inhabitants and gaining special abilities.",
    GenreId = 9, // Shooter
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2007-08-21"),
    Developer = "Irrational Games",
    AdminApproval = true
},
new Game
{
    Id = 140,
    Title = "Bioshock Infinite",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/a/a3/Official_cover_art_for_Bioshock_Infinite.jpg",
    Description = "Taking place in the floating city of Columbia, this game expands upon the series' narrative and introduces new characters and gameplay mechanics.",
    GenreId = 9, // Shooter
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2013-03-26"),
    Developer = "Irrational Games",
    AdminApproval = true
},
new Game
{
    Id = 141,
    Title = "Disco Elysium",
    CoverImage = "https://150044068.v2.pressablecdn.com/wp-content/uploads/0d4244c2fd3525dca5278a1bfa6e6a50608d690ec473e4597f53b76c8211aed4_product_card_v2_mobile_slider_639-639x330.jpg",
    Description = "A detective role-playing game with a heavy focus on narrative and dialogue choices, set in a unique and gritty urban fantasy world.",
    GenreId = 3, // RPG
    CategoryId = 7, // Drama
    ReleaseDate = DateTime.Parse("2019-10-15"),
    Developer = "ZA/UM",
    AdminApproval = true
},

new Game
{
    Id = 142,
    Title = "Red Dead Revolver",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c1/Red_Dead_Revolver_Coverart.jpg/220px-Red_Dead_Revolver_Coverart.jpg",
    Description = "A third-person shooter set in the Wild West, tracing the story of Red Harlow and his quest for vengeance.",
    GenreId = 9, // Shooter
    CategoryId = 10, // Western
    ReleaseDate = DateTime.Parse("2004-05-04"),
    Developer = "Rockstar San Diego",
    AdminApproval = true
},
new Game
{
    Id = 143,
    Title = "Dishonored",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/6/65/Dishonored_box_art_Bethesda.jpg",
    Description = "A stealth action-adventure game that lets players take on the role of Corvo, a disgraced guard framed for murder, in a steampunk-inspired city.",
    GenreId = 1, // Action
    CategoryId = 6, // Steampunk
    ReleaseDate = DateTime.Parse("2012-10-09"),
    Developer = "Arkane Studios",
    AdminApproval = true
},
new Game
{
    Id = 144,
    Title = "Dishonored 2",
    CoverImage = "https://wallpapers.com/images/featured/dishonored-2-pictures-sm14jc0lashvkpci.jpg",
    Description = "The sequel to Dishonored, allowing players to choose between playing as Corvo or his daughter Emily in a tale of revenge and political intrigue.",
    GenreId = 1, // Action
    CategoryId = 6, // Steampunk
    ReleaseDate = DateTime.Parse("2016-11-11"),
    Developer = "Arkane Studios",
    AdminApproval = true
},
new Game
{
    Id = 145,
    Title = "Pokemon Red/Blue",
    CoverImage = "https://cubiccreativity.files.wordpress.com/2022/02/pokemon-red-and-blue-header.jpg",
    Description = "The original Pokemon games that introduced the world to the beloved franchise, allowing players to capture, train, and battle Pokemon.",
    GenreId = 3, // RPG
    CategoryId = 18, // Cartoon & Animation
    ReleaseDate = DateTime.Parse("1996-02-27"),
    Developer = "Game Freak",
    AdminApproval = true
},
new Game
{
    Id = 146,
    Title = "Metal Gear Solid V: The Phantom Pain",
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/8/8f/Metal_Gear_Solid_V_The_Phantom_Pain_cover.png",
    Description = "An open-world stealth game following Venom Snake as he seeks revenge against those who destroyed his forces during the events of Ground Zeroes.",
    GenreId = 1, // Action
    CategoryId = 5, // Thriller
    ReleaseDate = DateTime.Parse("2015-09-01"),
    Developer = "Kojima Productions",
    AdminApproval = true
},
new Game
{
    Id = 147,
    Title = "Star Wars: Knights of the Old Republic",
    CoverImage = "https://imageio.forbes.com/specials-images/imageserve/6516be8aa27b6dd6a0e67651/kotor2/960x0.png?format=png&width=1440",
    Description = "A role-playing game set in the Star Wars universe, taking place thousands of years before the original films, allowing players to shape the fate of the galaxy.",
    GenreId = 3, // RPG
    CategoryId = 2, // Sci-Fi
    ReleaseDate = DateTime.Parse("2003-07-15"),
    Developer = "BioWare",
    AdminApproval = true
},
new Game
{
    Id = 148,
    Title = "Dragon Ball Z: The Legacy of Goku II",
    Description = "Continue the DBZ saga, spanning from the Frieza saga to the end of the Cell Games.",
    ReleaseDate = DateTime.Parse("2003-06-17"),
    CoverImage = "https://www.giantbomb.com/a/uploads/scale_small/8/87790/1814881-box_dbztlog2.png",
    CategoryId = 1, // Fantasy
    GenreId = 3, // RPG
    Developer = "Webfoot Technologies",
    AdminApproval = true   
},
new Game
{
    Id = 149,
    Title = "Fable",
    Description = "In a fantasy world, grow from a young boy into a legendary hero. Every choice impacts your path, reputation, and the evolution of the world around you.",
    ReleaseDate = DateTime.Parse("2004-09-14"),
    CoverImage = "https://preview.redd.it/nrwhtr50v0t51.jpg?width=256&format=pjpg&auto=webp&s=894462d80ac59ad63eb4d78c2afd1643da3ea949",
    CategoryId = 1, // Fantasy
    GenreId = 19, // Open World
    Developer = "Lionhead Studios",
    AdminApproval = true  
},
new Game
{
    Id = 150,
    Title = "Fable III",
    Description = "Lead a revolution to take control of Albion, then make choices as king or queen that will lead to a thriving nation or its downfall.",
    ReleaseDate = DateTime.Parse("2010-10-26"),
    CoverImage = "https://upload.wikimedia.org/wikipedia/en/f/f1/Fableiii.jpg",
    CategoryId = 1, // Fantasy
    GenreId = 19, // Open World
    Developer = "Lionhead Studios",
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
    },

new Platform
{
    Id = 16,
    Name = "GameCube",
    GamesInCatalog = 658,
    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/GameCube-Console-Set.png/1200px-GameCube-Console-Set.png",
    Description = "Nintendo's compact disc-based console offering a variety of memorable titles.",
    ReleaseYear = DateTime.Parse("2001-09-14"),
    EndYear = DateTime.Parse("2007-02-22")
},
new Platform
{
    Id = 17,
    Name = "PlayStation Portable (PSP)",
    GamesInCatalog = 1367,
    Image = "https://m.media-amazon.com/images/I/615gWr9r13L.jpg",
    Description = "Sony's first foray into the handheld gaming market, featuring impressive visuals and multimedia capabilities.",
    ReleaseYear = DateTime.Parse("2004-12-12"),
    EndYear = DateTime.Parse("2014-06-03")
},
new Platform
{
    Id = 18,
    Name = "Dreamcast",
    GamesInCatalog = 620,
    Image = "https://upload.wikimedia.org/wikipedia/commons/8/81/Dreamcast-Console-Set.jpg",
    Description = "SEGA's last home console, known for its innovative games and pioneering online capabilities.",
    ReleaseYear = DateTime.Parse("1998-11-27"),
    EndYear = DateTime.Parse("2001-03-31")
},
new Platform
{
    Id = 19,
    Name = "Sega Saturn",
    GamesInCatalog = 1094,
    Image = "https://upload.wikimedia.org/wikipedia/commons/2/20/Sega-Saturn-Console-Set-Mk1.png",
    Description = "SEGA's CD-based console known for its arcade ports and unique titles.",
    ReleaseYear = DateTime.Parse("1994-11-22"),
    EndYear = DateTime.Parse("2000-11-23")
},
new Platform
{
    Id = 20,
    Name = "GameBoy Advance",
    GamesInCatalog = 12,
    Image = "https://i.kinja-img.com/image/upload/c_fill,f_auto,fl_progressive,g_center,h_675,pg_1,q_80,w_1200/2f4efdaea6323025a083e58ef3ed8207.jpg",
    Description = "Nintendo's greatest handheld gaming console!",
    ReleaseYear = DateTime.Parse("2001-06-11"),
    EndYear = DateTime.Parse("2010-05-15")
},


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
        { Id = 98, PlatformId = 6, GameId = 30},
        new PlatformGame
        { Id = 99, PlatformId = 2, GameId = 31 },
        // Mass Effect: Legendary Edition
        new PlatformGame { Id = 100, PlatformId = 1, GameId = 31}, // PS4
        new PlatformGame { Id = 101, PlatformId = 2, GameId = 31}, // PC
        new PlatformGame { Id = 102, PlatformId = 4, GameId = 31}, // Xbox One
        new PlatformGame { Id = 103, PlatformId = 5, GameId = 31}, // PS5
        new PlatformGame { Id = 104, PlatformId = 6, GameId = 31}, // Xbox Series X

        // Stardew Valley
        new PlatformGame { Id = 105, PlatformId = 1, GameId = 32}, // PS4
        new PlatformGame { Id = 106, PlatformId = 2, GameId = 32}, // PC
        new PlatformGame { Id = 107, PlatformId = 3, GameId = 32}, // Switch
        new PlatformGame { Id = 108, PlatformId = 4, GameId = 32}, // Xbox One
        new PlatformGame { Id = 109, PlatformId = 5, GameId = 32}, // PS5
        new PlatformGame { Id = 110, PlatformId = 6, GameId = 32}, // Xbox Series X

        // Sekiro: Shadows Die Twice
        new PlatformGame { Id = 111, PlatformId = 1, GameId = 33}, // PS4
        new PlatformGame { Id = 112, PlatformId = 2, GameId = 33}, // PC
        new PlatformGame { Id = 113, PlatformId = 4, GameId = 33}, // Xbox One
        new PlatformGame { Id = 114, PlatformId = 5, GameId = 33}, // PS5
        new PlatformGame { Id = 115, PlatformId = 6, GameId = 33}, // Xbox Series X

        // Dark Souls III
        new PlatformGame { Id = 116, PlatformId = 1, GameId = 34}, // PS4
        new PlatformGame { Id = 117, PlatformId = 2, GameId = 34}, // PC
        new PlatformGame { Id = 118, PlatformId = 4, GameId = 34}, // Xbox One
        new PlatformGame { Id = 119, PlatformId = 5, GameId = 34}, // PS5
        new PlatformGame { Id = 120, PlatformId = 6, GameId = 34}, // Xbox Series X

        // Horizon Zero Dawn
        new PlatformGame { Id = 121, PlatformId = 1, GameId = 35}, // PS4
        new PlatformGame { Id = 122, PlatformId = 2, GameId = 35}, // PC
        new PlatformGame { Id = 123, PlatformId = 5, GameId = 35}, // PS5
        // Civilization VI
        new PlatformGame { Id = 124, PlatformId = 1, GameId = 36}, // PS4
        new PlatformGame { Id = 125, PlatformId = 2, GameId = 36}, // PC
        new PlatformGame { Id = 126, PlatformId = 3, GameId = 36}, // Switch
        new PlatformGame { Id = 127, PlatformId = 4, GameId = 36}, // Xbox One
        new PlatformGame { Id = 128, PlatformId = 5, GameId = 36}, // PS5
        new PlatformGame { Id = 129, PlatformId = 6, GameId = 36}, // Xbox Series X

        // Dead by Daylight
        new PlatformGame { Id = 130, PlatformId = 1, GameId = 37}, // PS4
        new PlatformGame { Id = 131, PlatformId = 2, GameId = 37}, // PC
        new PlatformGame { Id = 132, PlatformId = 3, GameId = 37}, // Switch
        new PlatformGame { Id = 133, PlatformId = 4, GameId = 37}, // Xbox One
        new PlatformGame { Id = 134, PlatformId = 5, GameId = 37}, // PS5
        new PlatformGame { Id = 135, PlatformId = 6, GameId = 37}, // Xbox Series X

        // Rocket League
        new PlatformGame { Id = 136, PlatformId = 1, GameId = 38}, // PS4
        new PlatformGame { Id = 137, PlatformId = 2, GameId = 38}, // PC
        new PlatformGame { Id = 138, PlatformId = 3, GameId = 38}, // Switch
        new PlatformGame { Id = 139, PlatformId = 4, GameId = 38}, // Xbox One
        new PlatformGame { Id = 140, PlatformId = 5, GameId = 38}, // PS5
        new PlatformGame { Id = 141, PlatformId = 6, GameId = 38}, // Xbox Series X

        // Detroit: Become Human
        new PlatformGame { Id = 142, PlatformId = 1, GameId = 39}, // PS4
        new PlatformGame { Id = 143, PlatformId = 2, GameId = 39}, // PC
        new PlatformGame { Id = 144, PlatformId = 5, GameId = 39}, // PS5

        // Total War: Three Kingdoms
        new PlatformGame { Id = 145, PlatformId = 2, GameId = 40}, // PC
        // Phasmophobia
        new PlatformGame { Id = 146, PlatformId = 2, GameId = 41}, // PC

        // Final Fantasy XV
        new PlatformGame { Id = 147, PlatformId = 1, GameId = 42}, // PS4
        new PlatformGame { Id = 148, PlatformId = 2, GameId = 42}, // PC
        new PlatformGame { Id = 149, PlatformId = 4, GameId = 42}, // Xbox One
        new PlatformGame { Id = 150, PlatformId = 5, GameId = 42}, // PS5

        // Apex Legends
        new PlatformGame { Id = 151, PlatformId = 1, GameId = 43}, // PS4
        new PlatformGame { Id = 152, PlatformId = 2, GameId = 43}, // PC
        new PlatformGame { Id = 153, PlatformId = 3, GameId = 43}, // Switch
        new PlatformGame { Id = 154, PlatformId = 4, GameId = 43}, // Xbox One
        new PlatformGame { Id = 155, PlatformId = 5, GameId = 43}, // PS5
        new PlatformGame { Id = 156, PlatformId = 6, GameId = 43}, // Xbox Series X

        // Hades
        new PlatformGame { Id = 157, PlatformId = 1, GameId = 44}, // PS4
        new PlatformGame { Id = 158, PlatformId = 2, GameId = 44}, // PC
        new PlatformGame { Id = 159, PlatformId = 3, GameId = 44}, // Switch
        new PlatformGame { Id = 160, PlatformId = 4, GameId = 44}, // Xbox One
        new PlatformGame { Id = 161, PlatformId = 5, GameId = 44}, // PS5
        new PlatformGame { Id = 162, PlatformId = 6, GameId = 44}, // Xbox Series X

        // The Sims 4
        new PlatformGame { Id = 163, PlatformId = 1, GameId = 45}, // PS4
        new PlatformGame { Id = 164, PlatformId = 2, GameId = 45}, // PC
        new PlatformGame { Id = 165, PlatformId = 4, GameId = 45}, // Xbox One
        new PlatformGame { Id = 166, PlatformId = 5, GameId = 45}, // PS5
        new PlatformGame { Id = 167, PlatformId = 6, GameId = 45}, // Xbox Series X

        // Street Fighter V
        new PlatformGame { Id = 168, PlatformId = 1, GameId = 46}, // PS4
        new PlatformGame { Id = 169, PlatformId = 2, GameId = 46}, // PC

        // Forza Horizon 4
        new PlatformGame { Id = 170, PlatformId = 2, GameId = 47}, // PC
        new PlatformGame { Id = 171, PlatformId = 4, GameId = 47}, // Xbox One
        new PlatformGame { Id = 172, PlatformId = 5, GameId = 47}, // PS5
        new PlatformGame { Id = 173, PlatformId = 6, GameId = 47}, // Xbox Series X

        // Red Dead Redemption (Referring to the first game here, not the sequel)
        new PlatformGame { Id = 174, PlatformId = 1, GameId = 48}, // PS4 (Remastered/Backward Compatibility)
        new PlatformGame { Id = 175, PlatformId = 8, GameId = 48}, // PS3
        new PlatformGame { Id = 176, PlatformId = 9, GameId = 48}, // Xbox 360

        // Celeste
        new PlatformGame { Id = 177, PlatformId = 1, GameId = 49}, // PS4
        new PlatformGame { Id = 178, PlatformId = 2, GameId = 49}, // PC
        new PlatformGame { Id = 179, PlatformId = 3, GameId = 49}, // Switch
        new PlatformGame { Id = 180, PlatformId = 4, GameId = 49}, // Xbox One
        new PlatformGame { Id = 181, PlatformId = 5, GameId = 49}, // PS5
        new PlatformGame { Id = 182, PlatformId = 6, GameId = 49}, // Xbox Series X

        // Monster Hunter: World
        new PlatformGame { Id = 183, PlatformId = 1, GameId = 50}, // PS4
        new PlatformGame { Id = 184, PlatformId = 2, GameId = 50}, // PC
        new PlatformGame { Id = 185, PlatformId = 4, GameId = 50}, // Xbox One
        new PlatformGame { Id = 186, PlatformId = 5, GameId = 50}, // PS5
        new PlatformGame { Id = 187, PlatformId = 6, GameId = 50}, // Xbox Series X
        // Star Wars: Knights of the Old Republic 2: The Sith Lords
        new PlatformGame { Id = 188, PlatformId = 2, GameId = 51}, // PC
        new PlatformGame { Id = 189, PlatformId = 8, GameId = 51}, // PS3 (via backward compatibility)
        new PlatformGame { Id = 190, PlatformId = 9, GameId = 51}, // Xbox 360 (via backward compatibility)
        new PlatformGame { Id = 191, PlatformId = 11, GameId = 51}, // Xbox

        // Dead Cells
        new PlatformGame { Id = 192, PlatformId = 1, GameId = 52}, // PS4
        new PlatformGame { Id = 193, PlatformId = 2, GameId = 52}, // PC
        new PlatformGame { Id = 194, PlatformId = 3, GameId = 52}, // Switch
        new PlatformGame { Id = 195, PlatformId = 4, GameId = 52}, // Xbox One
        new PlatformGame { Id = 196, PlatformId = 5, GameId = 52}, // PS5
        new PlatformGame { Id = 197, PlatformId = 6, GameId = 52}, // Xbox Series X

        // Ghost of Tsushima
        new PlatformGame { Id = 198, PlatformId = 1, GameId = 54}, // PS4
        new PlatformGame { Id = 199, PlatformId = 5, GameId = 54}, // PS5

        // Death Stranding
        new PlatformGame { Id = 200, PlatformId = 1, GameId = 55}, // PS4
        new PlatformGame { Id = 201, PlatformId = 2, GameId = 55}, // PC
        new PlatformGame { Id = 202, PlatformId = 5, GameId = 55}, // PS5
        // Control
        new PlatformGame { Id = 203, PlatformId = 1, GameId = 56}, // PS4
        new PlatformGame { Id = 204, PlatformId = 2, GameId = 56}, // PC
        new PlatformGame { Id = 205, PlatformId = 4, GameId = 56}, // Xbox One
        new PlatformGame { Id = 206, PlatformId = 5, GameId = 56}, // PS5
        new PlatformGame { Id = 207, PlatformId = 6, GameId = 56}, // Xbox Series X

        // Oxenfree
        new PlatformGame { Id = 208, PlatformId = 1, GameId = 57}, // PS4
        new PlatformGame { Id = 209, PlatformId = 2, GameId = 57}, // PC
        new PlatformGame { Id = 210, PlatformId = 3, GameId = 57}, // Switch
        new PlatformGame { Id = 211, PlatformId = 4, GameId = 57}, // Xbox One
        new PlatformGame { Id = 212, PlatformId = 5, GameId = 57}, // PS5
        new PlatformGame { Id = 213, PlatformId = 6, GameId = 57}, // Xbox Series X

        // Firewatch
        new PlatformGame { Id = 214, PlatformId = 1, GameId = 58}, // PS4
        new PlatformGame { Id = 215, PlatformId = 2, GameId = 58}, // PC
        new PlatformGame { Id = 216, PlatformId = 3, GameId = 58}, // Switch
        new PlatformGame { Id = 217, PlatformId = 4, GameId = 58}, // Xbox One

        // Undertale
        new PlatformGame { Id = 218, PlatformId = 1, GameId = 59}, // PS4
        new PlatformGame { Id = 219, PlatformId = 2, GameId = 59}, // PC
        new PlatformGame { Id = 220, PlatformId = 3, GameId = 59}, // Switch
        new PlatformGame { Id = 221, PlatformId = 7, GameId = 59}, // Vita (though it's not in the provided platform list)

        // Inside
        new PlatformGame { Id = 222, PlatformId = 1, GameId = 60}, // PS4
        new PlatformGame { Id = 223, PlatformId = 2, GameId = 60}, // PC
        new PlatformGame { Id = 224, PlatformId = 3, GameId = 60}, // Switch
        new PlatformGame { Id = 225, PlatformId = 4, GameId = 60}, // Xbox One
        new PlatformGame { Id = 226, PlatformId = 5, GameId = 60}, // PS5
        new PlatformGame { Id = 227, PlatformId = 6, GameId = 60}, // Xbox Series X
        // Final Fantasy VII
        new PlatformGame { Id = 228, PlatformId = 1, GameId = 61}, // PS4 (Remastered)
        new PlatformGame { Id = 229, PlatformId = 2, GameId = 61}, // PC
        new PlatformGame { Id = 230, PlatformId = 3, GameId = 61}, // Switch (Remastered)
        new PlatformGame { Id = 231, PlatformId = 8, GameId = 61}, // PS3 (Classic)
        new PlatformGame { Id = 232, PlatformId = 12, GameId = 61}, // PS2 (Classic)

        // Metal Gear Solid
        new PlatformGame { Id = 233, PlatformId = 8, GameId = 62}, // PS3 (Via HD Collection)
        new PlatformGame { Id = 234, PlatformId = 2, GameId = 62}, // PC (Original Release)
        new PlatformGame { Id = 235, PlatformId = 12, GameId = 62}, // PS1

        // Super Mario Bros. 3
        new PlatformGame { Id = 236, PlatformId = 3, GameId = 63}, // Switch (Via NES Online)
        new PlatformGame { Id = 237, PlatformId = 14, GameId = 63}, // SNES (Via Super Mario All-Stars)
        new PlatformGame { Id = 238, PlatformId = 15, GameId = 63}, // NES

        // Castlevania: Symphony of the Night
        new PlatformGame { Id = 239, PlatformId = 1, GameId = 64}, // PS4 (Re-release)
        new PlatformGame { Id = 240, PlatformId = 2, GameId = 64}, // PC
        new PlatformGame { Id = 241, PlatformId = 8, GameId = 64}, // PS3 (Via PSN)
        new PlatformGame { Id = 242, PlatformId = 12, GameId = 64}, // PS1

        // Resident Evil 4
        new PlatformGame { Id = 243, PlatformId = 1, GameId = 65}, // PS4
        new PlatformGame { Id = 244, PlatformId = 2, GameId = 65}, // PC
        new PlatformGame { Id = 245, PlatformId = 3, GameId = 65}, // Switch
        new PlatformGame { Id = 246, PlatformId = 4, GameId = 65}, // Xbox One
        new PlatformGame { Id = 247, PlatformId = 5, GameId = 65}, // PS5
        new PlatformGame { Id = 248, PlatformId = 6, GameId = 65}, // Xbox Series X
        new PlatformGame { Id = 249, PlatformId = 8, GameId = 65}, // PS3
        new PlatformGame { Id = 250, PlatformId = 9, GameId = 65}, // Xbox 360
        new PlatformGame { Id = 251, PlatformId = 10, GameId = 65}, // Wii U
        new PlatformGame { Id = 252, PlatformId = 16, GameId = 65}, // GameCube

        // Street Fighter II
        new PlatformGame { Id = 253, PlatformId = 2, GameId = 66}, // PC (Various versions through the years)
        new PlatformGame { Id = 254, PlatformId = 3, GameId = 66}, // Switch (Ultra Street Fighter II)
        new PlatformGame { Id = 255, PlatformId = 14, GameId = 66}, // SNES (Street Fighter II Turbo)
        new PlatformGame { Id = 256, PlatformId = 15, GameId = 66}, // Sega Genesis (Street Fighter II: Special Champion Edition)

        // Chrono Trigger
        new PlatformGame { Id = 257, PlatformId = 2, GameId = 67}, // PC (Steam version)
        new PlatformGame { Id = 258, PlatformId = 3, GameId = 67}, // Switch (via DS version available on eShop)
        new PlatformGame { Id = 259, PlatformId = 14, GameId = 67}, // SNES
        new PlatformGame { Id = 260, PlatformId = 8, GameId = 67}, // PS3 (Via PSN)

        // Mega Man X
        new PlatformGame { Id = 261, PlatformId = 2, GameId = 68}, // PC (Mega Man X Legacy Collection)
        new PlatformGame { Id = 262, PlatformId = 3, GameId = 68}, // Switch (Mega Man X Legacy Collection)
        new PlatformGame { Id = 263, PlatformId = 14, GameId = 68}, // SNES

        // Silent Hill 2
        new PlatformGame { Id = 264, PlatformId = 2, GameId = 69}, // PC
        new PlatformGame { Id = 265, PlatformId = 8, GameId = 69}, // PS3 (Silent Hill HD Collection)
        new PlatformGame { Id = 266, PlatformId = 9, GameId = 69}, // Xbox 360 (Silent Hill HD Collection)
        new PlatformGame { Id = 267, PlatformId = 12, GameId = 69}, // PS2

        // Baldur's Gate II: Shadows of Amn
        new PlatformGame { Id = 268, PlatformId = 2, GameId = 70}, // PC (Original and Enhanced Edition)
        new PlatformGame { Id = 269, PlatformId = 3, GameId = 70}, // Switch (Enhanced Edition)
        new PlatformGame { Id = 270, PlatformId = 1, GameId = 70}, // PS4 (Enhanced Edition)
        new PlatformGame { Id = 271, PlatformId = 4, GameId = 70}, // Xbox One (Enhanced Edition)
        // Metroid Prime
        new PlatformGame { Id = 272, PlatformId = 16, GameId = 71}, // GameCube
        new PlatformGame { Id = 273, PlatformId = 10, GameId = 71}, // Wii U (Via backward compatibility with Wii version)

        // Diablo II
        new PlatformGame { Id = 274, PlatformId = 2, GameId = 72}, // PC (Original and Resurrected)
        new PlatformGame { Id = 275, PlatformId = 1, GameId = 72}, // PS4 (Resurrected)
        new PlatformGame { Id = 276, PlatformId = 4, GameId = 72}, // Xbox One (Resurrected)
        new PlatformGame { Id = 277, PlatformId = 5, GameId = 72}, // PS5 (Resurrected)
        new PlatformGame { Id = 278, PlatformId = 6, GameId = 72}, // Xbox Series X (Resurrected)
        new PlatformGame { Id = 279, PlatformId = 3, GameId = 72}, // Switch (Resurrected)

        // Half-Life
        new PlatformGame { Id = 280, PlatformId = 2, GameId = 73}, // PC

        // Prince of Persia: The Sands of Time
        new PlatformGame { Id = 281, PlatformId = 2, GameId = 74}, // PC
        new PlatformGame { Id = 282, PlatformId = 8, GameId = 74}, // PS3 (Via PS2 Classics)
        new PlatformGame { Id = 283, PlatformId = 12, GameId = 74}, // PS2
        new PlatformGame { Id = 284, PlatformId = 9, GameId = 74}, // Xbox 360 (Backward compatibility)
        new PlatformGame { Id = 285, PlatformId = 11, GameId = 74}, // Xbox

        // Super Metroid
        new PlatformGame { Id = 286, PlatformId = 3, GameId = 75}, // Switch (Via SNES Online)
        new PlatformGame { Id = 287, PlatformId = 14, GameId = 75}, // SNES
        // StarCraft
        new PlatformGame { Id = 288, PlatformId = 2, GameId = 47}, // PC

        // Monkey Island 2: LeChuck's Revenge
        new PlatformGame { Id = 289, PlatformId = 2, GameId = 77}, // PC (Special Edition)
        new PlatformGame { Id = 290, PlatformId = 1, GameId = 77}, // PS4 (Special Edition via backward compatibility)
        new PlatformGame { Id = 291, PlatformId = 8, GameId = 77}, // PS3 (Special Edition)
        new PlatformGame { Id = 292, PlatformId = 9, GameId = 77}, // Xbox 360 (Special Edition)

        // Age of Empires II
        new PlatformGame { Id = 293, PlatformId = 2, GameId = 78}, // PC (Original and Definitive Edition)

        // Quake
        new PlatformGame { Id = 294, PlatformId = 2, GameId = 79}, // PC (Original and Remastered)
        new PlatformGame { Id = 295, PlatformId = 1, GameId = 79}, // PS4 (Remastered)
        new PlatformGame { Id = 296, PlatformId = 4, GameId = 79}, // Xbox One (Remastered)
        new PlatformGame { Id = 297, PlatformId = 5, GameId = 79}, // PS5 (Remastered)
        new PlatformGame { Id = 298, PlatformId = 6, GameId = 79}, // Xbox Series X (Remastered)
        new PlatformGame { Id = 299, PlatformId = 3, GameId = 79}, // Switch (Remastered)

        // SimCity 2000
        new PlatformGame { Id = 300, PlatformId = 2, GameId = 80}, // PC
        new PlatformGame { Id = 301, PlatformId = 12, GameId = 80}, // PS1
        new PlatformGame { Id = 302, PlatformId = 15, GameId = 80}, // Sega Genesis (SimCity 2000)
        new PlatformGame { Id = 303, PlatformId = 14, GameId = 80}, // SNES

        // Final Fantasy VI
        new PlatformGame { Id = 304, PlatformId = 2, GameId = 81}, // PC (Steam version)
        new PlatformGame { Id = 305, PlatformId = 3, GameId = 81}, // Switch (Pixel Remaster)
        new PlatformGame { Id = 306, PlatformId = 14, GameId = 81}, // SNES (original release as "Final Fantasy III" in North America)
        new PlatformGame { Id = 307, PlatformId = 12, GameId = 81}, // PS1 (as part of Final Fantasy Anthology)

        // Batman: Arkham City
        new PlatformGame { Id = 308, PlatformId = 2, GameId = 82}, // PC
        new PlatformGame { Id = 309, PlatformId = 1, GameId = 82}, // PS4 (Return to Arkham version)
        new PlatformGame { Id = 310, PlatformId = 4, GameId = 82}, // Xbox One (Return to Arkham version)
        new PlatformGame { Id = 311, PlatformId = 8, GameId = 82}, // PS3
        new PlatformGame { Id = 312, PlatformId = 9, GameId = 82}, // Xbox 360

        // Marvel's Spider-Man
        new PlatformGame { Id = 313, PlatformId = 1, GameId = 83}, // PS4
        new PlatformGame { Id = 314, PlatformId = 5, GameId = 83}, // PS5 (Remastered version)

        // Diablo
        new PlatformGame { Id = 315, PlatformId = 2, GameId = 84}, // PC

        // System Shock 2
        new PlatformGame { Id = 316, PlatformId = 2, GameId = 85}, // PC

        // Doom II
        new PlatformGame { Id = 317, PlatformId = 2, GameId = 86}, // PC
        new PlatformGame { Id = 318, PlatformId = 8, GameId = 86}, // PS3 (Doom Classic Complete)
        new PlatformGame { Id = 319, PlatformId = 9, GameId = 86}, // Xbox 360
        new PlatformGame { Id = 320, PlatformId = 4, GameId = 86}, // Xbox One (backward compatibility)
        new PlatformGame { Id = 321, PlatformId = 1, GameId = 86}, // PS4
        new PlatformGame { Id = 322, PlatformId = 3, GameId = 86}, // Switch

        // Marvel's Wolverine (assuming this is an upcoming game, as of my last training data in 2022)
        // Note: Platforms based on common release platforms for AAA games as of 2022, but might be subject to change.
        new PlatformGame { Id = 323, PlatformId = 5, GameId = 87}, // PS5
        new PlatformGame { Id = 324, PlatformId = 6, GameId = 87}, // Xbox Series X

        // Marvel vs. Capcom 3
        new PlatformGame { Id = 325, PlatformId = 2, GameId = 88}, // PC
        new PlatformGame { Id = 326, PlatformId = 8, GameId = 88}, // PS3
        new PlatformGame { Id = 327, PlatformId = 9, GameId = 88}, // Xbox 360
        new PlatformGame { Id = 328, PlatformId = 1, GameId = 88}, // PS4 (Ultimate version)

        // Max Payne
        new PlatformGame { Id = 329, PlatformId = 2, GameId = 89}, // PC
        new PlatformGame { Id = 330, PlatformId = 8, GameId = 89}, // PS3 (PS2 Classics)
        new PlatformGame { Id = 331, PlatformId = 12, GameId = 89}, // PS2
        new PlatformGame { Id = 332, PlatformId = 9, GameId = 89}, // Xbox 360 (backward compatibility)
        new PlatformGame { Id = 333, PlatformId = 11, GameId = 89}, // Xbox

        // Fallout 3
        new PlatformGame { Id = 334, PlatformId = 2, GameId = 90}, // PC
        new PlatformGame { Id = 335, PlatformId = 8, GameId = 90}, // PS3
        new PlatformGame { Id = 336, PlatformId = 9, GameId = 90}, // Xbox 360
        new PlatformGame { Id = 337, PlatformId = 4, GameId = 90}, // Xbox One (backward compatibility)
        // Banjo-Kazooie
        new PlatformGame { Id = 338, PlatformId = 9, GameId = 91}, // Xbox 360 (as part of Rare Replay and standalone)
        new PlatformGame { Id = 339, PlatformId = 4, GameId = 91}, // Xbox One (backward compatibility and as part of Rare Replay)
        new PlatformGame { Id = 340, PlatformId = 13, GameId = 91}, // Nintendo 64 (original release)

        // Dragon Ball Z: Buu's Fury
        new PlatformGame { Id = 341, PlatformId = 20, GameId = 92}, // Mobile (via Game Boy Advance emulators)
        // Note: Original platform was Game Boy Advance, which isn't listed among the platforms provided.

        // Deus Ex
        new PlatformGame { Id = 342, PlatformId = 2, GameId = 93}, // PC

        // Kingdom Hearts 2
        new PlatformGame { Id = 343, PlatformId = 2, GameId = 94}, // PC (via Kingdom Hearts HD collections)
        new PlatformGame { Id = 344, PlatformId = 1, GameId = 94}, // PS4 (as part of various Kingdom Hearts HD collections)
        new PlatformGame { Id = 345, PlatformId = 5, GameId = 94}, // PS5 (as part of various Kingdom Hearts HD collections)
        new PlatformGame { Id = 346, PlatformId = 12, GameId = 94}, // PS2 (original release)
        new PlatformGame { Id = 347, PlatformId = 3, GameId = 94}, // Switch (Cloud version)

        // Command & Conquer: Red Alert
        new PlatformGame { Id = 348, PlatformId = 2, GameId = 95}, // PC (original and Remastered version)
        new PlatformGame { Id = 349, PlatformId = 19, GameId = 95}, // PlayStation (original release as Command & Conquer: Red Alert)
        new PlatformGame { Id = 350, PlatformId = 15, GameId = 95}, // Sega Saturn (original release)

        // Far Cry 5
        new PlatformGame { Id = 351, PlatformId = 2, GameId = 96}, // PC
        new PlatformGame { Id = 352, PlatformId = 1, GameId = 96}, // PS4
        new PlatformGame { Id = 353, PlatformId = 4, GameId = 96}, // Xbox One
        new PlatformGame { Id = 354, PlatformId = 5, GameId = 96}, // PS5 (via backward compatibility)
        new PlatformGame { Id = 355, PlatformId = 6, GameId = 96}, // Xbox Series X (via backward compatibility)

        // Wing Commander
        new PlatformGame { Id = 356, PlatformId = 2, GameId = 97}, // PC (original release)

        // Myst
        new PlatformGame { Id = 357, PlatformId = 2, GameId = 98}, // PC (original and various remastered versions)
        new PlatformGame { Id = 358, PlatformId = 3, GameId = 98}, // Nintendo Switch (RealMyst)
        new PlatformGame { Id = 359, PlatformId = 18, GameId = 98}, // PlayStation Portable (Myst)

        // Civilization
        new PlatformGame { Id = 360, PlatformId = 2, GameId = 99}, // PC (original release)

        // Deus Ex: Mankind Divided
        new PlatformGame { Id = 361, PlatformId = 2, GameId = 100}, // PC
        new PlatformGame { Id = 362, PlatformId = 1, GameId = 100}, // PS4
        new PlatformGame { Id = 363, PlatformId = 4, GameId = 100}, // Xbox One
        new PlatformGame { Id = 364, PlatformId = 8, GameId = 100}, // PS3 (though not common, the game did have some editions on older consoles)
        new PlatformGame { Id = 365, PlatformId = 9, GameId = 100}, // Xbox 360 (same note as for PS3)
        // Far Cry 6
        new PlatformGame { Id = 366, PlatformId = 2, GameId = 101}, // PC
        new PlatformGame { Id = 367, PlatformId = 1, GameId = 101}, // PS4
        new PlatformGame { Id = 368, PlatformId = 4, GameId = 101}, // Xbox One
        new PlatformGame { Id = 369, PlatformId = 5, GameId = 101}, // PS5
        new PlatformGame { Id = 370, PlatformId = 6, GameId = 101}, // Xbox Series X
        new PlatformGame { Id = 371, PlatformId = 3, GameId = 101}, // Switch

        // Mortal Kombat vs. DC Universe
        new PlatformGame { Id = 372, PlatformId = 8, GameId = 102}, // PS3
        new PlatformGame { Id = 373, PlatformId = 9, GameId = 102}, // Xbox 360

        // Batman: Arkham Origins
        new PlatformGame { Id = 374, PlatformId = 2, GameId = 103}, // PC
        new PlatformGame { Id = 375, PlatformId = 8, GameId = 103}, // PS3
        new PlatformGame { Id = 376, PlatformId = 9, GameId = 103}, // Xbox 360
        new PlatformGame { Id = 377, PlatformId = 1, GameId = 103}, // PS4 (via Return to Arkham collection)
        new PlatformGame { Id = 378, PlatformId = 4, GameId = 103}, // Xbox One (via backward compatibility and Return to Arkham collection)

        // Kingdom Hearts
        new PlatformGame { Id = 379, PlatformId = 2, GameId = 104}, // PC (via Kingdom Hearts HD collections)
        new PlatformGame { Id = 380, PlatformId = 1, GameId = 104}, // PS4 (via various Kingdom Hearts HD collections)
        new PlatformGame { Id = 381, PlatformId = 5, GameId = 104}, // PS5 (via various Kingdom Hearts HD collections)
        new PlatformGame { Id = 382, PlatformId = 12, GameId = 104}, // PS2 (original release)
        new PlatformGame { Id = 383, PlatformId = 3, GameId = 104}, // Switch (Cloud version)

        // Marvel's Spider-Man 2 (assuming it's the sequel to the PS4 game)
        new PlatformGame { Id = 384, PlatformId = 5, GameId = 105}, // PS5
        // Batman: Arkham Asylum
        new PlatformGame { Id = 385, PlatformId = 2, GameId = 106}, // PC
        new PlatformGame { Id = 386, PlatformId = 8, GameId = 106}, // PS3
        new PlatformGame { Id = 387, PlatformId = 9, GameId = 106}, // Xbox 360
        new PlatformGame { Id = 388, PlatformId = 1, GameId = 106}, // PS4 (via Return to Arkham collection)
        new PlatformGame { Id = 389, PlatformId = 4, GameId = 106}, // Xbox One (via backward compatibility and Return to Arkham collection)

        // Resident Evil 2 (Assuming this is the original, not the remake)
        new PlatformGame { Id = 390, PlatformId = 12, GameId = 107}, // PS1
        new PlatformGame { Id = 391, PlatformId = 2, GameId = 107}, // PC
        new PlatformGame { Id = 392, PlatformId = 18, GameId = 107}, // Dreamcast
        new PlatformGame { Id = 393, PlatformId = 16, GameId = 107}, // GameCube

        // The Oregon Trail
        new PlatformGame { Id = 394, PlatformId = 2, GameId = 108}, // PC
        new PlatformGame { Id = 395, PlatformId = 7, GameId = 108}, // Mobile

        // Marvel's Avengers
        new PlatformGame { Id = 396, PlatformId = 1, GameId = 109}, // PS4
        new PlatformGame { Id = 397, PlatformId = 4, GameId = 109}, // Xbox One
        new PlatformGame { Id = 398, PlatformId = 2, GameId = 109}, // PC
        new PlatformGame { Id = 399, PlatformId = 5, GameId = 109}, // PS5
        new PlatformGame { Id = 400, PlatformId = 6, GameId = 109}, // Xbox Series X

        // Streets of Rage 2
        new PlatformGame { Id = 401, PlatformId = 15, GameId = 110}, // Sega Genesis
        new PlatformGame { Id = 402, PlatformId = 3, GameId = 110}, // Nintendo Switch (via various collections)
        new PlatformGame { Id = 403, PlatformId = 2, GameId = 110}, // PC (via various collections)
        // ARK: Survival Evolved
        new PlatformGame { Id = 404, PlatformId = 2, GameId = 111}, // PC
        new PlatformGame { Id = 405, PlatformId = 1, GameId = 111}, // PS4
        new PlatformGame { Id = 406, PlatformId = 4, GameId = 111}, // Xbox One
        new PlatformGame { Id = 407, PlatformId = 3, GameId = 111}, // Nintendo Switch
        new PlatformGame { Id = 408, PlatformId = 5, GameId = 111}, // PS5 (via backward compatibility)
        new PlatformGame { Id = 409, PlatformId = 6, GameId = 111}, // Xbox Series X (via backward compatibility)
        new PlatformGame { Id = 410, PlatformId = 7, GameId = 111}, // Mobile

        // Day of the Tentacle
        new PlatformGame { Id = 411, PlatformId = 2, GameId = 112}, // PC (original and remastered)
        new PlatformGame { Id = 412, PlatformId = 1, GameId = 112}, // PS4 (remastered)
        new PlatformGame { Id = 413, PlatformId = 8, GameId = 112}, // PS3 (remastered)

        // Fallout: New Vegas
        new PlatformGame { Id = 414, PlatformId = 2, GameId = 113}, // PC
        new PlatformGame { Id = 415, PlatformId = 8, GameId = 113}, // PS3
        new PlatformGame { Id = 416, PlatformId = 9, GameId = 113}, // Xbox 360
        new PlatformGame { Id = 417, PlatformId = 4, GameId = 113}, // Xbox One (via backward compatibility)

        // Kingdom Hearts 3
        new PlatformGame { Id = 418, PlatformId = 1, GameId = 114}, // PS4
        new PlatformGame { Id = 419, PlatformId = 4, GameId = 114}, // Xbox One
        new PlatformGame { Id = 420, PlatformId = 2, GameId = 114}, // PC
        new PlatformGame { Id = 421, PlatformId = 5, GameId = 114}, // PS5 (via updates and improved versions)
        new PlatformGame { Id = 422, PlatformId = 6, GameId = 114}, // Xbox Series X (via updates and improved versions)

        // Dragon Ball Z: Kakarot
        new PlatformGame { Id = 423, PlatformId = 1, GameId = 115}, // PS4
        new PlatformGame { Id = 424, PlatformId = 4, GameId = 115}, // Xbox One
        new PlatformGame { Id = 425, PlatformId = 2, GameId = 115}, // PC
        new PlatformGame { Id = 426, PlatformId = 5, GameId = 115}, // PS5 (via backward compatibility)
        new PlatformGame { Id = 427, PlatformId = 6, GameId = 115}, // Xbox Series X (via backward compatibility)

        // Diddy Kong Racing
        new PlatformGame { Id = 428, PlatformId = 13, GameId = 116}, // Nintendo 64

        // Super Mario 64
        new PlatformGame { Id = 429, PlatformId = 13, GameId = 117}, // Nintendo 64
        new PlatformGame { Id = 430, PlatformId = 3, GameId = 117}, // Nintendo Switch (via Super Mario 3D All-Stars)

        // The Legend of Zelda: Ocarina of Time
        new PlatformGame { Id = 431, PlatformId = 13, GameId = 118}, // Nintendo 64
        new PlatformGame { Id = 432, PlatformId = 16, GameId = 118}, // GameCube (via various collections)

        // Halo: Reach
        new PlatformGame { Id = 433, PlatformId = 9, GameId = 119}, // Xbox 360
        new PlatformGame { Id = 434, PlatformId = 4, GameId = 119}, // Xbox One (via Halo: The Master Chief Collection)
        new PlatformGame { Id = 435, PlatformId = 6, GameId = 119}, // Xbox Series X (via backward compatibility and Halo: The Master Chief Collection)
        new PlatformGame { Id = 436, PlatformId = 2, GameId = 119}, // PC (via Halo: The Master Chief Collection)

        // Portal
        new PlatformGame { Id = 437, PlatformId = 2, GameId = 120}, // PC
        new PlatformGame { Id = 438, PlatformId = 8, GameId = 120}, // PS3 (as part of The Orange Box)
        new PlatformGame { Id = 439, PlatformId = 9, GameId = 120}, // Xbox 360 (as part of The Orange Box)
        new PlatformGame { Id = 440, PlatformId = 4, GameId = 120}, // Xbox One (via backward compatibility for The Orange Box)

        // Starfield (unchanged from earlier)
        new PlatformGame { Id = 441, PlatformId = 2, GameId = 121}, // PC
        new PlatformGame { Id = 442, PlatformId = 6, GameId = 121}, // Xbox Series X

        // Lies of P
        new PlatformGame { Id = 443, PlatformId = 2, GameId = 122}, // PC
        new PlatformGame { Id = 444, PlatformId = 5, GameId = 122}, // PlayStation 5
        new PlatformGame { Id = 445, PlatformId = 6, GameId = 122}, // Xbox Series X

        // Payday (unchanged from earlier)
        new PlatformGame { Id = 446, PlatformId = 2, GameId = 123}, // PC
        new PlatformGame { Id = 447, PlatformId = 8, GameId = 123}, // PS3
        new PlatformGame { Id = 448, PlatformId = 9, GameId = 123}, // Xbox 360

        // Payday 2 (unchanged from earlier)
        new PlatformGame { Id = 449, PlatformId = 2, GameId = 124}, // PC
        new PlatformGame { Id = 450, PlatformId = 1, GameId = 124}, // PS4
        new PlatformGame { Id = 451, PlatformId = 4, GameId = 124}, // Xbox One
        new PlatformGame { Id = 452, PlatformId = 8, GameId = 124}, // PS3
        new PlatformGame { Id = 453, PlatformId = 9, GameId = 124}, // Xbox 360
        new PlatformGame { Id = 454, PlatformId = 3, GameId = 124}, // Nintendo Switch

        // Payday 3
        new PlatformGame { Id = 455, PlatformId = 2, GameId = 125}, // PC
        new PlatformGame { Id = 456, PlatformId = 5, GameId = 125}, // PlayStation 5
        new PlatformGame { Id = 457, PlatformId = 6, GameId = 125}, // Xbox Series X
        new PlatformGame { Id = 458, PlatformId = 3, GameId = 125}, // Nintendo Switch

        // Crackdown
        new PlatformGame { Id = 459, PlatformId = 9, GameId = 126}, // Xbox 360
        new PlatformGame { Id = 460, PlatformId = 4, GameId = 126}, // Xbox One (via backward compatibility)

        // Overwatch 2
        new PlatformGame { Id = 461, PlatformId = 1, GameId = 127}, // PlayStation 4
        new PlatformGame { Id = 462, PlatformId = 2, GameId = 127}, // PC
        new PlatformGame { Id = 463, PlatformId = 4, GameId = 127}, // Xbox One
        new PlatformGame { Id = 464, PlatformId = 5, GameId = 127}, // PlayStation 5
        new PlatformGame { Id = 465, PlatformId = 6, GameId = 127}, // Xbox Series X
        new PlatformGame { Id = 466, PlatformId = 3, GameId = 127}, // Nintendo Switch

        // Donkey Kong 64
        new PlatformGame { Id = 467, PlatformId = 13, GameId = 128}, // Nintendo 64

        // Starfox 64
        new PlatformGame { Id = 468, PlatformId = 13, GameId = 129}, // Nintendo 64

        // Elden Ring
        new PlatformGame { Id = 469, PlatformId = 1, GameId = 130}, // PlayStation 4
        new PlatformGame { Id = 470, PlatformId = 2, GameId = 130}, // PC
        new PlatformGame { Id = 471, PlatformId = 4, GameId = 130}, // Xbox One
        new PlatformGame { Id = 472, PlatformId = 5, GameId = 130}, // PlayStation 5
        new PlatformGame { Id = 473, PlatformId = 6, GameId = 130}, // Xbox Series X

        // Super Mario Galaxy
        new PlatformGame { Id = 474, PlatformId = 10, GameId = 131}, // Wii (original platform)
        new PlatformGame { Id = 475, PlatformId = 11, GameId = 131}, // Nintendo Switch (via Super Mario 3D All-Stars)

        // Bloodborne
        new PlatformGame { Id = 476, PlatformId = 1, GameId = 132}, // PlayStation 4

        // The Last of Us
        new PlatformGame { Id = 477, PlatformId = 1, GameId = 133}, // PlayStation 4 (Remastered version)
        new PlatformGame { Id = 478, PlatformId = 8, GameId = 133}, // PlayStation 3 (Original version)

        // Grand Theft Auto 3
        new PlatformGame { Id = 479, PlatformId = 8, GameId = 134}, // PlayStation 3 (via PSN)
        new PlatformGame { Id = 480, PlatformId = 11, GameId = 134}, // PlayStation 2 (original release)
        new PlatformGame { Id = 481, PlatformId = 9, GameId = 134}, // Xbox (original release)
        new PlatformGame { Id = 482, PlatformId = 2, GameId = 134}, // PC
        new PlatformGame { Id = 483, PlatformId = 7, GameId = 134}, // Mobile

        // Grand Theft Auto 4
        new PlatformGame { Id = 484, PlatformId = 8, GameId = 135}, // PlayStation 3
        new PlatformGame { Id = 485, PlatformId = 9, GameId = 135}, // Xbox 360
        new PlatformGame { Id = 486, PlatformId = 2, GameId = 135}, // PC

        // Final Fantasy X
        new PlatformGame { Id = 487, PlatformId = 11, GameId = 136}, // PlayStation 2 (original release)
        new PlatformGame { Id = 488, PlatformId = 8, GameId = 136}, // PlayStation 3 (HD Remaster)
        new PlatformGame { Id = 489, PlatformId = 1, GameId = 136}, // PlayStation 4 (HD Remaster)
        new PlatformGame { Id = 490, PlatformId = 3, GameId = 136}, // Nintendo Switch (HD Remaster)
        new PlatformGame { Id = 491, PlatformId = 2, GameId = 136}, // PC (HD Remaster)

        // Shadow of the Colossus
        new PlatformGame { Id = 492, PlatformId = 11, GameId = 137}, // PlayStation 2 (original release)
        new PlatformGame { Id = 493, PlatformId = 8, GameId = 137}, // PlayStation 3 (HD Remaster)
        new PlatformGame { Id = 494, PlatformId = 1, GameId = 137}, // PlayStation 4 (Remake)

        // The Outer Worlds
        new PlatformGame { Id = 495, PlatformId = 1, GameId = 138}, // PlayStation 4
        new PlatformGame { Id = 496, PlatformId = 2, GameId = 138}, // PC
        new PlatformGame { Id = 497, PlatformId = 4, GameId = 138}, // Xbox One
        new PlatformGame { Id = 498, PlatformId = 3, GameId = 138}, // Nintendo Switch

        // Bioshock
        new PlatformGame { Id = 499, PlatformId = 8, GameId = 139}, // PlayStation 3
        new PlatformGame { Id = 500, PlatformId = 9, GameId = 139}, // Xbox 360
        new PlatformGame { Id = 501, PlatformId = 2, GameId = 139}, // PC
        new PlatformGame { Id = 502, PlatformId = 1, GameId = 139}, // PlayStation 4 (Bioshock: The Collection)
        new PlatformGame { Id = 503, PlatformId = 4, GameId = 139}, // Xbox One (Bioshock: The Collection)

        // Bioshock Infinite
        new PlatformGame { Id = 504, PlatformId = 8, GameId = 140}, // PlayStation 3
        new PlatformGame { Id = 505, PlatformId = 9, GameId = 140}, // Xbox 360
        new PlatformGame { Id = 506, PlatformId = 2, GameId = 140}, // PC
        new PlatformGame { Id = 507, PlatformId = 1, GameId = 140}, // PlayStation 4 (Bioshock: The Collection)
        new PlatformGame { Id = 508, PlatformId = 4, GameId = 140}, // Xbox One (Bioshock: The Collection)

        // Disco Elysium
        new PlatformGame { Id = 509, PlatformId = 2, GameId = 141}, // PC (original platform)
        new PlatformGame { Id = 510, PlatformId = 1, GameId = 141}, // PlayStation 4
        new PlatformGame { Id = 511, PlatformId = 5, GameId = 141}, // PlayStation 5
        new PlatformGame { Id = 512, PlatformId = 4, GameId = 141}, // Xbox One
        new PlatformGame { Id = 513, PlatformId = 6, GameId = 141}, // Xbox Series X
        new PlatformGame { Id = 514, PlatformId = 3, GameId = 141}, // Nintendo Switch

        // Red Dead Revolver
        new PlatformGame { Id = 515, PlatformId = 11, GameId = 142}, // PlayStation 2 (original platform)
        new PlatformGame { Id = 516, PlatformId = 9, GameId = 142}, // Xbox (original platform)
        new PlatformGame { Id = 517, PlatformId = 8, GameId = 142}, // PlayStation 3 (via PSN)
        new PlatformGame { Id = 518, PlatformId = 2, GameId = 142}, // PC

        // Dishonored
        new PlatformGame { Id = 519, PlatformId = 8, GameId = 143}, // PlayStation 3
        new PlatformGame { Id = 520, PlatformId = 9, GameId = 143}, // Xbox 360
        new PlatformGame { Id = 521, PlatformId = 2, GameId = 143}, // PC
        new PlatformGame { Id = 522, PlatformId = 1, GameId = 143}, // PlayStation 4 (Definitive Edition)
        new PlatformGame { Id = 523, PlatformId = 4, GameId = 143}, // Xbox One (Definitive Edition)

        // Dishonored 2
        new PlatformGame { Id = 524, PlatformId = 1, GameId = 144}, // PlayStation 4
        new PlatformGame { Id = 525, PlatformId = 4, GameId = 144}, // Xbox One
        new PlatformGame { Id = 526, PlatformId = 2, GameId = 144}, // PC

        // Pokemon Red/Blue
        new PlatformGame { Id = 527, PlatformId = 20, GameId = 145}, // GameBoy (original platform, note the platform id change)

                // Metal Gear Solid V: The Phantom Pain
        new PlatformGame { Id = 528, PlatformId = 8, GameId = 146}, // PlayStation 3
        new PlatformGame { Id = 529, PlatformId = 9, GameId = 146}, // Xbox 360
        new PlatformGame { Id = 530, PlatformId = 1, GameId = 146}, // PlayStation 4
        new PlatformGame { Id = 531, PlatformId = 4, GameId = 146}, // Xbox One
        new PlatformGame { Id = 532, PlatformId = 2, GameId = 146}, // PC

        // Star Wars: Knights of the Old Republic
        new PlatformGame { Id = 533, PlatformId = 9, GameId = 147}, // Xbox (original platform)
        new PlatformGame { Id = 534, PlatformId = 2, GameId = 147}, // PC
        new PlatformGame { Id = 535, PlatformId = 7, GameId = 147}, // Mobile

        // Dragon Ball Z: The Legacy of Goku II
        new PlatformGame { Id = 536, PlatformId = 20, GameId = 148}, // GameBoy Advance

        // Fable
        new PlatformGame { Id = 537, PlatformId = 9, GameId = 149}, // Xbox (original platform)
        new PlatformGame { Id = 538, PlatformId = 2, GameId = 149}, // PC (Fable Anniversary)

        // Fable III
        new PlatformGame { Id = 539, PlatformId = 9, GameId = 150}, // Xbox 360
        new PlatformGame { Id = 540, PlatformId = 2, GameId = 150}, // PC

        // Star Wars: Jedi Survivor
        new PlatformGame { Id = 541, PlatformId = 6, GameId = 53},
        new PlatformGame { Id = 542, PlatformId = 5, GameId = 53},
        new PlatformGame { Id = 543, PlatformId = 2, GameId = 53},

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