using ProjetEnnySarahLocationJeux.DAO;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace ProjetEnnySarahLocationJeux.ValidationRules
{
    public class ValidateUsername : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                bool isUsernameAvailable = new PlayerDAO().IsUsernameAvailable(value.ToString());
                if (isUsernameAvailable)
                {
                    return ValidationResult.ValidResult;
                }
                else
                {
                    return new ValidationResult(false, "Username already taken");
                }
            }
            else
            {
                return new ValidationResult(false, "Must be characters");
            }
        }
    }
}
