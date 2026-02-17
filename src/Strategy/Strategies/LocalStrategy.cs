using Strategy.Abstractions.Interfaces;
using Strategy.Models;

namespace Strategy.Strategies;

public class LocalStrategy : IShippingStrategy
{
    public decimal CalculateShipping(ShippingInfo info)
    {
        var cost = 8.00m;
        cost += info.Weight * 1.50m;

        Console.WriteLine($"→ Cálculo Local: R$ {cost:N2}");
        return cost;
    }

    public string GetCarrierName() => "Transportadora Local";

    public int GetDeliveryTime(ShippingInfo info) => 1;

    public bool IsAvailable(ShippingInfo info) => info.Destination.Contains("São Paulo-SP");
}
