using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using festifact.client.Services.Contracts;
using festifact.models.Dtos.Visitor;

namespace festifact.client.ViewModels;

public class ContactViewModel : INotifyPropertyChanged
{
    private readonly IVisitorService _visitorService;
    private string _firstName;
    private string _lastName;
    private DateTime _dateOfBirth;
    private string _sex;
    private string _residence;
    private string _email;
    private string _pageTitle;
    private int _visitorId;

    private ObservableCollection<VisitorDto> _visitors;


    public string Firstname
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }

    public string Lastname
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            OnPropertyChanged();
        }
    }

    public string Sex
    {
        get => _sex;
        set
        {
            _sex = value;
            OnPropertyChanged();
        }
    }

    public string Residence
    {
        get => _residence;
        set
        {
            _residence = value;
            OnPropertyChanged();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

    public string PageTitle
    {
        get => _pageTitle;
        set
        {
            _pageTitle = value;
            OnPropertyChanged();
        }
    }

    public int VisitorId
    {
        get => _visitorId;
        set
        {
            _visitorId = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<VisitorDto> Visitors
    {
        get => _visitors;
        set
        {
            _visitors = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Constructor
    public ContactViewModel(IVisitorService visitorService)
    {
        this._visitorService = visitorService;

        _visitors = new ObservableCollection<VisitorDto>();

        PageTitle = "Contacts";

        Task.Run(async () => await GetVisitors());
    }

    public async Task GetVisitors()
    {
        try
        {
            var visitors = await _visitorService.GetVisitors();

            foreach (var visitor in visitors)
            {
                _visitors.Add(visitor);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<VisitorDto> GetVisitor(int id)
    {
        var visitor = await _visitorService.GetVisitor(id);
        return visitor;
    }

    public async Task AddVisitor(VisitorToAddDto visitorToAddDto)
    {
        var visitor = await _visitorService.AddVisitor(visitorToAddDto);
    }

    public async Task UpdateVisitor(VisitorUpdateDto visitorUpdateDto)
    {
        var visitor = await _visitorService.UpdateVisitor(visitorUpdateDto);
    }

    public async Task DeleteVisitor(int id)
    {
        var visitorToDelete = await _visitorService.DeleteVisitor(id);
    }

    public List<VisitorDto> SearchVisitors(string filterText)
    {
        var filteredVisitors = (from v in _visitors
                                where (!string.IsNullOrWhiteSpace(v.Firstname) && v.Firstname.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)) ||
                                      (!string.IsNullOrWhiteSpace(v.Email) && v.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)) ||
                                      (!string.IsNullOrWhiteSpace(v.Lastname) && v.Lastname.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)) ||
                                      (!string.IsNullOrWhiteSpace(v.Residence) && v.Residence.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))
                                select v).ToList();

        return filteredVisitors;
    }


    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
    }
}

