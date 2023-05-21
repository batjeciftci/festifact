using System;
using festifact.server.Entities;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Database;

public class FestiFactDbContext : DbContext
{
    // Properties
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<FestivalCategory> FestivalCategories { get; set; }
    public DbSet<Festival> Festivals { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Artist> Artists { get; set; }

    // Constructor
    public FestiFactDbContext(DbContextOptions<FestiFactDbContext> options) : base(options) {}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Visitors
        modelBuilder.Entity<Visitor>().HasData(new Visitor
        {
            VisitorId = 1,
            Firstname = "paul",
            Lastname = "hertog",
            DateOfBirth = new DateOnly(1980, 4, 24),
            Sex = "male",
            Residence = "breda",
            Email = "paul@avans.nl",
            Password = 01234
        });

        modelBuilder.Entity<Visitor>().HasData(new Visitor
        {
            VisitorId = 2,
            Firstname = "hans",
            Lastname = "graaf",
            DateOfBirth = new DateOnly(1979, 5, 12),
            Sex = "male",
            Residence = "breda",
            Email = "hans@avans.nl",
            Password = 0034
        });

        modelBuilder.Entity<Visitor>().HasData(new Visitor
        {
            VisitorId = 3,
            Firstname = "tom",
            Lastname = "koning",
            DateOfBirth = new DateOnly(1950, 1, 14),
            Sex = "male",
            Residence = "scheveningen",
            Email = "tom@avans.nl",
            Password = 01211
        });

        modelBuilder.Entity<Visitor>().HasData(new Visitor
        {
            VisitorId = 4,
            Firstname = "linda",
            Lastname = "koningin",
            DateOfBirth = new DateOnly(2002, 10, 11),
            Sex = "female",
            Residence = "amsterdam",
            Email = "linda@avans.nl",
            Password = 0188
        });

        modelBuilder.Entity<Visitor>().HasData(new Visitor
        {
            VisitorId = 5,
            Firstname = "lieke",
            Lastname = "gravin",
            DateOfBirth = new DateOnly(1992, 3, 28),
            Sex = "female",
            Residence = "eindhoven",
            Email = "lieke@avans.nl",
            Password = 4591
        });

        modelBuilder.Entity<Visitor>().HasData(new Visitor
        {
            VisitorId = 6,
            Firstname = "roy",
            Lastname = "baron",
            DateOfBirth = new DateOnly(1995, 7, 8),
            Sex = "male",
            Residence = "rotterdam",
            Email = "roy@avans.nl",
            Password = 12399
        });

        // Shows
        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 1,
            Title = "main stage madness",
            Description = "Get ready for an explosive showcase of music as top artists take the main stage by storm. Experience an unforgettable night filled with electrifying performances and high-energy entertainment.",
            ImageUrl = "/Images/Shows/mFestivalShow1.png",
            StartTime = new DateTime(2023, 7, 5, 18, 00, 00),
            EndTime = new DateTime(2023, 7, 5, 19, 30, 00),
            ArtistId = 2,
            FilmId = 0
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 2,
            Title = "acoustic bliss",
            Description = "Immerse yourself in the soothing melodies of acoustic music. Sit back, relax, and let the enchanting sounds of talented singer-songwriters create an atmosphere of pure bliss and heartfelt emotions.",
            ImageUrl = "/Images/Shows/mFestivalShow2.png",
            StartTime = new DateTime(2023, 6, 2, 14, 00, 00),
            EndTime = new DateTime(2023, 6, 2, 15, 30, 00),
            ArtistId = 1,
            FilmId = 0
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 3,
            Title = "rock revolution",
            Description = "Unleash your inner rock enthusiast and witness the raw power of live rock music.",
            ImageUrl = "/Images/Shows/mFestivalShow3.png",
            StartTime = new DateTime(2023, 6, 15, 16, 30, 00),
            EndTime = new DateTime(2023, 6, 15, 18, 30, 00),
            ArtistId = 3,
            FilmId = 0
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 4,
            Title = "opening night spectacular",
            Description = "Join us for a glamorous evening as we kick off the film festival in style.",
            ImageUrl = "/Images/Shows/fFestivalShow1.png",
            StartTime = new DateTime(2023, 7, 19, 20, 00, 00),
            EndTime = new DateTime(2023, 7, 19, 21, 30, 00),
            ArtistId = 0,
            FilmId = 3
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 5,
            Title = "classic cinema showcase",
            Description = "Step back in time and relish the golden era of cinema with a showcase of timeless classics.",
            ImageUrl = "/Images/Shows/fFestivalShow2.png",
            StartTime = new DateTime(2023, 6, 10, 19, 30, 00),
            EndTime = new DateTime(2023, 6, 10, 21, 30, 00),
            ArtistId = 0,
            FilmId = 2
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 6,
            Title = "indie gems gala",
            Description = "Celebrate the creativity and innovation of independent filmmaking with a showcase of captivating indie gems.",
            ImageUrl = "/Images/Shows/fFestivalShow3.png",
            StartTime = new DateTime(2023, 8, 25, 14, 30, 00),
            EndTime = new DateTime(2023, 8, 25, 16, 30, 00),
            ArtistId = 0,
            FilmId = 1
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 7,
            Title = "dance extravaganza",
            Description = "Immerse yourself in a dazzling display of dance styles and mesmerizing choreography.",
            ImageUrl = "/Images/Shows/dFestivalShow1.png",
            StartTime = new DateTime(2023, 9, 3, 16, 30, 00),
            EndTime = new DateTime(2023, 9, 3, 18, 00, 00),
            ArtistId = 4,
            FilmId = 0
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 8,
            Title = "street dance showdown",
            Description = "Witness the raw energy and fierce competition of street dance as crews battle it out in an electrifying showdown.",
            ImageUrl = "/Images/Shows/dFestivalShow2.png",
            StartTime = new DateTime(2023, 11, 7, 15, 00, 00),
            EndTime = new DateTime(2023, 11, 7, 17, 00, 00),
            ArtistId = 5,
            FilmId = 0
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 9,
            Title = "author spotlight",
            Description = "Step into the world of renowned authors as they take the stage to share insights into their works. Engage in fascinating discussions, hear captivating readings, and get a glimpse into the creative minds behind some of the most celebrated literary works.",
            ImageUrl = "/Images/Shows/lFestivalShow1.png",
            StartTime = new DateTime(2023, 12, 20, 15, 00, 00),
            EndTime = new DateTime(2023, 12, 20, 17, 00, 00),
            ArtistId = 0,
            FilmId = 0
        });

        modelBuilder.Entity<Show>().HasData(new Show
        {
            ShowId = 10,
            Title = "book club live",
            Description = "Join a vibrant book club discussion brought to life on stage.",
            ImageUrl = "/Images/Shows/lFestivalShow2.png",
            StartTime = new DateTime(2023, 11, 8, 17, 30, 00),
            EndTime = new DateTime(2023, 11, 8, 19, 30, 00),
            ArtistId = 0,
            FilmId = 0
        });

        // ShoppingCarts
        modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
        {
            ShoppingCartId = 1,
            VisitorId = 2
        });

        modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
        {
            ShoppingCartId = 2,
            VisitorId = 3
        });

        modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
        {
            ShoppingCartId = 3,
            VisitorId = 1
        });

        // Films
        modelBuilder.Entity<Film>().HasData(new Film
        {
            FilmId = 1,
            Title = "whispers in the dark",
            Description = "A haunting psychological thriller that delves into the depths of the human psyche.",
            Director = "olivia taylor",
            YearOfPublication = 1996,
            CountryOfOrigin = "australia"
        });

        modelBuilder.Entity<Film>().HasData(new Film
        {
            FilmId = 2,
            Title = "shadows of destiny",
            Description = "In the atmospheric thriller Shadows of Destiny,\" shadows hold secrets and darkness conceals the truth.",
            Director = "samuel wright",
            YearOfPublication = 2011,
            CountryOfOrigin = "canada"
        });

        modelBuilder.Entity<Film>().HasData(new Film
        {
            FilmId = 3,
            Title = "fragments of time",
            Description = "Fragments of Time pieces together fragmented memories, intersecting timelines, and the threads of destiny.",
            Director = "isabella lee",
            YearOfPublication = 2016,
            CountryOfOrigin = "usa"
        });

        modelBuilder.Entity<Film>().HasData(new Film
        {
            FilmId = 4,
            Title = "journey of the soul",
            Description = "Embark on a profound and introspective Journey of the Soul.",
            Director = "ethan anderson",
            YearOfPublication = 2012,
            CountryOfOrigin = "ireland"
        });

        modelBuilder.Entity<Film>().HasData(new Film
        {
            FilmId = 5,
            Title = "lost in reverie",
            Description = "A captivating romantic drama that explores the transformative power of love and the delicate nature of human connections.",
            Director = "benjamin martinez",
            YearOfPublication = 2020,
            CountryOfOrigin = "england"
        });

        modelBuilder.Entity<Film>().HasData(new Film
        {
            FilmId = 6,
            Title = "echoes of yesterday",
            Description = "Echoes of Yesterday takes audiences on a nostalgic journey through time.",
            Director = "ava williams",
            YearOfPublication = 2008,
            CountryOfOrigin = "usa"
        });

        // FestivalCategories
        modelBuilder.Entity<FestivalCategory>().HasData(new FestivalCategory
        {
            FestivalCategoryId = 1,
            Name = "music festival"
        });

        modelBuilder.Entity<FestivalCategory>().HasData(new FestivalCategory
        {
            FestivalCategoryId = 2,
            Name = "film festival"
        });

        modelBuilder.Entity<FestivalCategory>().HasData(new FestivalCategory
        {
            FestivalCategoryId = 3,
            Name = "dance festival"
        });

        modelBuilder.Entity<FestivalCategory>().HasData(new FestivalCategory
        {
            FestivalCategoryId = 4,
            Name = "literature festival"
        });

        // Festivals
        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 1,
            Title = "harmony music fest",
            Description = "Immerse yourself in a harmonious celebration of music at Harmony Music Fest.",
            Date = new DateTime(2023, 6, 2, 14, 00, 00),
            BannerImageUrl = "/Images/Music/mFestival1.png",
            Genre = "pop",
            Age = 21,
            NumberOfDays = 3,
            Location = "amsterdam",
            Price = 30,
            Capacity = 200,
            ShowId = 2,
            FestivalCategoryId = 1
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 2,
            Title = "melody mania",
            Description = "Indulge your senses in a melodic extravaganza at Melody Mania.",
            Date = new DateTime(2023, 6, 15, 16, 30, 00),
            BannerImageUrl = "/Images/Music/mFestival2.png",
            Genre = "deephouse",
            Age = 18,
            NumberOfDays = 2,
            Location = "rotterdam",
            Price = 15,
            Capacity = 120,
            ShowId = 3,
            FestivalCategoryId = 1
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 3,
            Title = "rhythm revival",
            Description = "Get ready to groove at Rhythm Revival, where the beats come alive and the dance floor ignites.",
            Date = new DateTime(2023, 7, 5, 18, 00, 00),
            BannerImageUrl = "/Images/Music/mFestival3.png",
            Genre = "urban",
            Age = 22,
            NumberOfDays = 4,
            Location = "utrecht",
            Price = 50,
            Capacity = 180,
            ShowId = 1,
            FestivalCategoryId = 1
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 4,
            Title = "sonic music summit",
            Description = "Prepare for a sonic journey like no other at Sonic Music Summit.",
            Date = new DateTime(2023, 8, 12, 17, 00, 00),
            BannerImageUrl = "/Images/Music/mFestival4.png",
            Genre = "techno",
            Age = 21,
            NumberOfDays = 2,
            Location = "breda",
            Price = 25,
            Capacity = 250,
            ShowId = 2,
            FestivalCategoryId = 1
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 5,
            Title = "frame by frame",
            Description = "Explore the art and craft of filmmaking, frame by frame, at this captivating film festival.",
            Date = new DateTime(2023, 6, 10, 19, 30, 00),
            BannerImageUrl = "/Images/Film/fFestival1.png",
            Genre = "drama",
            Age = 18,
            NumberOfDays = 2,
            Location = "eindhoven",
            Price = 15,
            Capacity = 150,
            ShowId = 5,
            FestivalCategoryId = 2
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 6,
            Title = "cinematic kaleidoscope",
            Description = "Immerse yourself in a dazzling array of cinematic experiences at the Cinematic Kaleidoscope film festival.",
            Date = new DateTime(2023, 7, 19, 20, 00, 00),
            BannerImageUrl = "/Images/Film/fFestival2.png",
            Genre = "comedy",
            Age = 8,
            NumberOfDays = 5,
            Location = "groningen",
            Price = 12,
            Capacity = 500,
            ShowId = 4,
            FestivalCategoryId = 2
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 7,
            Title = "silver screen showcase",
            Description = "Step into a world of cinematic enchantment at the Silver Screen Showcase film festival.",
            Date = new DateTime(2023, 8, 25, 14, 30, 00),
            BannerImageUrl = "/Images/Film/fFestival3.png",
            Genre = "action",
            Age = 18,
            NumberOfDays = 3,
            Location = "maastricht",
            Price = 18,
            Capacity = 300,
            ShowId = 6,
            FestivalCategoryId = 2
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 8,
            Title = "reel masterpieces",
            Description = "Prepare to be captivated by the artistry and brilliance of cinema at the Reel Masterpieces film festival.",
            Date = new DateTime(2023, 10, 12, 21, 00, 00),
            BannerImageUrl = "/Images/Film/fFestival4.png",
            Genre = "romance",
            Age = 21,
            NumberOfDays = 2,
            Location = "hilversum",
            Price = 20,
            Capacity = 120,
            ShowId = 4,
            FestivalCategoryId = 2
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 9,
            Title = "rhythm fusion",
            Description = "Experience the electrifying energy of Rhythm Fusion, where diverse dance styles collide and ignite the stage.",
            Date = new DateTime(2023, 9, 3, 16, 30, 00),
            BannerImageUrl = "/Images/Dance/dFestival1.png",
            Genre = "jazz dance",
            Age = 15,
            NumberOfDays = 4,
            Location = "eindhoven",
            Price = 15,
            Capacity = 200,
            ShowId = 7,
            FestivalCategoryId = 3
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 10,
            Title = "dance odyssey",
            Description = "Embark on a captivating Dance Odyssey, a journey through the rich tapestry of dance from around the world.",
            Date = new DateTime(2023, 11, 7, 15, 00, 00),
            BannerImageUrl = "/Images/Dance/dFestival2.png",
            Genre = "hiphop",
            Age = 18,
            NumberOfDays = 4,
            Location = "haarlem",
            Price = 25,
            Capacity = 280,
            ShowId = 8,
            FestivalCategoryId = 3
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 11,
            Title = "groove gala",
            Description = "Get ready to groove at the Groove Gala, an explosive celebration of music and dance.",
            Date = new DateTime(2023, 12, 12, 14, 30, 00),
            BannerImageUrl = "/Images/Dance/dFestival3.png",
            Genre = "jazz dance",
            Age = 21,
            NumberOfDays = 2,
            Location = "utrecht",
            Price = 30,
            Capacity = 220,
            ShowId = 7,
            FestivalCategoryId = 3
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 12,
            Title = "euphoric moves",
            Description = "Prepare to be mesmerized by Euphoric Moves, a festival that transcends the boundaries of dance and takes you on a euphoric journey of movement and expression.",
            Date = new DateTime(2024, 2, 5, 18, 00, 00),
            BannerImageUrl = "/Images/Dance/dFestival4.png",
            Genre = "latin dance",
            Age = 22,
            NumberOfDays = 2,
            Location = "amsterdam",
            Price = 35,
            Capacity = 200,
            ShowId = 8,
            FestivalCategoryId = 3
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 13,
            Title = "word weavers festival",
            Description = "Step into the enchanting world of storytelling and imagination at the Word Weavers Festival.",
            Date = new DateTime(2023, 11, 8, 17, 30, 00),
            BannerImageUrl = "/Images/Literature/lFestival1.png",
            Genre = "fiction",
            Age = 8,
            NumberOfDays = 2,
            Location = "breda",
            Price = 10,
            Capacity = 200,
            ShowId = 10,
            FestivalCategoryId = 4
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 14,
            Title = "literary confluence",
            Description = "Indulge in a fusion of literary voices and ideas at Literary Confluence, a festival that celebrates the diverse landscape of literature.",
            Date = new DateTime(2023, 12, 20, 15, 00, 00),
            BannerImageUrl = "/Images/Literature/lFestival2.png",
            Genre = "poetry",
            Age = 8,
            NumberOfDays = 3,
            Location = "rotterdam",
            Price = 8,
            Capacity = 350,
            ShowId = 9,
            FestivalCategoryId = 4
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 15,
            Title = "bookish delights",
            Description = "Enter a realm of literary delights at the Bookish Delights festival, where books come alive and reading is celebrated with fervor.",
            Date = new DateTime(2023, 10, 27, 12, 00, 00),
            BannerImageUrl = "/Images/Literature/lFestival3.png",
            Genre = "thriller",
            Age = 8,
            NumberOfDays = 2,
            Location = "groningen",
            Price = 15,
            Capacity = 180,
            ShowId = 10,
            FestivalCategoryId = 4
        });

        modelBuilder.Entity<Festival>().HasData(new Festival
        {
            FestivalId = 16,
            Title = "literary mosaic",
            Description = "Experience the rich tapestry of literature at the Literary Mosaic festival, where diverse voices and genres come together to create a vibrant literary landscape.",
            Date = new DateTime(2024, 2, 10, 12, 30, 00),
            BannerImageUrl = "/Images/Literature/lFestival4.png",
            Genre = "non fiction",
            Age = 8,
            NumberOfDays = 2,
            Location = "maastricht",
            Price = 12,
            Capacity = 250,
            ShowId = 9,
            FestivalCategoryId = 4
        });

        // CartItems
        modelBuilder.Entity<CartItem>().HasData(new CartItem
        {
            CartItemId = 1,
            NumberOfTickets = 2,
            TotalAmount = 100,
            FestivalId = 3,
            ShoppingCartId = 3
        });

        modelBuilder.Entity<CartItem>().HasData(new CartItem
        {
            CartItemId = 2,
            NumberOfTickets = 3,
            TotalAmount = 45,
            FestivalId = 2,
            ShoppingCartId = 1
        });

        modelBuilder.Entity<CartItem>().HasData(new CartItem
        {
            CartItemId = 3,
            NumberOfTickets = 1,
            TotalAmount = 25,
            FestivalId = 4,
            ShoppingCartId = 2
        });

        // Artists
        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 1,
            Name = "aurora reed",
            Description = "A name that evokes a sense of ethereal beauty and natural wonder.",
            CountryOfOrigin = "australia",
            Genre = "pop"
        });

        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 2,
            Name = "milo sullivan",
            Description = "A name that carries a sense of boldness and adventure.",
            CountryOfOrigin = "mexico",
            Genre = "rock"
        });

        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 3,
            Name = "isabella blake",
            Description = "A name that exudes elegance and grace.",
            CountryOfOrigin = "usa",
            Genre = "hiphop"
        });

        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 4,
            Name = "jasper graaf",
            Description = "A name that conjures images of bold strokes and expressive forms.",
            CountryOfOrigin = "netherlands",
            Genre = "soul"
        });

        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 5,
            Name = "luna martinez",
            Description = "A name that evokes a sense of enchantment and celestial wonder.",
            CountryOfOrigin = "portugal",
            Genre = "rap"
        });

        modelBuilder.Entity<Artist>().HasData(new Artist
        {
            ArtistId = 6,
            Name = "oliver brooks",
            Description = "A name that embodies a sense of versatility and versatility.",
            CountryOfOrigin = "ireland",
            Genre = "electronic"
        });
    }
}
