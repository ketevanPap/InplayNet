using System;
using System.ComponentModel.DataAnnotations;

namespace Inplaynet.Model.Dtos
{
    class AgeRestriction : ValidationAttribute
    {
        public int MinAge { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var customer = (CustomerDto)context.ObjectInstance;

            if (customer.DateOfBirth == null)
                return new ValidationResult("Birthdate is Required.");

            var age = DateTime.Today.Year - customer.DateOfBirth.Year;

            return (age >= MinAge)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 16 years old to go on a membership.");
        }
    }
}
