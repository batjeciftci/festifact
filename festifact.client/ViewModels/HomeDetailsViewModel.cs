using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using festifact.models.Dtos.Festival;

namespace festifact.client.ViewModels;

[QueryProperty(nameof(FestivalDto), "festival")]
public class HomeDetailsViewModel : INotifyPropertyChanged
{

    private FestivalDto _festivalDto;

    public FestivalDto FestivalDto
    {
        get => _festivalDto;
        set
        {
            if (_festivalDto != value)
            {
                _festivalDto = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;


    public HomeDetailsViewModel()
    {

    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}
