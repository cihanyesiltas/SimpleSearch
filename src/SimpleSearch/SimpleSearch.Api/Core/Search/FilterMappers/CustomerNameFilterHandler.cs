using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.FilterMappers
{
    public class CustomerNameFilterHandler : IPropertyFilterHandler<string>
    {
        private readonly string _name;
        
        public CustomerNameFilterHandler(string name)
        {
            _name = name;
        }
        
        public IFilter GetFilter()
        {
            if (!string.IsNullOrWhiteSpace(_name))
            {
                return new CustomerNameFilter(_name);
            }

            return null;
        }
    }
}