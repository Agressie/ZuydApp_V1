using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.MVVM.ViewModels;

namespace ZuydApp_V1.MVVM.Views;

public partial class UndertakingDetailsPage : ContentPage
{
    private bool enteredundertaking = false;
	public UndertakingDetailsPage()
	{
		InitializeComponent();
		Undertaking undertaking = VM_Undertaking.CurrentUndertaking;
        DisplayLayoutUndertaking.BindingContext = undertaking;
        checkentered(undertaking);

    }
    private void checkentered(Undertaking undertaking)
    {
        if (undertaking.Users != null)
        {
            foreach (User user in undertaking.Users)
            {
                if (user.Id == VM_User.CurrentUser.Id)
                {
                    enteredundertaking = true;
                    btnInUitschrijven.Text = "Uitschrijven";
                }
            }
        }
    }

    public void OnInUitschrijvenClicked(object sender, EventArgs e)
	{
        if (enteredundertaking == true)
        {

            VM_Undertaking.RemoveUser(VM_User.CurrentUser);
            btnInUitschrijven.Text = "Inschrijven";
            enteredundertaking = false;
            Navigation.PopAsync();
        }
        else if (enteredundertaking == false)
        {
            VM_Undertaking.AddUser(VM_User.CurrentUser);
            btnInUitschrijven.Text = "Uitschrijven";
            enteredundertaking = true;
            Navigation.PopAsync();
        }
    }
}