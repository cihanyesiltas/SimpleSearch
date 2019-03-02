using Nest;

namespace SimpleSearch.Api.Core.Search.Filters
{
    public interface IFilter
    {
        void Apply(ISearchRequest searchRequest);
    }
}