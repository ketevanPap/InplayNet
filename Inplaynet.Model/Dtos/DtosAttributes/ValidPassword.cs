using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inplaynet.Model.Dtos.DtosAttributes
{
    class ValidPassword : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (string.IsNullOrEmpty(value.ToString())) // || Password.Length < 8)
                return new ValidationResult("Password is Required ");

            return (value.ToString().Any(char.IsUpper)
                && value.ToString().Any(char.IsLower)
                && value.ToString().Any(char.IsDigit))
                ? ValidationResult.Success
                : new ValidationResult("Password must contain at least 1 lowercase, 1 uppercase letter and at least one digit");
        }
    }
}
