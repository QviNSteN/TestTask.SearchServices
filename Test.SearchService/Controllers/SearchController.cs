using Microsoft.AspNetCore.Mvc;
using Test.BI.Interfaces;
using Test.Data.Search;

namespace Test.ProviderOne.Controllers
{
    [Route("v1")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchRequest filter, CancellationToken cancellationToken)
        {
            if (filter == null)
                return BadRequest();

           return Ok(await _searchService.SearchAsync(filter, cancellationToken));
        }
    }
}
