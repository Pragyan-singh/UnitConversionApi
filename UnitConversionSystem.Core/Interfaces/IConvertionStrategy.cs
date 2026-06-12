using UnitConversionSystem.Core.Models;

namespace UnitConversionSystem.Core.Interfaces
{
    public interface IConversionStrategy
    {
        ConversionCategory Category { get; }
        double Convert(double value, string fromUnit, string toUnit);
    }
}
