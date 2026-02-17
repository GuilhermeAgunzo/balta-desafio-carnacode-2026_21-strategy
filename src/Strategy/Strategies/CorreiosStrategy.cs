using Strategy.Abstractions.Interfaces;
using Strategy.Models;

namespace Strategy.Strategies;

public class CorreiosStrategy : IShippingStrategy
{
    public decimal CalculateShipping(ShippingInfo info)
    {
        var cost = 15.00m; // Taxa base
        cost += info.Weight * 2.50m; // Por kg

        if (info.IsExpress)
            cost += 25.00m; // Taxa SEDEX

        // Desconto para mesmo estado
        if (info.Origin.Split('-')[1] == info.Destination.Split('-')[1])
            cost *= 0.85m;

        Console.WriteLine($"→ Cálculo Correios: R$ {cost:N2}");
        return cost;
    }

    public string GetCarrierName() => "Correios";

    public int GetDeliveryTime(ShippingInfo info) => info.IsExpress ? 3 : 7;

    public bool IsAvailable(ShippingInfo info) => true;
}
