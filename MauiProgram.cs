using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PizzaMAUI.page;
using PizzaMAUI.Service;
using PizzaMAUI.ViewModel;

namespace PizzaMAUI
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
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            AddPizzaServices(builder.Services);

            return builder.Build();
        }

        private static IServiceCollection AddPizzaServices(IServiceCollection services)
        {
            services.AddSingleton<PizzaService>();
            services.AddSingleton<HomePage>()
                .AddSingleton<HomeViewModel>();
            services.AddTransientWithShellRoute<AllPizzaPage, AllPizzaViewModel>(nameof(AllPizzaPage));
            services.AddTransientWithShellRoute<DetailePage, DetailsViewModel>(nameof(DetailePage));
            services.AddTransientWithShellRoute<CartPage, CartViewModel>(nameof(CartPage));
            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();
            return services;
        }
    }
}
