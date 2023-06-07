using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using festifact.client.Services;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Festival;

namespace festifact.client.ViewModels;

public class MusicFestivalViewModel : INotifyPropertyChanged
{
    private readonly IFestivalService _festivalService;
    private string _title;
    private DateTime _date;
    private readonly string _bannerImageUrl;
    private string _location;
    private int _price;
    private bool _isRefreshing;
    private ObservableCollection<FestivalDto> _festivals;

    public string Title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    public DateTime Date
    {
        get => _date;
        set { _date = value; OnPropertyChanged(); }
    }

    //public string BannerImageUrl => _bannerImageUrl;

    public string Location
    {
        get => _location;
        set { _location = value; OnPropertyChanged(); }
    }

    public int Price
    {
        get => _price;
        set { _price = value; OnPropertyChanged(); }
    }

    public bool IsRefReshing
    {
        get => _isRefreshing;
        set
        {
            if (_isRefreshing != value)
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
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

    public ICommand RefreshCommand { get; set; }

    public MusicFestivalViewModel(IFestivalService festivalService)
	{
        this._festivalService = festivalService;

        this._festivals = new();

        RefreshCommand = new Command(async () => await RunRefreshCommand());
    }

    private async Task RunRefreshCommand()
    {
        try
        {
            IsRefReshing = true;

            await GetFestivalsByCategory(1);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Refresh error: {ex.Message}");
        }
        finally
        {
            IsRefReshing = false;
        }
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
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}


