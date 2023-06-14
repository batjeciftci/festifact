using festifact.client.ViewModels;
using festifact.models.Dtos.Visitor;

namespace festifact.client.Pages;

public partial class AddVisitorPage : ContentPage
{
    private readonly ContactViewModel _contactViewModel;

    public AddVisitorPage(ContactViewModel contactViewModel)
    {
        InitializeComponent();

        this._contactViewModel = contactViewModel;

        this.BindingContext = contactViewModel;
    }

    private async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var fName = firstname.Text;
        var city = residence.Text;
        var mail = email.Text;

        if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(mail))
        {
            await Shell.Current.DisplayAlert("Error message", "Please fill in all required fields.", "OK");

            return;
        }

        var visitor = new VisitorToAddDto()
        {
            Firstname = firstname.Text,
            Lastname = "avans",
            DateOfBirth = new DateTime(2023, 10, 10),
            Sex = "male",
            Residence = residence.Text,
            Email = email.Text
        };

        await _contactViewModel.AddVisitor(visitor);

        await Shell.Current.DisplayAlert("Message", $"Successfully added: {visitor.Firstname.ToUpper()}", "OK");
    }
}
