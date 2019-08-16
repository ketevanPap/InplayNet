using Inplaynet.Model.Dtos.DtosAttributes;
using System.ComponentModel.DataAnnotations;

namespace Inplaynet.Model.Dtos
{
    public class UpdateCustomerDto
    {
        [Required]
        public int ID { get; set; }

        [ValidName]
        public string FirstName { get; set; }

        [ValidName]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Language { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ValidMobNumber]
        public string Mobile { get; set; }

        [ValidPassword]
        public string Password { get; set; }

        public string Country { get; set; }

        public string RegionState { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostalCode { get; set; }
    }
}
