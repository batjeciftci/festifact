using System;
using festifact.models.Dtos.Artist;
using festifact.models.Dtos.CartItem;
using festifact.models.Dtos.Festival;
using festifact.models.Dtos.Film;
using festifact.models.Dtos.Show;
using festifact.models.Dtos.Visitor;
using festifact.server.Entities;

namespace festifact.server.Helpers;

public static class DtoConversions
{
    public static IEnumerable<VisitorDto> ConvertToDto(this IEnumerable<Visitor> visitors)
    {
        var query = (from visitor in visitors
                     select new VisitorDto
                     {
                         VisitorId = visitor.VisitorId,
                         Firstname = visitor.Firstname,
                         Lastname = visitor.Lastname,
                         DateOfBirth = visitor.DateOfBirth,
                         Sex = visitor.Sex,
                         Residence = visitor.Residence,
                         Email = visitor.Email
                     }).ToList();

        return query;
    }

    public static VisitorDto ConvertToDto(this Visitor visitor)
    {
        return new VisitorDto
        {
            VisitorId = visitor.VisitorId,
            Firstname = visitor.Firstname,
            Lastname = visitor.Lastname,
            DateOfBirth = visitor.DateOfBirth,
            Sex = visitor.Sex,
            Residence = visitor.Residence,
            Email = visitor.Email
        };
    }

    public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> items)
    {
        var query = (from item in items
                     select new CartItemDto
                     {
                         CartItemId = item.CartItemId,
                         NumberOfTickets = item.NumberOfTickets,
                         TotalAmount = item.TotalAmount,
                         FestivalId = item.FestivalId,
                         ShoppingCartId = item.ShoppingCartId
                     }).ToList();

        return query;
    }

    public static CartItemDto ConvertToDto(this CartItem item)
    {
        return new CartItemDto
        {
            CartItemId = item.CartItemId,
            NumberOfTickets = item.NumberOfTickets,
            TotalAmount = item.TotalAmount,
            FestivalId = item.FestivalId,
            ShoppingCartId = item.ShoppingCartId
        };
    }

    public static IEnumerable<FilmDto> ConvertToDto(this IEnumerable<Film> films)
    {
        var query = (from film in films
                     select new FilmDto
                     {
                         FilmId = film.FilmId,
                         Title = film.Title,
                         Description = film.Description,
                         Director = film.Director,
                         YearOfPublication = film.YearOfPublication,
                         CountryOfOrigin = film.CountryOfOrigin
                     }).ToList();

        return query;
    }

    public static FilmDto ConvertToDto(this Film film)
    {
        return new FilmDto
        {
            FilmId = film.FilmId,
            Title = film.Title,
            Description = film.Description,
            Director = film.Director,
            YearOfPublication = film.YearOfPublication,
            CountryOfOrigin = film.CountryOfOrigin
        };
    }

    public static ArtistDto ConvertToDto(this Artist artist)
    {
        return new ArtistDto
        {
            ArtistId = artist.ArtistId,
            Name = artist.Name,
            Description = artist.Description,
            CountryOfOrigin = artist.CountryOfOrigin,
            Genre = artist.Genre
        };
    }

    public static IEnumerable<ArtistDto> ConvertToDto(this IEnumerable<Artist> artists)
    {
        return (from artist in artists
                select new ArtistDto
                {
                    ArtistId = artist.ArtistId,
                    Name = artist.Name,
                    Description = artist.Description,
                    CountryOfOrigin = artist.CountryOfOrigin,
                    Genre = artist.Genre
                }).ToList();
    }

    public static IEnumerable<ShowDto> ConvertToDto(this IEnumerable<Show> shows)
    {
        var query = (from show in shows
                     select new ShowDto
                     {
                         ShowId = show.ShowId,
                         Title = show.Title,
                         Description = show.Description,
                         ImageUrl = show.ImageUrl,
                         StartTime = show.StartTime,
                         EndTime = show.EndTime,
                         ArtistId = show.ArtistId,
                         FilmId = show.FilmId
                     }).ToList();

        return query;

        // Another way to achieve the same goal!
        //List<ShowDto> showList = new();

        //foreach (var show in shows)
        //{
        //    var showDto = new ShowDto
        //    {
        //        ShowId = show.ShowId,
        //        Title = show.Title,
        //        Description = show.Description,
        //        ImageUrl = show.ImageUrl,
        //        StartTime = show.StartTime,
        //        EndTime = show.EndTime,
        //        ArtistId = show.ArtistId,
        //        FilmId = show.FilmId
        //    };

        //    showList.Add(showDto);
        //}
        //return showList;
    }

    public static ShowDto ConvertToDto(this Show show)
    {
        return new ShowDto
        {
            ShowId = show.ShowId,
            Title = show.Title,
            Description = show.Description,
            ImageUrl = show.ImageUrl,
            StartTime = show.StartTime,
            EndTime = show.EndTime,
            ArtistId = show.ArtistId,
            FilmId = show.FilmId
        };
    }

    public static IEnumerable<FestivalToAddDto> ConvertToDto(this IEnumerable<Festival> festivals)
    {
        var query = (from festival in festivals
                     select new FestivalToAddDto
                     {
                         FestivalId = festival.FestivalId,
                         Title = festival.Title,
                         Description = festival.Description,
                         Date = festival.Date,
                         BannerImageUrl = festival.BannerImageUrl,
                         Genre = festival.Genre,
                         Age = festival.Age,
                         NumberOfDays = festival.NumberOfDays,
                         Location = festival.Location,
                         Price = festival.Price,
                         Capacity = festival.Capacity,
                         ShowId = festival.ShowId,
                         FestivalCategoryId = festival.FestivalCategoryId
                     }).ToList();

        return query;
    }

    public static FestivalToAddDto ConvertToDto(this Festival festival)
    {
        return new FestivalToAddDto
        {
            FestivalId = festival.FestivalId,
            Title = festival.Title,
            Description = festival.Description,
            Date = festival.Date,
            BannerImageUrl = festival.BannerImageUrl,
            Genre = festival.Genre,
            Age = festival.Age,
            NumberOfDays = festival.NumberOfDays,
            Location = festival.Location,
            Price = festival.Price,
            Capacity = festival.Capacity,
            ShowId = festival.ShowId,
            FestivalCategoryId = festival.FestivalCategoryId
        };
    }

    public static IEnumerable<FestivalDto> ConvertDto(this IEnumerable<Festival> festivals)
    {
        return (from festival in festivals
                select new FestivalDto
                {
                    FestivalId = festival.FestivalId,
                    Title = festival.Title,
                    Description = festival.Description,
                    Date = festival.Date,
                    BannerImageUrl = festival.BannerImageUrl,
                    Genre = festival.Genre,
                    Age = festival.Age,
                    NumberOfDays = festival.NumberOfDays,
                    Location = festival.Location,
                    Price = festival.Price,
                    Capacity = festival.Capacity,
                    ShowId = festival.ShowId,
                    FestivalCategoryId = festival.FestivalCategoryId
                }).ToList();
    }

    public static IEnumerable<FestivalCategoryDto> ConvertToDto(this IEnumerable<FestivalCategory> festivalCategories)
    {
        var query = (from festival in festivalCategories
                     select new FestivalCategoryDto
                     {
                         FestivalCategoryId = festival.FestivalCategoryId,
                         Name = festival.Name
                     }).ToList();

        return query;
    }





}

