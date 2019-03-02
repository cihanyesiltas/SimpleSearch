using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using SimpleSearch.Api.Models;

namespace SimpleSearch.Api.Extensions
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<Order>(m => m
                    .PropertyName(o => o.Id, "_id")
                    .PropertyName(o => o.CustomerFullName, "customer_full_name")
                    .PropertyName(o => o.TaxfulTotalPrice, "taxful_total_price")
                    .PropertyName(o=>o.CustomerGender, "customer_gender")
                );

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}