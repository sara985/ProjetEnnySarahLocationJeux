using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetEnnySarahLocationJeux.ValidationRules
{
    public class ValueRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int result))
            {
                if (result >= Min && result <= Max)
                {
                    return ValidationResult.ValidResult;
                }

                else
                {
                    return new ValidationResult(false, $"Value must be between {Min} and {Max}.");
                }
            }
            else
            {
                return new ValidationResult(false, "Value must be a number.");
            }
        }
    }
}
