// DESAFIO: Sistema de Cálculo de Frete com Múltiplas Transportadoras
// PROBLEMA: Um e-commerce precisa calcular frete usando diferentes transportadoras (Correios, 
// FedEx, DHL, Transportadora Local), cada uma com sua própria lógica de cálculo. O código atual
// usa condicionais para escolher o algoritmo, violando o Open/Closed Principle

// Contexto: Sistema de e-commerce que calcula frete baseado em peso, destino e urgência
// Cada transportadora tem regras próprias e precisa ser facilmente intercambiável

using Strategy.Abstractions.Interfaces;
using Strategy.Models;
using Strategy.Service;
using Strategy.Strategies;

Console.WriteLine("=== Sistema de Cálculo de Frete ===");

var calculator = new ShippingCalculator();

var shipping1 = new ShippingInfo
{
    Origin = "São Paulo-SP",
    Destination = "Rio de Janeiro-RJ",
    Weight = 5.0m,
    IsExpress = false
};

var shipping2 = new ShippingInfo
{
    Origin = "São Paulo-SP",
    Destination = "Manaus-AM",
    Weight = 8.0m,
    IsExpress = true
};

// Testando transportadora inexistente
calculator.CalculateShipping(shipping1);

// Testando diferentes transportadoras
calculator.SetStrategy(new CorreiosStrategy());
calculator.CalculateShipping(shipping1);
calculator.GetDeliveryTime(shipping1);


calculator.SetStrategy(new FedexStrategy());
calculator.CalculateShipping(shipping2);
calculator.GetDeliveryTime(shipping2);

calculator.SetStrategy(new DHLStrategy());
calculator.CalculateShipping(shipping1);
calculator.GetDeliveryTime(shipping1);


calculator.SetStrategy(new LocalStrategy());
calculator.CalculateShipping(shipping1);
calculator.GetDeliveryTime(shipping1);

Console.WriteLine("\n=== Comparando Opções ===");
List<IShippingStrategy> carriers = [
    new CorreiosStrategy(),
    new FedexStrategy(),
    new DHLStrategy(),
    new LocalStrategy()
];

foreach (var carrier in carriers)
{
    calculator.SetStrategy(carrier);
    _ = calculator.CalculateShipping(shipping1);
    _ = calculator.GetDeliveryTime(shipping1);
}
