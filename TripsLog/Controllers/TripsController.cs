using Microsoft.AspNetCore.Mvc;
using TripsLog.Data;
using TripsLog.Models;
using Microsoft.EntityFrameworkCore;
namespace TripsLog.Controllers
{
    public class TripsController : Controller
    {
        private readonly TripsContext _context;
        public TripsController(TripsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var trips = _context.Trips
            .Include(t => t.Destination)
            .Include(t => t.Accommodation)
            .Include(t => t.TripActivities)
                .ThenInclude(ta => ta.Activity)
            .ToList();
            return View(trips);
        }
        [HttpPost]
        public IActionResult DeleteTrip(int tripId)
        {
            var trip = _context.Trips
                    .Include(t => t.TripActivities) // Include related TripActivities
                    .FirstOrDefault(t => t.TripId == tripId);
            if (trip != null)
            {
                _context.TripActivities.RemoveRange(trip.TripActivities);
                _context.Trips.Remove(trip);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Trips");
        }
        public IActionResult AddTripStep1()
        {
            ViewBag.Destinations = _context.Destinations.ToList();
            ViewBag.Accommodations = _context.Accommodations.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddTripStep1(AddTripViewModel obj1)
        {
            var startdate = obj1.StartDate;
            var enddate = obj1.EndDate;
            var destinationId = obj1.DestinationId;
            var accommodationId = obj1.AccommodationId;
            return RedirectToAction("AddTripStep3", "Trips", new { startDate = startdate, endDate = enddate, destinationId = destinationId, accommodationId = accommodationId });
        }
        public IActionResult AddTripStep3(DateTime startDate, DateTime endDate, int destinationId, int accommodationId)
        {
            var destinationName = _context.Destinations.FirstOrDefault(d => d.DestinationId == destinationId)?.DestinationName;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.AccommodationId = accommodationId;
            ViewBag.DestinationName = destinationName;
            ViewBag.DestinationId = destinationId;
            ViewBag.Activities = _context.Activities.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddTripStep3(AddTripViewModel obj2)
        {
            if (ModelState.IsValid)
            {
                var destination = _context.Destinations.FirstOrDefault(d => d.DestinationId == obj2.DestinationId);
                var accommodation = _context.Accommodations.FirstOrDefault(a => a.AccommodationId == obj2.AccommodationId);
                var trip = new Trip
                {
                    StartDate = obj2.StartDate,
                    EndDate = obj2.EndDate,
                    DestinationId = obj2.DestinationId,
                    Destination = destination,
                    AccommodationId = obj2.AccommodationId,
                    Accommodation = accommodation,
                    TripActivities = new List<TripActivity>()
                };
                if (obj2.ActivityIds != null)
                {
                    foreach (var activityId in obj2.ActivityIds)
                    {
                        var activity = _context.Activities.FirstOrDefault(a => a.ActivityId == activityId);

                        if (activity != null)
                        {
                            var tripActivity = new TripActivity
                            {
                                ActivityId = activityId,
                                Activity = activity
                            };
                            trip.TripActivities.Add(tripActivity);
                        }
                    }
                }
                _context.Trips.Add(trip);
                _context.SaveChanges();
                return RedirectToAction("Index", "Trips");
            }
            return View(obj2);
        }
        public IActionResult ManagePage()
        {
            ViewBag.Destinations = _context.Destinations.ToList();
            ViewBag.Accommodations = _context.Accommodations.ToList();
            ViewBag.Activities = _context.Activities.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult ManagePage(ManagePageViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var destinationName = obj.Destination?.DestinationName;
                var accommodationName = obj.Accommodation?.AccommodationName;
                var accommodationPhone = obj.Accommodation?.AccommodationPhone;
                var accommodationEmail = obj.Accommodation?.AccommodationEmail;
                var activityName = obj.Activity?.ActivityName;
                var destination = new Destination { DestinationName = destinationName };
                var accommodation = new Accommodation { AccommodationName = accommodationName, AccommodationPhone = accommodationPhone, AccommodationEmail = accommodationEmail };
                var activity = new Activity { ActivityName = activityName };
                _context.Destinations.Add(destination);
                _context.Accommodations.Add(accommodation);
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction("AddTripStep1", "Trips");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult DeleteItems(int destinationId, int accommodationId, int activityId)
        {
            try
            {
                var destination = _context.Destinations.FirstOrDefault(d => d.DestinationId == destinationId);
                var accommodation = _context.Accommodations.FirstOrDefault(d => d.AccommodationId == accommodationId);
                var activity = _context.Activities.FirstOrDefault(d => d.ActivityId == activityId);
                if (destination != null)
                {
                    _context.Destinations.Remove(destination);
                }
                if (accommodation != null)
                {
                    _context.Accommodations.Remove(accommodation);
                }
                if (activity != null)
                {
                    _context.Activities.Remove(activity);
                }
                _context.SaveChanges();
                return RedirectToAction("AddTripStep1", "Trips");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred while deleting items: " + ex.Message;
                return RedirectToAction("AddTripStep1", "Trips");
            }
        }
    }
}