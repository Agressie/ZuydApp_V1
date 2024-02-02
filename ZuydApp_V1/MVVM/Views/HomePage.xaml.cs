namespace ZuydApp_V1.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private void btnEvenementen_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventPage());
    }

    private void btnMyEvenementen_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MyEventPage());
    }

    private void LogoutClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}