using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.API;


namespace ZuydApp_V1.MVVM.Views;

public partial class MyEventDetailsPage : ContentPage
{
    private bool enteredevent = false;
    public MyEventDetailsPage()
    {
        InitializeComponent();
        Event @event = VM_Event.CurrentEvent;
        List<Weather> forecast = Weather.GetForecast();
        DisplayLayoutEvent.BindingContext = @event;
        DisplayLayoutWeather.BindingContext = forecast[0];
        checkentered(@event);
        

    }

    private void checkentered(Event @event)
    {
        if (@event.Users != null)
        {
            foreach (User user in @event.Users)
            {
                if (user.Id == VM_User.CurrentUser.Id)
                {
                    enteredevent = true;
                    btnInUitschrijven.Text = "Uitschrijven";
                }
            }
        }
    }

    public void OnActiviteitenClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MyUndertakingPage());
    }

    public void OnInUitschrijvenClicked(object sender, EventArgs e)
    {
        VM_Event.RemoveUser(VM_User.CurrentUser);
        btnInUitschrijven.Text = "Inschrijven";
        enteredevent = false;
        Navigation.PopAsync();
    }

   
}