using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPlan.Domain
{
    //AggregateRoot
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
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Location StartingPoint { get; private set; }

        public Location Destination { get; private set; }

        private readonly List<Location> _locations;
        public IReadOnlyCollection<Location> Locations => _locations;

        //Not sure why we need to calculate the distance as described
        //TODO: I would just save the distance in repo
        public async Task<decimal> TotalInstance()
        {
            //High CPU task
            return await Task.Run(() =>
            {

                decimal DistanceInBetween(Location l1, Location l2)
                {

                    return (decimal) Math.Sqrt(
                        Math.Pow((double) l2.Latitude - (double) l1.Latitude, 2)
                        +
                        Math.Pow((double) l2.Longitude - (double) l1.Longitude, 2)
                    );
                }

                var distance = 0m;
                for (var i = 1; i < _locations.Count; i++)
                {
                    //algorithm to calculate
                    distance += DistanceInBetween(_locations[i - 1], _locations[i]);
                }

                return distance;
            });
        }
    }


    //Value objects
    public class Location
    {
        public Location(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
    }
}
