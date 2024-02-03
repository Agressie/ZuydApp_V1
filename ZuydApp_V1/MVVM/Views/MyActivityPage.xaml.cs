using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.MVVM.ViewModels;

namespace ZuydApp_V1.MVVM.Views;

public partial class MyActivityPage : ContentPage
{
	private List<Undertaking> undertakings = VM_Undertaking.GetUndertaking();
	public MyActivityPage()
	{
		InitializeComponent();
        lstvwUndertaking.ItemsSource = undertakings;

    }

    private async void TappedViewCell(object sender, EventArgs e)
    {
        var viewcell = sender as ViewCell;
        var undertaking = viewcell.BindingContext as Undertaking;
        VM_Undertaking.SetCurrentUndertaking(undertaking);
        Navigation.PushAsync(new UndertakingDetailsPage());
    }

    public void VoegActiviteitClicked(object sender, EventArgs e)
	{

	}
}