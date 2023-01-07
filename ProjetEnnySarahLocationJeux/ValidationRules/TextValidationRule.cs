using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ProjetEnnySarahLocationJeux.ValidationRules
{
    public class TextValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length == 0)
            {
                return new ValidationResult(false, "empty");
            }
            if (Regex.IsMatch(value.ToString(), "^[A-Za-z]*$"))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "invalid");
        }
    }
}
