using System;
using System.Collections.Generic;
using UnitConversionSystem.Core.Interfaces;
using UnitConversionSystem.Core.Models;

namespace UnitConversionSystem.Core.Services
{
    public class WeightConversionStrategy : IConversionStrategy
    {
        public ConversionCategory Category => ConversionCategory.Weight;

        // Conversion factors relative to 1 Kilogram
        private static readonly Dictionary<string, double> ToKgFactors = new(StringComparer.OrdinalIgnoreCase)
        {
            { "kilogram", 1.0 },
            { "kilograms", 1.0 },
            { "kg", 1.0 },
            { "pound", 0.45359237 },
            { "pounds", 0.45359237 },
            { "lbs", 0.45359237 },
            { "gram", 0.001 },
            { "grams", 0.001 },
            { "g", 0.001 }
        };

        public double Convert(double value, string fromUnit, string toUnit)
        {
            if (!ToKgFactors.TryGetValue(fromUnit, out var fromFactor) ||
                !ToKgFactors.TryGetValue(toUnit, out var toFactor))
            {
                throw new ArgumentException($"Unsupported weight units: {fromUnit} or {toUnit}");
            }

            double valueInKg = value * fromFactor;
            return valueInKg / toFactor;
        }
    }
}
