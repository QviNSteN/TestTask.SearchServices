using Microsoft.AspNetCore.Mvc;
using Test.BI.Interfaces;
using Test.Data.ProviderOne;
using Test.Data.ProviderTwo;
using Test.Providers.BI.Interfaces;

namespace Test.ProviderTwo.Controllers
{
    [Route("v1")]
    public class SearchController : Controller
    {
        private readonly IStatus _status;
        private readonly IData<ProviderTwoSearchResponse> _data;

        public SearchController(IStatus status, IData<ProviderTwoSearchResponse> data)
        {
            _status = status;
            _data = data;
        }

        [HttpGet("ping")]
        public IActionResult Ping() => _status.IsAvailable ? Ok() : StatusCode(500);

        [HttpGet("search")]
        public async Task<IActionResult> Search(ProviderTwoSearchRequest filter)
            => Ok(await _data.GetData<ProviderTwoSearchResponse, ProviderTwoSearchRequest>(filter));
    }
}
