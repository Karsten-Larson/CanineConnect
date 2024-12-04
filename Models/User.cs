using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanineConnect.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required DateOnly Age { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? Phone { get; set; }

        [Required]
        public int HomeAddressId { get; set; }
        public Address? HomeAddress { get; set; }
    }
}
