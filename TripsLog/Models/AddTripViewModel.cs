using System.ComponentModel.DataAnnotations;
namespace TripsLog.Models
{
    public class AddTripViewModel
    {
        public Destination? Destination { get; set; }
        public Accommodation? Accommodation { get; set; }
        public Activity? Activity { get; set; }
        public Trip? Trip { get; set; }
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }
        [Display(Name = "Accommodation")]
        public int AccommodationId { get; set; }
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Activity")]
        public int ActivityId { get; set; }
        [Display(Name = "Activities")]
        public List<int> ActivityIds { get; set; }
    }
}
