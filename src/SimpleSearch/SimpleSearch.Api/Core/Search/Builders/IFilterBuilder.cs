using System.Collections.Generic;
using SimpleSearch.Api.Core.Search.FilterMappers;
using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.Builders
{
    public interface IFilterBuilder
    {
        IFilterBuilder Add<T>(IPropertyFilterHandler<T> mapper);
        List<IFilter> ToFilterList();
    }
}