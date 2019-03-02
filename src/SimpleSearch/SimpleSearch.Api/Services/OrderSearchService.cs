using System.Collections.Generic;
using System.Linq;
using Nest;
using SimpleSearch.Api.Constants;
using SimpleSearch.Api.Core.Search.Builders;
using SimpleSearch.Api.Core.Search.FilterMappers;
using SimpleSearch.Api.Infrastructure.Exception;
using SimpleSearch.Api.Models;
using SimpleSearch.Api.Models.Request;
using SimpleSearch.Api.Models.Response;

namespace SimpleSearch.Api.Services
{
    public class OrderSearchService : IOrderSearchService
    {
        private readonly IElasticClient _elasticClient;

        public OrderSearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        
        public IEnumerable<OrderSearchResponse> Search(OrderSearchRequest request)
        {
            var filters = new FilterBuilder()
                .Add(new CustomerNameFilterMapper(request.CustomerName))
                .Add(new PriceFilterMapper(request.Price))
                .ToFilterList();

            var searchRequest = new SearchRequest
            {
                From = 0,
                Size = 10
            };

            foreach (var filter in filters)
            {
                filter.Apply(searchRequest);
            }

            var result = _elasticClient.Search<Order>(searchRequest);

            if (result.IsValid)
            {
                return result.Hits.Select(a => new OrderSearchResponse
                {
                    CustomerFullName = a.Source.CustomerFullName,
                    TaxfulTotalPrice = a.Source.TaxfulTotalPrice,
                    Id = a.Source.Id,
                    CustomerGender = a.Source.CustomerGender
                });
            }

            throw new DomainException(ErrorCodes.ErrorOccuredWhileGettingSearchResult);
        }
    }
}