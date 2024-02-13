using System.ComponentModel.DataAnnotations;

namespace Test.Data.ProviderOne;

public sealed class ProviderOneRoute
{
    /// <summary>
    /// Точка отправления
    /// </summary>
    public string From { get; set; } = null!;

    /// <summary>
    /// Точка прибытия
    /// </summary>
    public string To { get; set; } = null!;

    /// <summary>
    /// Дата начала маршрута
    /// </summary>
    public DateTime DateFrom { get; set; }

    /// <summary>
    /// Дата окончания маршрута
    /// </summary>
    public DateTime? DateTo { get; set; }

    /// <summary>
    /// Цена маршрута
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Срок действия маршрута
    /// </summary>
    public DateTime TimeLimit { get; set; }
}