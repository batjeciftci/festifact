using System.Collections.ObjectModel;
using festifact.client.Services.Contracts;
using festifact.client.ViewModels;
using festifact.models.Dtos.Visitor;

namespace festifact.client.Pages;

public partial class ContactPage : ContentPage
{
    private readonly ContactViewModel _contactViewModel;

    // CONSTRUCTOR
    public ContactPage(ContactViewModel contactViewModel)
    {
        InitializeComponent();

        this._contactViewModel = contactViewModel;
        this.BindingContext = contactViewModel;
    }

    void listContacts_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            // logic
            //await Shell.Current.GoToAsync(nameof(EditContactPage));
        }
    }


    void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {

    }

    // this event handler method is for deleting contact!
    void MenuItem_Clicked(System.Object sender, System.EventArgs e)
    {

    }

    void SearchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<VisitorDto>(_contactViewModel.SearchVisitors(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}

