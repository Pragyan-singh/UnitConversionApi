namespace UnitConversionSystem.Core.Models
{
    public class ConversionResult
    {
        public double OriginalValue { get; set; }
        public double ConvertedValue { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
    }
}
