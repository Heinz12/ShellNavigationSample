using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using ShellNavigationSample.Services.Navigation;
using ShellNavigationSample.ViewModels;
using ShellNavigationSample.Views;
using System.Net;

namespace ShellNavigationSample
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<PageAViewModel>();
            builder.Services.AddTransient<PageBViewModel>();

            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            // Manually register all Views.
            builder.Services.AddTransient<PageAView>();
            builder.Services.AddTransient<PageBView>();

            return builder;
        }
    }
}
