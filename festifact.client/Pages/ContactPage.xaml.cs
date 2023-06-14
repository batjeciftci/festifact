using System.Collections.ObjectModel;
using festifact.client.Services.Contracts;
using festifact.client.ViewModels;
using festifact.models.Dtos.Visitor;

namespace festifact.client.Pages;

public partial class ContactPage : ContentPage
{
    private readonly ContactViewModel _contactViewModel;
    private IList<VisitorDto> _visitors;

    // CONSTRUCTOR
    public ContactPage(ContactViewModel contactViewModel)
    {
        InitializeComponent();

        this._contactViewModel = contactViewModel;

        this.BindingContext = contactViewModel;

        _visitors = new ObservableCollection<VisitorDto>();
    }


    void SearchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<VisitorDto>(_contactViewModel.SearchVisitors(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    async void listContacts_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            this._contactViewModel.VisitorId = ((VisitorDto)listContacts.SelectedItem).VisitorId;

            await Shell.Current.GoToAsync($"{nameof(EditVisitorPage)}?Id={this._contactViewModel.VisitorId}");
        }
    }

    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddVisitorPage));
    }

    // this event handler method is for deleting contact!
    void MenuItem_Clicked(System.Object sender, System.EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var visitor = menuItem.CommandParameter as VisitorDto;
        Task.Run(async () => await _contactViewModel.DeleteVisitor(visitor.VisitorId));

        LoadVisitors();
    }

    private void LoadVisitors()
    {
        _visitors = _contactViewModel.Visitors;
        listContacts.ItemsSource = _visitors;
    }
}
