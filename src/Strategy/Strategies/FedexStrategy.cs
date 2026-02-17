using Strategy.Abstractions.Interfaces;
using Strategy.Models;

namespace Strategy.Strategies;

public class FedexStrategy : IShippingStrategy
{
    public decimal CalculateShipping(ShippingInfo info)
    {
        var cost = 30.00m; // Taxa base internacional
        cost += info.Weight * 5.00m;

        if (info.IsExpress)
            cost *= 1.8m; // 80% a mais para expresso

        // Taxa adicional para destinos remotos
        if (info.Destination.Contains("Norte") || info.Destination.Contains("Nordeste"))
            cost += 20.00m;

        Console.WriteLine($"→ Cálculo FedEx: R$ {cost:N2}");

        return cost;
    }

    public string GetCarrierName() => "FedEx";

    public int GetDeliveryTime(ShippingInfo info) => info.IsExpress ? 2 : 5;

    public bool IsAvailable(ShippingInfo info) => info.Weight <= 50;
}
