using Microsoft.Extensions.DependencyInjection;
using SimpleSearch.Api.Services;

namespace SimpleSearch.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModules(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IOrderSearchService), typeof(OrderSearchService));
        }
    }
}