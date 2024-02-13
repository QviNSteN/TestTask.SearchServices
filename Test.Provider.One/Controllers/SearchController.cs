using Microsoft.AspNetCore.Mvc;
using Test.BI.Interfaces;
using Test.Data.ProviderOne;
using Test.Providers.BI.Interfaces;

namespace Test.ProviderOne.Controllers
{
    [Route("v1")]
    public class SearchController : Controller
    {
        private readonly IStatus _status;
        private readonly IData<ProviderOneSearchResponse> _data;

        public SearchController(IStatus status, IData<ProviderOneSearchResponse> data)
        {
            _status = status;
            _data = data;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
            => _status.IsAvailable ? Ok() : StatusCode(500);

        [HttpGet("search")]
        public async Task<IActionResult> Search(ProviderOneSearchRequest filter)
            => Ok(await _data.GetData<ProviderOneSearchResponse, ProviderOneSearchRequest>(filter));
    }
}
