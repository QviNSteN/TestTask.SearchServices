using System.ComponentModel.DataAnnotations;
using Test.Data.Base;
using Test.Data.Entities;

namespace Test.Data.ProviderTwo;

/// <summary>
/// Фильтр для поиска, предназначенный для второго провайдера
/// </summary>
public class ProviderTwoSearchRequest : BaseRequest
{
    /// <summary>
    /// Точка отправления
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите точку отправления!")]
    public string Departure { get; set; }

    /// <summary>
    /// Точка прибытия
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите точку прибытия!")]
    public string Arrival { get; set; }
    
    /// <summary>
    /// Дата начала маршрута
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите дату начала предполагаемого маршрута!")]
    public DateTime DepartureDate { get; set; }

    /// <summary>
    /// Минимальное время, окончания принятия решения по маршруту
    /// </summary>
    public DateTime? MinTimeLimit { get; set; }

    public override bool Filter(Route route)
     => route.Origin == Departure && route.Destination == Arrival
        && route.OriginDateTime == DepartureDate
        && (MinTimeLimit is not null ? route.TimeLimit.Date <= DateTime.UtcNow.Date : true);
}
