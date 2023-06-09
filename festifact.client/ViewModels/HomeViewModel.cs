using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using festifact.client.Pages;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Festival;
using Microsoft.Maui.Networking;

namespace festifact.client.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly IFestivalService _festivalService;
    private string _title;
    private DateTime _date;
    private string _bannerImageUrl;
    private string _location;
    private int _price;
    private ObservableCollection<FestivalDto> _festivals;

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

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand NavigateToHomeDetailsPageCommand { get; set; }


    // CONSTRUCTOR
    public HomeViewModel(IFestivalService festivalService)
	{
        this._festivalService = festivalService;

        this._festivals = new();

        NavigateToHomeDetailsPageCommand = new Command<FestivalDto>(async (festival) => await NavigateToHomeDetailsPage(festival));
    }

    public async Task GetFestivals()
    {
        try
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }
            else
            {
                var festivals = await _festivalService.GetFestivals();

                if (Festivals.Count != 0)
                    Festivals.Clear();

                foreach (var festival in festivals)
                {
                    Festivals.Add(festival);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Festivals could not be retrieved, {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    private async Task NavigateToHomeDetailsPage(FestivalDto festival)
    {

        var navParameter = new Dictionary<string, object>()
        {
            { "festival", festival }
        };

        await Shell.Current.GoToAsync(nameof(HomeDetailsPage), navParameter);
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}
