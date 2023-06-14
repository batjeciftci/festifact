using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Festival;

namespace festifact.client.ViewModels;

public class FilmFestivalViewModel : INotifyPropertyChanged
{

    private readonly IFestivalService _festivalService;
    private string _title;
    private DateTime _date;
    private string _bannerImageUrl;
    private string _location;
    private int _price;
    private ObservableCollection<FestivalDto> _festivals;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged();
        }
    }

    public string BannerImageUrl
    {
        get => _bannerImageUrl;
        set
        {
            _bannerImageUrl = value;
            OnPropertyChanged();
        }
    }

    public string Location
    {
        get => _location;
        set
        {
            _location = value;
            OnPropertyChanged();
        }
    }

    public int Price
    {
        get => _price;
        set
        {
            _price = value;
        }
    }

    public ObservableCollection<FestivalDto> Festivals
    {
        get => _festivals;
        set
        {
            _festivals = value;
            OnPropertyChanged();
        }
    }

    public FilmFestivalViewModel(IFestivalService festivalService)
    {
        this._festivalService = festivalService;
        this._festivals = new();
    }


    public async Task GetFestivalsByCategory(int categoryId)
    {
        try
        {
            var festivals = await _festivalService.GetFestivalsByCategory(categoryId);

            Festivals.Clear();

            foreach (var festival in festivals)
            {
                Festivals.Add(festival);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Festivals could not be retrieved, {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (PropertyChanged is not null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }
    }
}

