using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.FilterMappers
{
    public class CustomerNameFilterMapper : IPropertyFilterMapper<string>
    {
        private readonly string _name;
        
        public CustomerNameFilterMapper(string name)
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