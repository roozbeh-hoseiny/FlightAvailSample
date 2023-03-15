using FlightAvail.Service;
using FlightAvail.Service.Abstraction;
using FlightAvail.Service.DependencyInjection;
using FlightAvailService.Samples.Shared.HttpClientHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FlightAvailService.Samples.Shared
{
    internal static class ServicesCollectionExtension
    {
        public static IServiceCollection RegisterSampleService(this IServiceCollection services) 
        {
            #region " Logging "
            services.AddLogging(logging =>
            {
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Debug);
            });
            #endregion

            #region " Registering all required FlightAvailService Services "
            services.AddFlightAvailService(opts =>
                {
                    opts.Supplier1CustomerId = "supplier1-customerId";
                    opts.Supplier2SiteName = "SampleSiteName";
                    opts.Supplier2FlightType = "charter";
                    opts.Supplier2Id = "id";
                });
            #endregion

            #region " HttpClient Handlers And DelegatingHandlers "
            services
                   .AddTransient<DefaultClientHandler>()
                   .AddTransient<LoggingDelegatingHandler>()
                   .AddTransient<Supplier1SampleResponseDelegatingHandler>()
                   .AddTransient<Supplier2SampleResponseDelegatingHandler>();
            #endregion

            #region " Configuring HttpClient of supplier1 "
            services.AddHttpClient(SuppliersEnum.Supplier1.ToString(), client =>
            {
                client.BaseAddress = new Uri("https://supplier1.com");
            }).ConfigureHttpMessageHandlerBuilder(builder =>
            {
                builder.AdditionalHandlers.Add(builder.Services.GetService<LoggingDelegatingHandler>()!);
                builder.AdditionalHandlers.Add(builder.Services.GetService<Supplier1SampleResponseDelegatingHandler>()!);
                builder.PrimaryHandler = builder.Services.GetService<DefaultClientHandler>()!;
            });
            #endregion
            
            #region " Configuring HttpClient of supplier2 "
            services.AddHttpClient(SuppliersEnum.Supplier2.ToString(), client =>
            {
                client.BaseAddress = new Uri("https://supplier2.com");
            }).ConfigureHttpMessageHandlerBuilder(builder =>
            {
                builder.AdditionalHandlers.Add(builder.Services.GetService<LoggingDelegatingHandler>()!);
                builder.AdditionalHandlers.Add(builder.Services.GetService<Supplier2SampleResponseDelegatingHandler>()!);
                builder.PrimaryHandler = builder.Services.GetService<DefaultClientHandler>()!;
            }); 
            #endregion

            return services;
        }
        public static IServiceCollection RegisterSampleService<TFactory>(this IServiceCollection services) where TFactory : IFlightSupplierFactory
        {
            RegisterSampleService(services);

            services.AddScoped(typeof(IFlightSupplierFactory), typeof(TFactory));

            return services;
        }
    }
}
