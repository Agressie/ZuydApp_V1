using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.Views;

public partial class ActivityPage : ContentPage
{
	public ActivityPage()
	{
		InitializeComponent();
		lstvwUndertaking.ItemsSource = VM_Event.CurrentEvent.Undertakings;
	}

    private void btnVoegActiviteit_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new CreateUndertakingPage());
    }

    private async void TappedViewCell(object sender, EventArgs e)
    {
        var viewcell = sender as ViewCell;
        var undertaking = viewcell.BindingContext as Undertaking;
        VM_Undertaking.SetCurrentUndertaking(undertaking);
        Navigation.PushAsync(new UndertakingDetailsPage());
    }
}