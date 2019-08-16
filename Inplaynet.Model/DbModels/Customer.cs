using System;
using System.ComponentModel.DataAnnotations;

namespace Inplaynet.Model.DbModels
{
    public class Customer
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string Resident { get; set; }

        [Required]
        public ulong PrivateID { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [MaxLength(50)]
        public string RegistrationIP { get; set; }

        [MaxLength(50)]
        public string Language { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string RegionState { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [MaxLength(100)]
        public string PostalCode { get; set; }
    }
}
