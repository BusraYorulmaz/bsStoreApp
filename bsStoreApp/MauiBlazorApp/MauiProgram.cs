using MauiBlazorApp.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MauiBlazorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddSingleton<BookService>();
            builder.Services.AddHttpClient<IBookService, BookService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7219/");
            });
    

            return builder.Build();
        }
    }
}