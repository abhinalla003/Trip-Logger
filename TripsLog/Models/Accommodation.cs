using System.ComponentModel.DataAnnotations;
namespace TripsLog.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; } // Primary Key
        [Required]
        public string? AccommodationName { get; set; }
        [Required]
        public string? AccommodationPhone { get; set; }
        [Required]
        public string? AccommodationEmail { get; set; }
        public ICollection<Trip>? Trip { get; set; }
    }
}
