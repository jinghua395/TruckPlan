using System;
using System.Collections.Generic;

namespace TruckPlan.Domain
{
    //Aggregate root
    public class Track
    {
        public Track(Guid id, Guid truckPlanId, Guid driverId)
        {
            Id = id;
            TruckPlanId = truckPlanId;
            DriverId = driverId;

            _locations = new List<Location>();
        }

        public Guid Id { get; private set; }
        public Guid TruckPlanId { get; set; }
        public Guid DriverId { get; private set; }

        private readonly List<Location> _locations;
        public IReadOnlyCollection<Location> Locations => _locations;

        public void AddLocation(Location location)
        {
            _locations.Add(location);
        }
    }
}
