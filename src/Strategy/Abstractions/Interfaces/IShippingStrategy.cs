using Strategy.Models;

namespace Strategy.Abstractions.Interfaces;

public interface IShippingStrategy
{
    decimal CalculateShipping(ShippingInfo info);
    int GetDeliveryTime(ShippingInfo info);
    bool IsAvailable(ShippingInfo info);
    string GetCarrierName();
}
