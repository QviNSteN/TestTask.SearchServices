using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Base;
using Test.Data.Entities;

namespace Test.Data.Search;

public class SearchResponse : BaseResponse
{
    // Mandatory
    // Array of routes
    public Route[] Routes { get; set; }

    /// <summary>
    /// Самый дешёвый маршрут
    /// </summary>
    public decimal MinPrice { get; set; }

    /// <summary>
    /// Самый дорогой маршрут
    /// </summary>
    public decimal MaxPrice { get; set; }

    /// <summary>
    /// Самый быстрый маршрут
    /// </summary>
    public int MinMinutesRoute { get; set; }

    /// <summary>
    /// Самый медленный маршрут
    /// </summary>
    public int MaxMinutesRoute { get; set; }

    public override SearchResponse GetResponse(IEnumerable<Route> routes)
    {
        if (routes == null || !routes.Any())
            return this;

        Routes = routes.ToArray();
        MinPrice = Routes.Min(r => r.Price);
        MaxPrice = Routes.Max(r => r.Price);
        MinMinutesRoute = (int)Routes.Min(r => (r.DestinationDateTime - r.OriginDateTime).TotalMinutes);
        MaxMinutesRoute = (int)Routes.Max(r => (r.DestinationDateTime - r.OriginDateTime).TotalMinutes);

        return this;
    }
}