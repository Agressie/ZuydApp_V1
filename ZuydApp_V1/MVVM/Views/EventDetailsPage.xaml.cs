using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.Views;

public partial class EventDetailsPage : ContentPage
{
	private bool enteredevent = false;
	public EventDetailsPage()
	{
		InitializeComponent();
		Event @event = VM_Event.CurrentEvent;
        DisplayLayout.BindingContext = @event;
		lbltest.Text = VM_User.CurrentUser.Name;
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

	}

	public void OnInUitschrijvenClicked(object sender, EventArgs e)
	{
		if (enteredevent == true)
		{

			VM_Event.RemoveUser(VM_User.CurrentUser);
			btnInUitschrijven.Text = "Inschrijven";
			enteredevent = false;
		}
		else if (enteredevent == false)
		{
			VM_Event.AddUser(VM_User.CurrentUser);
			btnInUitschrijven.Text = "Uitschrijven";
			enteredevent = true;
		}
	}
}