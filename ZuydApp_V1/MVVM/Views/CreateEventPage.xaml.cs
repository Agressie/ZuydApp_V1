using ZuydApp_V1.MVVM.ViewModels;

namespace ZuydApp_V1.MVVM.Views;

public partial class CreateEventPage : ContentPage
{
	public CreateEventPage()
	{
		InitializeComponent();
	}

	// Because i could make it work that i have a date and a time to a datetime. i chose to just pick .Now to get on with the code. The rest is functional.
    private void OnCreateEventClicked(object sender, EventArgs e)
    {
        var titleempty = string.IsNullOrEmpty(Entrytitle.Text);
		var locationempty = string.IsNullOrEmpty(EntryLocation.Text);
		var descriptionempty = string.IsNullOrEmpty(EditorDescription.Text);
        DateTime dateTime = DateTime.Now;
		if (titleempty == false && locationempty == false && descriptionempty == false)
			if (EditorDescription.Text.Count() < 250)
				VM_Event.CreateNewEvent(Entrytitle.Text, EntryLocation.Text, dateTime, EditorDescription.Text);
				Navigation.PopAsync();

    }
}