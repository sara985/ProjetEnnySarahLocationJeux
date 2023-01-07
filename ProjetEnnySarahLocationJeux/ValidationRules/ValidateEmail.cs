using ProjetEnnySarahLocationJeux.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetEnnySarahLocationJeux.ValidationRules
{
    public class ValidateEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string)
            {
                bool isEmailAvailable = new PlayerDAO().IsEmailAvailable(value.ToString());
                if (isEmailAvailable)
                {
                    return ValidationResult.ValidResult;
                }
                else
                {
                    return new ValidationResult(false, "You already have an account with this email");
                }
            }
            else
            {
                return new ValidationResult(false, "Must be characters");
            }
        }
    }
}
