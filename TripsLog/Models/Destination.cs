using System.ComponentModel.DataAnnotations;
namespace TripsLog.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        [Required]
        public string? DestinationName { get; set; }
        public ICollection<Trip>? Trip { get; set; }
    }
}
