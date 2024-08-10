using System.ComponentModel.DataAnnotations;
namespace TripsLog.Models
{
    public class Trip
    {
        public int TripId { get; set; } // Primary Key
        [Required]
        public int DestinationId { get; set; } // Foreign Key
        public Destination Destination { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        //Accommodation Details
        public int? AccommodationId { get; set; }
        public Accommodation? Accommodation { get; set; }
        // Things to Do
        [Required]
        public ICollection<TripActivity> TripActivities { get; set; }
    }
}
