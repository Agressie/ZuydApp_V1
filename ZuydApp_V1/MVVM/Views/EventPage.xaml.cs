using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.Views;

public partial class EventPage : ContentPage
{
	public List<Event> events = VM_Event.GetEvent();
    public EventPage()
	{
		InitializeComponent();
        lstvwEvents.ItemsSource = events;
	}

    private void btnVoegEvenement_Clicked(object sender, EventArgs e)
    {
		VM_Event.CreateNewEvent("EventTest2", "Beschrijvingtest", DateTime.Now, "Heerlen");
        events = VM_Event.GetEvent();
        lstvwEvents.ItemsSource = events;

    }

    private async void TappedViewCell(object sender, EventArgs e)
	{
		var viewcell = sender as ViewCell;
		var @event = viewcell.BindingContext as Event;
		VM_Event.SetCurrentEvent(@event);
        Navigation.PushAsync(new EventDetailsPage());
    }
}