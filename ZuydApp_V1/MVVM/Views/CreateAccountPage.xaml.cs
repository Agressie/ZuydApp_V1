using Plugin.LocalNotification;

namespace ZuydApp_V1.MVVM.Views;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage()
	{
		InitializeComponent();
	}
    public void Onaccountcreateclicked(object sender, EventArgs e)
    {
        var UsernameEmpty = string.IsNullOrEmpty(EntryUsername.Text);
        var PasswordEmpty = string.IsNullOrEmpty(EntryPassword.Text);
        var ConfirmPasswordEmpty = string.IsNullOrEmpty(EntryConfirmPassword.Text);

        if (UsernameEmpty)
            EntryUsername.Placeholder = "Vul iets in!";
        else if (PasswordEmpty)
            EntryPassword.Placeholder = "Vul iets in!";
        else if (ConfirmPasswordEmpty)
            EntryConfirmPassword.Placeholder = "Vul iets in!";
        else
        {   // This Code should work fine only the VM_User is not created yet.
            //if (VM_User.Checkusername(EntryUsername.Text) == false)
            //{
            //    if (EntryPassword.Text == EntryConfirmPassword.Text)
            //    {
            //        VM_User.CreateNewUser(EntryUsername.Text, EntryPassword.Text);
            //        if (VM_User.LoginCheck(EntryUsername.Text, EntryPassword.Text) == true)
            //        {
            //            // This function still needs to be added.
            //            Accountnotification(EntryUsername.Text);
            //            // THis Page still needs to be added
            //            Navigation.PushAsync(new HomePage());
            //        }
            //    }
            //    else
            //        Invalid.Text = "Passwords don't match";
            //}
            //else
            //    Invalid.Text = "Username already exists";
        }
    }

    public void Accountnotification(string username)
    {
        var rq = new NotificationRequest
        {
            NotificationId = 1000,
            Title = "Welcome to Zuyd Wayfinder",
            Subtitle = "Account created with Zuyd Wayfinder",
            Description = $"Thank you {username} for creating an account with us.",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(30),
                NotifyRepeatInterval = TimeSpan.FromSeconds(30),
            }
        };
        LocalNotificationCenter.Current.Show(rq);
    }
}