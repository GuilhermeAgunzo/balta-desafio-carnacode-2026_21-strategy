using Strategy.Abstractions.Interfaces;
using Strategy.Models;

namespace Strategy.Service;

public class ShippingCalculator
{
    private IShippingStrategy? _shippingStrategy;

    public ShippingCalculator() { }

    public ShippingCalculator(IShippingStrategy shippingStrategy)
    {
        _shippingStrategy = shippingStrategy;
    }

    public decimal CalculateShipping(ShippingInfo info)
    {
        if (_shippingStrategy is null)
        {
            Console.WriteLine("Nenhuma transportadora selecionada.");
            return 0;
        }

        if (!_shippingStrategy.IsAvailable(info))
            return 0;

        Console.WriteLine($"\n=== Calculando Frete ===");
        Console.WriteLine($"Transportadora: {_shippingStrategy.GetCarrierName()}");
        Console.WriteLine($"Origem: {info.Origin}");
        Console.WriteLine($"Destino: {info.Destination}");
        Console.WriteLine($"Peso: {info.Weight}kg");
        Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");

        return _shippingStrategy.CalculateShipping(info);

    }

    public int GetDeliveryTime(ShippingInfo info)
    {
        if (_shippingStrategy is null)
        {
            Console.WriteLine("Nenhuma transportadora selecionada.");
            return 0;
        }

        if (!_shippingStrategy.IsAvailable(info))
            return 0;

        var time = _shippingStrategy.GetDeliveryTime(info);
        Console.WriteLine($"Prazo: {time} dias úteis\n");

        return time;
    }

    public void SetStrategy(IShippingStrategy shippingStrategy)
    {
        _shippingStrategy = shippingStrategy;
    }
}

