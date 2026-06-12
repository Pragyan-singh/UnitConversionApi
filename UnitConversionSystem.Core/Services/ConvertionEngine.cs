using System;
using System.Collections.Generic;
using System.Linq;
using UnitConversionSystem.Core.Interfaces;
using UnitConversionSystem.Core.Models;

namespace UnitConversionSystem.Core.Services
{
    public class ConversionEngine
    {
        private readonly Dictionary<ConversionCategory, IConversionStrategy> _strategies;

        // .NET Dependency Injection automatically injects all registered IConversionStrategy implementations
        public ConversionEngine(IEnumerable<IConversionStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.Category);
        }

        public ConversionResult ProcessConversion(ConversionRequest request)
        {
            if (!_strategies.TryGetValue(request.Category, out var strategy))
            {
                throw new NotImplementedException($"No strategy implemented for category: {request.Category}");
            }

            double resultValue = strategy.Convert(request.Value, request.FromUnit, request.ToUnit);

            return new ConversionResult
            {
                OriginalValue = request.Value,
                ConvertedValue = Math.Round(resultValue, 4), // Clean rounding to 4 decimal places
                FromUnit = request.FromUnit,
                ToUnit = request.ToUnit
            };
        }
    }
}
