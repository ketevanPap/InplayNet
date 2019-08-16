using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Inplaynet.Model.Dtos.DtosAttributes
{
    class ValidName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(string.Concat(context.DisplayName,"is Required "));

            return (!value.ToString().Any(char.IsDigit)
                && value.ToString().Length > 2)
                ? ValidationResult.Success
                : new ValidationResult(string.Concat(context.DisplayName, " should not contain numbers and must contain at least 2 characters"));
        }
    }
}
