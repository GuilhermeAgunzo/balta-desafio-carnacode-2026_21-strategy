using Strategy.Abstractions.Interfaces;
using Strategy.Models;

namespace Strategy.Strategies;

public class DHLStrategy : IShippingStrategy
{
    public decimal CalculateShipping(ShippingInfo info)
    {
        var cost = 25.00m;
        cost += info.Weight * 4.50m;

        // DHL cobra por faixa de peso
        if (info.Weight > 10)
            cost += (info.Weight - 10) * 2.00m;

        if (info.IsExpress)
            cost += 35.00m;

        Console.WriteLine($"→ Cálculo DHL: R$ {cost:N2}");

        return cost;
    }

    public string GetCarrierName() => "DHL";

    public int GetDeliveryTime(ShippingInfo info) => info.IsExpress ? 1 : 4;

    public bool IsAvailable(ShippingInfo info) => info.Weight <= 50;
}
