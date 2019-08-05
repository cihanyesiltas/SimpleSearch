using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.FilterMappers
{
    public class MinPriceFilterHandler : IPropertyFilterHandler<double>
    {
        private readonly double _price;

        public MinPriceFilterHandler(double price)
        {
            _price = price;
        }
        
        public IFilter GetFilter()
        {
            if (_price > 0)
            {
                return new MinPriceFilter(_price);
            }

            return null;
        }
    }
}