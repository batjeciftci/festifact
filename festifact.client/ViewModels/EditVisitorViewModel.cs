using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using festifact.client.Pages;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Visitor;

namespace festifact.client.ViewModels;

public class EditVisitorViewModel : INotifyPropertyChanged
{
    private readonly IVisitorService _visitorService;
    private string _firstName;
    private string _lastName;
    private string _residence;
    private string _email;


    public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged(); } }
    public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged(); } }
    public string Residence { get => _residence; set { _residence = value; OnPropertyChanged(); } }
    public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

    public event PropertyChangedEventHandler PropertyChanged;

    // CONSTRUCTOR
    public EditVisitorViewModel(IVisitorService visitorService)
	{
        this._visitorService = visitorService;
    }

    public async Task<VisitorDto> GetVisitor(int id)
    {
        var visitor = await _visitorService.GetVisitor(id);
        return visitor;
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}

