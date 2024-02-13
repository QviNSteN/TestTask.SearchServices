namespace Test.Data.ProviderTwo;

public sealed class ProviderTwoRoute
{
    /// <summary>
    /// Точка отправления
    /// </summary>
    public ProviderTwoPoint Departure { get; set; }

    /// <summary>
    /// Точка прибытия
    /// </summary>
    public ProviderTwoPoint Arrival { get; set; }

    /// <summary>
    /// Цена маршрута
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Срок действия маршрута
    /// </summary>
    public DateTime TimeLimit { get; set; }
}
