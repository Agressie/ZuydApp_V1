using ZuydApp_V1.API;

namespace ZuydApp_V1.MVVM.Views;

public partial class TestPageNoah : ContentPage
{
	private int daycounter = 0;
    private List<Weather> forecast = Weather.GetForecast();
    public TestPageNoah()
	{
		InitializeComponent();
        SetParams();
    }
	private void OnNextDayClicked(object sender, EventArgs e)
	{
		if (daycounter <= 13)
		{
            daycounter++;
            SetParams();
        }
    }
    private void OnPrevDayClicked(object sender, EventArgs e)
    {
        if (daycounter >= 1)
        {
            daycounter--;
            SetParams();
        }
    }
    private void SetParams()
    {
        lblDate.Text = forecast[daycounter].Weatherdatetime.ToString();
        lbldesc.Text = forecast[daycounter].Weatherdesc.ToString();
        lblmaxtemp.Text = forecast[daycounter].WeatherMaxtemp.ToString();
        lblmintemp.Text = forecast[daycounter].WeatherMintemp.ToString();
    }
}