﻿using System.ComponentModel.DataAnnotations;

namespace CanineConnect.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public DateTime Age { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Phone { get; set; }

        [Required]
        public int HomeAddressId { get; set; }
        public Address? HomeAddress { get; set; }
    }
}