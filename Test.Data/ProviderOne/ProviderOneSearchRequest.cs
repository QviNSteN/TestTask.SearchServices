using System.ComponentModel.DataAnnotations;
using Test.Data.Base;
using Test.Data.Entities;

namespace Test.Data.ProviderOne;

/// <summary>
/// Фильтр для поиска, предназначенный для первого провайдера
/// </summary>
public class ProviderOneSearchRequest : BaseRequest
{
    /// <summary>
    /// Точка отправления
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите точку отправления!")]
    public string From { get; set; } = null!;

    /// <summary>
    /// Точка прибытия
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите точку прибытия!")]
    public string To { get; set; } = null!;

    /// <summary>
    /// Дата начала маршрута
    /// </summary>
    [Required(ErrorMessage = "Пожалуйста, укажите дату начала предполагаемого маршрута!")]
    public DateTime DateFrom { get; set; }

    /// <summary>
    /// Дата окончания маршрута
    /// </summary>
    public DateTime? DateTo { get; set; }

    /// <summary>
    /// Максимальная цена маршрута
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "Сумма не может быть меньше нуля!")]
    public decimal? MaxPrice { get; set; }

    public override bool Filter(Route route)
     => route.Origin == From && route.Destination == To
        && route.OriginDateTime == DateFrom && (DateTo is not null ? route.DestinationDateTime == DateTo : true)
        && (MaxPrice is not null ? route.Price <= MaxPrice : true);
}