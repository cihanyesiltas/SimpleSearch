using Nest;

namespace SimpleSearch.Api.Core.Search.Filters
{
    public class PriceFilter : IFilter
    {
        private readonly double _price;

        public PriceFilter(double price)
        {
            this._price = price;
        }

        public void Apply(ISearchRequest searchRequest)
        {
            searchRequest.Query &= new QueryContainer(new NumericRangeQuery
            {
                Field = "taxful_total_price",
                GreaterThan = _price,
                Name = "PriceFilter"
            });
        }
    }
}