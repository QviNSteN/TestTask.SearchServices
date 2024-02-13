namespace Test.Data.Search;

public class SearchFilters
{
    /// <summary>
    /// Дата окончания маршрута
    /// </summary>
    public DateTime? DestinationDateTime { get; set; }

    /// <summary>
    /// Максимальная цена маршрута
    /// </summary>
    public decimal? MaxPrice { get; set; }

    /// <summary>
    /// Срок действия маршрута
    /// </summary>
    public DateTime? MinTimeLimit { get; set; }

    /// <summary>
    /// Поиск только по кэшированным данным
    /// </summary>
    public bool? OnlyCached { get; set; }
}
