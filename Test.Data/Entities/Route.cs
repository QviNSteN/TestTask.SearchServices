using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Entities;

public class Route : Base
{
    /// <summary>
    /// Точка отправления
    /// </summary>
    public string Origin { get; set; } = null!;

    /// <summary>
    /// Точка прибытия
    /// </summary>
    public string Destination { get; set; } = null!;

    /// <summary>
    /// Дата начала маршрута
    /// </summary>
    public DateTime OriginDateTime { get; set; }

    /// <summary>
    /// Дата окончания маршрута
    /// </summary>
    public DateTime DestinationDateTime { get; set; }

    /// <summary>
    /// Цена маршрута
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Срок актуальности маршрута
    /// </summary>
    public DateTime TimeLimit { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj == null)
            return false;

        var o = (Route)obj;

        return o.Id == Id && o.Origin == Origin && o.Price == Price
            && o.Destination == Destination && o.OriginDateTime == OriginDateTime
            && o.DestinationDateTime == DestinationDateTime && o.TimeLimit == TimeLimit;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
