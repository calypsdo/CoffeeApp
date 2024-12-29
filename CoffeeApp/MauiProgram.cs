using CoffeeApp.Application.Services.Interfaces;
using CoffeeApp.Infrastructure.Common.Constants;
using CoffeeApp.Infrastructure.Common.Policies;
using CoffeeApp.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CoffeeApp.Presentation.ViewModels;
using CoffeeApp.Presentation.Views;
using CoffeeApp.Application.UseCases;
using System.Text.Json;

namespace CoffeeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //Register Pages
            builder.Services.AddSingleton<CoffeePage>();
            builder.Services.AddTransient<CoffeeDetailsPage>();

            //Register ViewModels
            builder.Services.AddSingleton<CoffeePageViewModel>();
            builder.Services.AddTransient<CoffeeDetailsPageViewModel>();

            //Register Application UseCases
            builder.Services.AddScoped<GetCoffee>();

            //Register Infrastructure Services
            builder.Services.AddSingleton(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            builder.Services.AddHttpClient<DefaultHttpService>(client =>
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("User-Agent", "CoffeeApp");
                client.BaseAddress = new Uri(ApiConstants.BaseUrl);
            })
            .AddPolicyHandler(HttpClientPolicies.GetRetryPolicy())
            .AddPolicyHandler(HttpClientPolicies.GetCircuitBreakerPolicy());

            builder.Services.AddScoped<ICoffeeService, CoffeeService>();

            return builder.Build();
        }
    }
}
