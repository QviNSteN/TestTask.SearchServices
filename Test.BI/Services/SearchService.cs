using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BI.Cache;
using Test.BI.Interfaces;
using Test.Data.Entities;
using Test.Data.Search;
using Test.SearchService.Data;

namespace Test.SearchService.BI.Services
{
    public class SearchService : ISearchService, IStatus
    {
        private readonly static Cache<Route> Cache = new Cache<Route>();

        private readonly IEnumerable<Provider> Providers;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public SearchService(IEnumerable<Provider> providers, ILogger logger, IMapper mapper)
        {
            Providers = providers;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
            => Task.FromResult(new Random().Next(0, 2) != 0);

        public async Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken)
        {
            if(request?.Filters?.OnlyCached != true)
                foreach (var p in Providers.Where(x => x.TypeSearchResponse != null))
                {
                    Cache.AddOrUpdate(await p.Search<Route>(request, cancellationToken));
                }

            var routes = Cache.GetAll(x => request.Filter(x)).ToArray();

            return new SearchResponse().GetResponse(routes);
        }
    }
}
