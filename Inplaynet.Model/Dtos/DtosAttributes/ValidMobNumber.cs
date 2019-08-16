using System.ComponentModel.DataAnnotations;

namespace Inplaynet.Model.Dtos.DtosAttributes
{
    class ValidMobNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Mobile number is Required.");

            if (value.ToString().Length < 3)
                return new ValidationResult("Mobile number is short.");

            return (value.ToString().Substring(0, 4) == "+995" || value.ToString().Substring(0, 3) == "+49")
                ? ValidationResult.Success
                : new ValidationResult("Enter a Georgian or German number. exp: +995XXXXXXXXX, +49XXXXXXXXX");
        }
    }
}
