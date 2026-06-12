using System;
using UnitConversionSystem.Core.Interfaces;
using UnitConversionSystem.Core.Models;

namespace UnitConversionSystem.Core.Services
{
    public class TemperatureConversionStrategy : IConversionStrategy
    {
        public ConversionCategory Category => ConversionCategory.Temperature;

        public double Convert(double value, string fromUnit, string toUnit)
        {
            string from = fromUnit.ToLower().Trim();
            string to = toUnit.ToLower().Trim();

            if (from == to) return value;

            // Normalize input value to Celsius first
            double celsius = from switch
            {
                "celsius" or "c" => value,
                "fahrenheit" or "f" => (value - 32) * 5 / 9,
                "kelvin" or "k" => value - 273.15,
                _ => throw new ArgumentException($"Unsupported temperature source unit: {fromUnit}")
            };

            // Convert Celsius to the targeted unit
            return to switch
            {
                "celsius" or "c" => celsius,
                "fahrenheit" or "f" => (celsius * 9 / 5) + 32,
                "kelvin" or "k" => celsius + 273.15,
                _ => throw new ArgumentException($"Unsupported temperature target unit: {toUnit}")
            };
        }
    }
}
