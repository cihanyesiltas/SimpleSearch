using System.Collections.Generic;
using SimpleSearch.Api.Core.Search.FilterMappers;
using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.Builders
{
    public class FilterBuilder : IFilterBuilder
    {
        private readonly List<IFilter> _filters;
        
        public FilterBuilder()
        {
            _filters = new List<IFilter>();    
        }
        
        
        public IFilterBuilder Add<T>(IPropertyFilterHandler<T> mapper)
        {
            var filter = mapper.GetFilter();
            if (filter != null)
            {
                _filters.Add(filter);
            }
            
            return this;
        }

        public List<IFilter> ToFilterList()
        {
            return _filters;
        }
    }
}