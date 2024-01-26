
namespace ZuydApp_V1.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
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
            // This code will work when the VM_User is created and this data can be gotten.
            //if (VM_User.LoginCheck(EntryUsername.Text, EntryPassword.Text) == true)
            //    // This Page still has to be made
            //    Navigation.PushAsync(new HomePage());
            //else
            //    Invalid.IsVisible = true;
            //
        }
    }
    private void OnCreateaccountClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateAccountPage());
    }
}