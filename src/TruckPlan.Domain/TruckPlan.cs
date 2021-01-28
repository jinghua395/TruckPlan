using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPlan.Domain
{
    //AggregateRoot
    //Truck plan = route, which is irrelevant to a driver and time
    public class TruckPlan
    {
        public TruckPlan(string name, List<Location> locations)
        {
            Id = Guid.NewGuid();
            Name = name;

            if (locations.Count < 2)
                throw new ArgumentException("Must more than two locations");

            _locations = locations;

            StartingPoint = locations.First();
            Destination = locations.Last();

            Distance = TotalInstance(locations);
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Location StartingPoint { get; private set; }

        public Location Destination { get; private set; }

        public decimal Distance { get; set; }

        //Consider separate this a different aggregate root if the location is not needed to retrieve all the time
        private readonly List<Location> _locations;
        public IReadOnlyCollection<Location> Locations => _locations;

        //Consider async run this method if this is a high CPU bound
        //https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth
        private decimal TotalInstance(List<Location> locations) 
        {
            var distance = 0m;
            for (var i = 1; i < locations.Count; i++)
            {
                //algorithm to calculate
                distance += CalculateDistanceService.DistanceInBetween(locations[i - 1], locations[i]);
            }

            return distance;
        }
    }
}
