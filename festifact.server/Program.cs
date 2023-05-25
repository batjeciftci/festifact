using festifact.server.Database;
using festifact.server.Repositories;
using festifact.server.Repositories.Contracts;
using festifact.server.Services;
using festifact.server.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace festifact.server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("sqlconnection");
        builder.Services.AddDbContext<FestiFactDbContext>(options => options.UseSqlServer(connectionString));

        // Repositories
        builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
        builder.Services.AddScoped<IShowRepository, ShowRepository>();
        builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        builder.Services.AddScoped<IFilmRepository, FilmRepository>();
        builder.Services.AddScoped<IFestivalRepository, FestivalRepository>();
        builder.Services.AddScoped<IArtistRepository, ArtistRepository>();

        // Services
        builder.Services.AddScoped<IVisitorService, VisitorService>();
        builder.Services.AddScoped<IShowService, ShowService>();
        builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
        builder.Services.AddScoped<IFilmService, FilmService>();
        builder.Services.AddScoped<IFestivalService, FestivalService>();
        builder.Services.AddScoped<IArtistService, ArtistService>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

