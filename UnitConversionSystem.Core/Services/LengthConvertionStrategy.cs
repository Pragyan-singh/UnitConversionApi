using System;
using System.Collections.Generic;
using UnitConversionSystem.Core.Interfaces;
using UnitConversionSystem.Core.Models;

namespace UnitConversionSystem.Core.Services
{
    public class LengthConversionStrategy : IConversionStrategy
    {
        public ConversionCategory Category => ConversionCategory.Length;

        // Conversion factors relative to 1 Meter
        private static readonly Dictionary<string, double> ToMeterFactors = new(StringComparer.OrdinalIgnoreCase)
        {
            { "meter", 1.0 },
            { "meters", 1.0 },
            { "m", 1.0 },
            { "foot", 0.3048 },
            { "feet", 0.3048 },
            { "ft", 0.3048 },
            { "inch", 0.0254 },
            { "inches", 0.0254 },
            { "in", 0.0254 }
        };

        public double Convert(double value, string fromUnit, string toUnit)
        {
            if (!ToMeterFactors.TryGetValue(fromUnit, out var fromFactor) ||
                !ToMeterFactors.TryGetValue(toUnit, out var toFactor))
            {
                throw new ArgumentException($"Unsupported length units: {fromUnit} or {toUnit}");
            }

            // Convert input unit to meters, then convert meters to target unit
            double valueInMeters = value * fromFactor;
            return valueInMeters / toFactor;
        }
    }
}
