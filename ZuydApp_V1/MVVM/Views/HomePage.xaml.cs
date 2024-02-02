namespace ZuydApp_V1.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    

    

    private void btnActiviteiten_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ActivityPage());
    }

    private void btnEvenementen_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EventPage());
    }

    

    private void btnParkeerterrein_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ParkingPage());
    }

    private void btnLokalen_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RoomPage());
    }

    private void LogoutClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}