using Nest;

namespace SimpleSearch.Api.Core.Search.Filters
{
    public class CustomerNameFilter : IFilter
    {
        private readonly string _customerName;
        
        public CustomerNameFilter(string customerName)
        {
            _customerName = customerName;
        }
        
        public void Apply(ISearchRequest searchRequest)
        {
            searchRequest.Query &= new QueryContainer(new MatchQuery
            {
                Field = "customer_full_name",
                Query = _customerName,
                Name = "CustomerNameFilter"
            });
        }
    }
}