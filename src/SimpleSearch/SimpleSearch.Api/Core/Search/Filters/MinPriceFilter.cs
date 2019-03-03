using Nest;

namespace SimpleSearch.Api.Core.Search.Filters
{
    public class MinPriceFilter : IFilter
    {
        private readonly double _price;

        public MinPriceFilter(double price)
        {
            this._price = price;
        }

        public void Apply(ISearchRequest searchRequest)
        {
            searchRequest.Query &= new QueryContainer(new NumericRangeQuery
            {
                Field = "taxful_total_price",
                GreaterThanOrEqualTo = _price,
                Name = "PriceFilter"
            });
        }
    }
}