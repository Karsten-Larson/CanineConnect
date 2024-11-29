using System.ComponentModel.DataAnnotations;

namespace CanineConnect.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int LocationId { get; set; }
        public Address? Location { get; set; }

        [Required]
        public int HostId { get; set; }
        public Shelter? Host { get; set; }
    }
}
