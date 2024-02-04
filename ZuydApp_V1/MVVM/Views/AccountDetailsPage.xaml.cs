using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.Views;

public partial class AccountDetailsPage : ContentPage
{
	private User user = VM_User.CurrentUser;
	public AccountDetailsPage()
	{
		InitializeComponent();
		Stacklayout.BindingContext = user;
		lstvwEvets.ItemsSource = UpcomingEvents(user.Events);
    }

	private List<Event> UpcomingEvents(List<Event> events)
	{
		List<Event> Upcomingevents = new List<Event>();
		if (events != null) 
		{
            foreach (Event @event in events)
            {
                if (@event.DateTime >= DateTime.Today)
                {
                    Upcomingevents.Add(@event);
                }
            }
        }
		return Upcomingevents;
	}
}