using System.ComponentModel.DataAnnotations;
namespace TripsLog.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required]
        public string? ActivityName { get; set; }
        public ICollection<TripActivity>? TripActivities { get; set; }
    }
}
