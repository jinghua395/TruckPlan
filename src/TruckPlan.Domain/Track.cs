using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckPlan.Domain
{
    //Aggregate root
    public class Track
    {
        public Track(Guid truckPlanId, Guid driverId, DateTime date)
        {
            Id = Guid.NewGuid();
            TruckPlanId = truckPlanId;
            DriverId = driverId;
            Date = date;

            _locations = new List<Location>();
        }

        public Guid Id { get; private set; }
        public Guid TruckPlanId { get; set; }
        public Guid DriverId { get; private set; }
        //Consider store driver age
        public DateTime Date { get; private set; }

        //Consider model it as location + timestamp
        private readonly List<Location> _locations;
        public IReadOnlyCollection<Location> Locations => _locations;

        public decimal Distance { get; set; }

        public void AddLocation(Location location)
        {
            if (_locations.Any())
            {
                Distance += CalculateDistanceService.DistanceInBetween(_locations.Last(), location);
            }

            _locations.Add(location);
        }
    }
}
