using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace festifact.server.Migrations
{
    /// <inheritdoc />
    public partial class DbSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfTickets = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FestivalId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                });

            migrationBuilder.CreateTable(
                name: "FestivalCategories",
                columns: table => new
                {
                    FestivalCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalCategories", x => x.FestivalCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    FestivalCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "CountryOfOrigin", "Description", "Genre", "Name" },
                values: new object[,]
                {
                    { 1, "australia", "A name that evokes a sense of ethereal beauty and natural wonder.", "pop", "aurora reed" },
                    { 2, "mexico", "A name that carries a sense of boldness and adventure.", "rock", "milo sullivan" },
                    { 3, "usa", "A name that exudes elegance and grace.", "hiphop", "isabella blake" },
                    { 4, "netherlands", "A name that conjures images of bold strokes and expressive forms.", "soul", "jasper graaf" },
                    { 5, "portugal", "A name that evokes a sense of enchantment and celestial wonder.", "rap", "luna martinez" },
                    { 6, "ireland", "A name that embodies a sense of versatility and versatility.", "electronic", "oliver brooks" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "FestivalId", "NumberOfTickets", "ShoppingCartId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 3, 2, 3, 100m },
                    { 2, 2, 3, 1, 45m },
                    { 3, 4, 1, 2, 25m }
                });

            migrationBuilder.InsertData(
                table: "FestivalCategories",
                columns: new[] { "FestivalCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "music festival" },
                    { 2, "film festival" },
                    { 3, "dance festival" },
                    { 4, "literature festival" }
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "FestivalId", "Age", "BannerImageUrl", "Capacity", "Date", "Description", "FestivalCategoryId", "Genre", "Location", "NumberOfDays", "Price", "ShowId", "Title" },
                values: new object[,]
                {
                    { 1, 21, "/Images/Music/mFestival1.png", 200, new DateTime(2023, 6, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "Immerse yourself in a harmonious celebration of music at Harmony Music Fest.", 1, "pop", "amsterdam", 3, 30, 2, "harmony music fest" },
                    { 2, 18, "/Images/Music/mFestival2.png", 120, new DateTime(2023, 6, 15, 16, 30, 0, 0, DateTimeKind.Unspecified), "Indulge your senses in a melodic extravaganza at Melody Mania.", 1, "deephouse", "rotterdam", 2, 15, 3, "melody mania" },
                    { 3, 22, "/Images/Music/mFestival3.png", 180, new DateTime(2023, 7, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), "Get ready to groove at Rhythm Revival, where the beats come alive and the dance floor ignites.", 1, "urban", "utrecht", 4, 50, 1, "rhythm revival" },
                    { 4, 21, "/Images/Music/mFestival4.png", 250, new DateTime(2023, 8, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Prepare for a sonic journey like no other at Sonic Music Summit.", 1, "techno", "breda", 2, 25, 2, "sonic music summit" },
                    { 5, 18, "/Images/Film/fFestival1.png", 150, new DateTime(2023, 6, 10, 19, 30, 0, 0, DateTimeKind.Unspecified), "Explore the art and craft of filmmaking, frame by frame, at this captivating film festival.", 2, "drama", "eindhoven", 2, 15, 5, "frame by frame" },
                    { 6, 8, "/Images/Film/fFestival2.png", 500, new DateTime(2023, 7, 19, 20, 0, 0, 0, DateTimeKind.Unspecified), "Immerse yourself in a dazzling array of cinematic experiences at the Cinematic Kaleidoscope film festival.", 2, "comedy", "groningen", 5, 12, 4, "cinematic kaleidoscope" },
                    { 7, 18, "/Images/Film/fFestival3.png", 300, new DateTime(2023, 8, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), "Step into a world of cinematic enchantment at the Silver Screen Showcase film festival.", 2, "action", "maastricht", 3, 18, 6, "silver screen showcase" },
                    { 8, 21, "/Images/Film/fFestival4.png", 120, new DateTime(2023, 10, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), "Prepare to be captivated by the artistry and brilliance of cinema at the Reel Masterpieces film festival.", 2, "romance", "hilversum", 2, 20, 4, "reel masterpieces" },
                    { 9, 15, "/Images/Dance/dFestival1.png", 200, new DateTime(2023, 9, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "Experience the electrifying energy of Rhythm Fusion, where diverse dance styles collide and ignite the stage.", 3, "jazz dance", "eindhoven", 4, 15, 7, "rhythm fusion" },
                    { 10, 18, "/Images/Dance/dFestival2.png", 280, new DateTime(2023, 11, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Embark on a captivating Dance Odyssey, a journey through the rich tapestry of dance from around the world.", 3, "hiphop", "haarlem", 4, 25, 8, "dance odyssey" },
                    { 11, 21, "/Images/Dance/dFestival3.png", 220, new DateTime(2023, 12, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), "Get ready to groove at the Groove Gala, an explosive celebration of music and dance.", 3, "jazz dance", "utrecht", 2, 30, 7, "groove gala" },
                    { 12, 22, "/Images/Dance/dFestival4.png", 200, new DateTime(2024, 2, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), "Prepare to be mesmerized by Euphoric Moves, a festival that transcends the boundaries of dance and takes you on a euphoric journey of movement and expression.", 3, "latin dance", "amsterdam", 2, 35, 8, "euphoric moves" },
                    { 13, 8, "/Images/Literature/lFestival1.png", 200, new DateTime(2023, 11, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), "Step into the enchanting world of storytelling and imagination at the Word Weavers Festival.", 4, "fiction", "breda", 2, 10, 10, "word weavers festival" },
                    { 14, 8, "/Images/Literature/lFestival2.png", 350, new DateTime(2023, 12, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), "Indulge in a fusion of literary voices and ideas at Literary Confluence, a festival that celebrates the diverse landscape of literature.", 4, "poetry", "rotterdam", 3, 8, 9, "literary confluence" },
                    { 15, 8, "/Images/Literature/lFestival3.png", 180, new DateTime(2023, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), "Enter a realm of literary delights at the Bookish Delights festival, where books come alive and reading is celebrated with fervor.", 4, "thriller", "groningen", 2, 15, 10, "bookish delights" },
                    { 16, 8, "/Images/Literature/lFestival4.png", 250, new DateTime(2024, 2, 10, 12, 30, 0, 0, DateTimeKind.Unspecified), "Experience the rich tapestry of literature at the Literary Mosaic festival, where diverse voices and genres come together to create a vibrant literary landscape.", 4, "non fiction", "maastricht", 2, 12, 9, "literary mosaic" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmId", "CountryOfOrigin", "Description", "Director", "Title", "YearOfPublication" },
                values: new object[,]
                {
                    { 1, "australia", "A haunting psychological thriller that delves into the depths of the human psyche.", "olivia taylor", "whispers in the dark", 1996 },
                    { 2, "canada", "In the atmospheric thriller Shadows of Destiny,\" shadows hold secrets and darkness conceals the truth.", "samuel wright", "shadows of destiny", 2011 },
                    { 3, "usa", "Fragments of Time pieces together fragmented memories, intersecting timelines, and the threads of destiny.", "isabella lee", "fragments of time", 2016 },
                    { 4, "ireland", "Embark on a profound and introspective Journey of the Soul.", "ethan anderson", "journey of the soul", 2012 },
                    { 5, "england", "A captivating romantic drama that explores the transformative power of love and the delicate nature of human connections.", "benjamin martinez", "lost in reverie", 2020 },
                    { 6, "usa", "Echoes of Yesterday takes audiences on a nostalgic journey through time.", "ava williams", "echoes of yesterday", 2008 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "VisitorId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "ArtistId", "Description", "EndTime", "FilmId", "ImageUrl", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Get ready for an explosive showcase of music as top artists take the main stage by storm. Experience an unforgettable night filled with electrifying performances and high-energy entertainment.", new DateTime(2023, 7, 5, 19, 30, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/mFestivalShow1.png", new DateTime(2023, 7, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), "main stage madness" },
                    { 2, 1, "Immerse yourself in the soothing melodies of acoustic music. Sit back, relax, and let the enchanting sounds of talented singer-songwriters create an atmosphere of pure bliss and heartfelt emotions.", new DateTime(2023, 6, 2, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/mFestivalShow2.png", new DateTime(2023, 6, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "acoustic bliss" },
                    { 3, 3, "Unleash your inner rock enthusiast and witness the raw power of live rock music.", new DateTime(2023, 6, 15, 18, 30, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/mFestivalShow3.png", new DateTime(2023, 6, 15, 16, 30, 0, 0, DateTimeKind.Unspecified), "rock revolution" },
                    { 4, 0, "Join us for a glamorous evening as we kick off the film festival in style.", new DateTime(2023, 7, 19, 21, 30, 0, 0, DateTimeKind.Unspecified), 3, "/Images/Shows/fFestivalShow1.png", new DateTime(2023, 7, 19, 20, 0, 0, 0, DateTimeKind.Unspecified), "opening night spectacular" },
                    { 5, 0, "Step back in time and relish the golden era of cinema with a showcase of timeless classics.", new DateTime(2023, 6, 10, 21, 30, 0, 0, DateTimeKind.Unspecified), 2, "/Images/Shows/fFestivalShow2.png", new DateTime(2023, 6, 10, 19, 30, 0, 0, DateTimeKind.Unspecified), "classic cinema showcase" },
                    { 6, 0, "Celebrate the creativity and innovation of independent filmmaking with a showcase of captivating indie gems.", new DateTime(2023, 8, 25, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "/Images/Shows/fFestivalShow3.png", new DateTime(2023, 8, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), "indie gems gala" },
                    { 7, 4, "Immerse yourself in a dazzling display of dance styles and mesmerizing choreography.", new DateTime(2023, 9, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/dFestivalShow1.png", new DateTime(2023, 9, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), "dance extravaganza" },
                    { 8, 5, "Witness the raw energy and fierce competition of street dance as crews battle it out in an electrifying showdown.", new DateTime(2023, 11, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/dFestivalShow2.png", new DateTime(2023, 11, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "street dance showdown" },
                    { 9, 0, "Step into the world of renowned authors as they take the stage to share insights into their works. Engage in fascinating discussions, hear captivating readings, and get a glimpse into the creative minds behind some of the most celebrated literary works.", new DateTime(2023, 12, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/lFestivalShow1.png", new DateTime(2023, 12, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), "author spotlight" },
                    { 10, 0, "Join a vibrant book club discussion brought to life on stage.", new DateTime(2023, 11, 8, 19, 30, 0, 0, DateTimeKind.Unspecified), 0, "/Images/Shows/lFestivalShow2.png", new DateTime(2023, 11, 8, 17, 30, 0, 0, DateTimeKind.Unspecified), "book club live" }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "VisitorId", "DateOfBirth", "Email", "Firstname", "Lastname", "Password", "Residence", "Sex" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "paul@avans.nl", "paul", "hertog", 1234, "breda", "male" },
                    { 2, new DateTime(1979, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "hans@avans.nl", "hans", "graaf", 34, "breda", "male" },
                    { 3, new DateTime(1950, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "tom@avans.nl", "tom", "koning", 1211, "scheveningen", "male" },
                    { 4, new DateTime(2002, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "linda@avans.nl", "linda", "koningin", 188, "amsterdam", "female" },
                    { 5, new DateTime(1992, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "lieke@avans.nl", "lieke", "gravin", 4591, "eindhoven", "female" },
                    { 6, new DateTime(1995, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "roy@avans.nl", "roy", "baron", 12399, "rotterdam", "male" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "FestivalCategories");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
