using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.FilterMappers
{
    public class PriceFilterMapper : IPropertyFilterMapper<double>
    {
        private readonly double _price;

        public PriceFilterMapper(double price)
        {
            _price = price;
        }
        
        public IFilter GetFilter()
        {
            if (_price > 0)
            {
                return new PriceFilter(_price);
            }

            return null;
        }
    }
}