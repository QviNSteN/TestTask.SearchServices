using System.ComponentModel.DataAnnotations;
using Test.Data.Base;
using Test.Data.Entities;

namespace Test.Data.Search;

public class SearchRequest : BaseRequest
{
    /// <summary>
    /// Точка отправления
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите точку отправления!")]
    public string Origin { get; set; }

    /// <summary>
    /// Точка прибытия
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите точку прибытия!")]
    public string Destination { get; set; }

    /// <summary>
    /// Дата начала маршрута
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите дату начала предполагаемого маршрута!")]
    public DateTime OriginDateTime { get; set; }

    /// <summary>
    /// Фильтры
    /// </summary>
    public SearchFilters? Filters { get; set; }

    public override bool Filter(Route route)
        => route.Origin == Origin && route.Destination == Destination && route.OriginDateTime.Date == OriginDateTime.Date
            && (Filters is not null
            ?  (Filters.MaxPrice is null || Filters.MaxPrice >= route.Price)
            && (Filters.DestinationDateTime is null || Filters.DestinationDateTime.Value.Date == route.DestinationDateTime.Date)
            && (Filters.MinTimeLimit is null || Filters.MinTimeLimit >= route.TimeLimit)
            : true);
}
