using System.ComponentModel.DataAnnotations;
namespace TripsLog.Models
{
    public class ManagePageViewModel
    {
        public Destination? Destination { get; set; }
        public Accommodation? Accommodation { get; set; }
        public Activity? Activity { get; set; }
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }
        [Display(Name = "Accommodation")]
        public int AccommodationId { get; set; }
        [Display(Name = "Activity")]
        public int ActivityId { get; set; }
    }
}
