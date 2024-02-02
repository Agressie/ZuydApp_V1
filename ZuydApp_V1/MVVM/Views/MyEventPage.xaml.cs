using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.Views;

public partial class MyEventPage : ContentPage
{
    public List<Event> events = VM_User.CurrentUser.Events;
    public MyEventPage()
    {
        InitializeComponent();
        lstvwEvents.ItemsSource = events;
    }

    private async void TappedViewCell(object sender, EventArgs e)
    {
        var viewcell = sender as ViewCell;
        var @event = viewcell.BindingContext as Event;
        VM_Event.SetCurrentEvent(@event);
        Navigation.PushAsync(new MyEventDetailsPage());
    }
}