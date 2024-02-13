using Test.Data.Search;
using Test.SearchService.Data;

namespace Test.BI.Interfaces;

public interface ISearchService
{
    Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken);
}

public interface IStatus
{
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}