using System.Collections.Generic;
using SimpleSearch.Api.Models.Request;
using SimpleSearch.Api.Models.Response;

namespace SimpleSearch.Api.Services
{
    public interface IOrderSearchService
    {
        IEnumerable<OrderSearchResponse> Search(OrderSearchRequest request);
    }
}