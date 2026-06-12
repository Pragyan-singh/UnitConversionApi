using System.ComponentModel.DataAnnotations;

namespace UnitConversionSystem.Core.Models
{
    public class ConversionRequest
    {
        [Required(ErrorMessage = "Value to convert is required.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Source unit (FromUnit) is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Source unit name must be between 1 and 50 characters.")]
        public string FromUnit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Target unit (ToUnit) is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Target unit name must be between 1 and 50 characters.")]
        public string ToUnit { get; set; } = string.Empty;

        [Required(ErrorMessage = "Conversion category is required.")]
        [Range(0, 2, ErrorMessage = "Category must be a valid range indicator: 0 (Length), 1 (Temperature), or 2 (Weight).")]
        public ConversionCategory Category { get; set; }
    }
}