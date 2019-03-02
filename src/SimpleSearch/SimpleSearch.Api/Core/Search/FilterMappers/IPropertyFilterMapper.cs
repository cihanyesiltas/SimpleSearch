using SimpleSearch.Api.Core.Search.Filters;

namespace SimpleSearch.Api.Core.Search.FilterMappers
{
    public interface IPropertyFilterMapper<T>
    {
        IFilter GetFilter();
    }
}