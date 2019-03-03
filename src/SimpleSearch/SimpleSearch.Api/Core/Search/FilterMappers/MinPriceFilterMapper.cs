using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.FilterMappers
{
    public class MinPriceFilterMapper : IPropertyFilterMapper<double>
    {
        private readonly double _price;

        public MinPriceFilterMapper(double price)
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