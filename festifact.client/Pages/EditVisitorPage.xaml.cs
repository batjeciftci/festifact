using festifact.client.ViewModels;
using festifact.models.Dtos.Visitor;

namespace festifact.client.Pages;

public partial class EditVisitorPage : ContentPage
{
    private readonly ContactViewModel _contactViewModel;
    private int _visitorId;
    private VisitorDto _visitor;

    public EditVisitorPage(ContactViewModel contactViewModel)
    {
        InitializeComponent();

        this._contactViewModel = contactViewModel;

        this.BindingContext = contactViewModel;

        Task.Run(async () => await SetId());
    }

    private async Task SetId()
    {
        _visitorId = _contactViewModel.VisitorId;

        await InitializePage(_visitorId);
    }

    public async Task InitializePage(int id)
    {
        _visitor = await _contactViewModel.GetVisitor(id);

        firstName.Text = _visitor.Firstname;
        lastName.Text = _visitor.Lastname;
        email.Text = _visitor.Email;
        city.Text = _visitor.Residence;
    }

    //async void Button_Clicked(System.Object sender, System.EventArgs e)
    //{
    //    var visitor = _contactViewModel.UpdateVisitor(new VisitorUpdateDto()
    //    {
    //        VisitorId = _visitor.VisitorId,
    //        Firstname = _visitor.Firstname,
    //        Lastname = _visitor.Lastname,
    //        Residence = _visitor.Residence,
    //        Email = _visitor.Email,
    //    });

    //    await Shell.Current.GoToAsync(nameof(ContactPage));
    //}
}

