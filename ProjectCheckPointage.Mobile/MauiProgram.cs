using Microsoft.Extensions.Logging;
using ProjectCheckPointage.Mobile.Services.Implementations;
using ProjectCheckPointage.Mobile.Services.Interfaces;
using ProjectCheckPointage.Mobile.ViewModels;
using ProjectCheckPointage.Mobile.Views;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;


namespace ProjectCheckPointage.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBarcodeReader() 
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<ConnexionViewModel>();
            // Pages
            builder.Services.AddSingleton<ConnexionPage>();

            builder.Services.AddSingleton<App>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
