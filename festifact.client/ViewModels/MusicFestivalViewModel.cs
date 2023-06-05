using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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
    private Boolean _isRefreshing;
    private ObservableCollection<FestivalDto> _festivals;

    public string Title
    {
        get => _title;
        set { _title = value; OnpropertyChanged(); }
    }

    public DateTime Date
    {
        get => _date;
        set { _date = value; OnpropertyChanged(); }
    }

    public string BannerImageUrl => _bannerImageUrl;

    public string Location
    {
        get => _location;
        set { _location = value; OnpropertyChanged(); }
    }

    public int Price
    {
        get => _price;
        set { _price = value; OnpropertyChanged(); }
    }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set { _isRefreshing = value; OnpropertyChanged(); }
    }

    public ObservableCollection<FestivalDto> Festivals
    {
        get => _festivals;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand RefreshCommand { get; }



    public MusicFestivalViewModel(IFestivalService festivalService)
	{
        this._festivalService = festivalService;
        this._festivals = new();
        RefreshCommand = new Command(RunRefreshCommand);
    }

    private async Task GetFestivalsByCategory(int categoryId)
    {
        var festivals = await _festivalService.GetFestivalsByCategory(categoryId);

        foreach (var festival in festivals)
        {
            _festivals.Add(festival);
        }
    }

    private async void RunRefreshCommand()
    {
        await GetFestivalsByCategory(1);
        _isRefreshing = false;
    }

    private void OnpropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}

