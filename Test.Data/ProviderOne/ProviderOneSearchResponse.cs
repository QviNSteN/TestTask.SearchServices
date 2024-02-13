using System.Net;
using Test.Data.Base;
using Test.Data.Entities;
using Test.Data.ProviderTwo;

namespace Test.Data.ProviderOne;

public class ProviderOneSearchResponse : BaseResponse
{
    /// <summary>
    /// Массив маршрутов
    /// </summary>
    public ProviderOneRoute[] Routes { get; set; }

    public override BaseResponse GetResponse(IEnumerable<Route> routes)
    {
        Routes = routes.Select(r =>
            new ProviderOneRoute()
            {
                To = r.Destination,
                From = r.Origin,
                DateTo = r.DestinationDateTime,
                DateFrom = r.OriginDateTime,
                Price = r.Price,
                TimeLimit = r.TimeLimit,
            }).ToArray();

        return this;
    }
}
