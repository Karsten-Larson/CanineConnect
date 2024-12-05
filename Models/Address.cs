using System.ComponentModel.DataAnnotations;

namespace CanineConnect.Models
{
    public class Address
    {
        public Address()
        {
            Street = "";
            City = "";
            State = "";
            PostalCode = "";
            Country = "";
        }

        public int Id { get; set; }
        [Required]
        public required string Street { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string State { get; set; }
        [Required]
        public required string PostalCode { get; set; }
        [Required]
        public required string Country { get; set; }
    }
}
