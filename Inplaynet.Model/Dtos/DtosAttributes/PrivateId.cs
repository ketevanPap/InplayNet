using System.ComponentModel.DataAnnotations;

namespace Inplaynet.Model.Dtos.DtosAttributes
{
    class PrivateId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var customer = (CustomerDto)context.ObjectInstance;

            if (customer.PrivateID == 0)
                return new ValidationResult(string.Concat(context.DisplayName, "is Required "));

            return (customer.PrivateID.ToString().Length == 11)
                ? ValidationResult.Success
                : new ValidationResult(string.Concat(context.DisplayName, " must be a 11 characters"));
        }
    }
}
