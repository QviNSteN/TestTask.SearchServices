using Test.Data.Base;
using Test.Data.Entities;
using Test.Data.ProviderTwo;

namespace Test.Data.ProviderOne;

public class ProviderTwoSearchResponse : BaseResponse
{
    /// <summary>
    /// Массив маршрутов
    /// </summary>
    public ProviderTwoRoute[] Routes { get; set; }

    public override BaseResponse GetResponse(IEnumerable<Route> routes)
    {
        Routes = routes.Select(r => new ProviderTwoRoute()
        {
            Arrival = new ProviderTwoPoint()
            {
                Point = r.Destination,
                Date = r.DestinationDateTime
            },
            Departure = new ProviderTwoPoint()
            {
                Point = r.Origin,
                Date = r.OriginDateTime
            },
            Price = r.Price,
            TimeLimit = r.TimeLimit,
        }).ToArray();

        return this;
    }
}
