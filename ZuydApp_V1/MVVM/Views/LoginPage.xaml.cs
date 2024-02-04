using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.API;
namespace ZuydApp_V1.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
        // I can't put this in the Mauiprogram, because it usesses the VM;s
        Dijkstra.FirstcreateRooms();
        InitializeComponent();
    }
    private void Onloginclicked(object sender, EventArgs e)
    {
        var UsernameEmpty = string.IsNullOrEmpty(EntryUsername.Text);
        var PasswordEmpty = string.IsNullOrEmpty(EntryPassword.Text);

        if (UsernameEmpty)
            EntryUsername.Placeholder = "Vul iets in!";
        else if (PasswordEmpty)
            EntryPassword.Placeholder = "Vul iets in!";
        else
        {
            if (VM_User.LoginCheckandUsernameCheck(false, EntryUsername.Text, EntryPassword.Text) == true)
            {
                Navigation.PushAsync(new HomePage());
                Invalid.IsVisible = false;
                EntryUsername.Text = "";
                EntryPassword.Text = "";
            }
            else
                Invalid.IsVisible = true;
            
        }
    }
    private void OnCreateaccountClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateAccountPage());
    }
}