using Microsoft.Extensions.Logging;
using ZuydApp_V1.API;
using ZuydApp_V1.Data;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            Weather.URLWeather();
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BaseRepo<User>>();
            builder.Services.AddSingleton<BaseRepo<Undertaking>>();
            builder.Services.AddSingleton<BaseRepo<Event>>();
            builder.Services.AddSingleton<BaseRepo<Room>>();
#if DEBUG
            builder.Logging.AddDebug();
#endif      
            return builder.Build();
        } 
    }
}
