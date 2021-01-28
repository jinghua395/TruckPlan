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

            _positions = new List<Position>();
        }

        public Guid Id { get; private set; }
        public Guid TruckPlanId { get; set; }
        public Guid DriverId { get; private set; }
        //Consider store driver age
        public DateTime Date { get; private set; }

        //Consider model it as location + timestamp
        private readonly List<Position> _positions;
        public IReadOnlyCollection<Position> Positions => _positions;

        public decimal Distance { get; set; }

        public void AddPosition(Position position)
        {
            if (_positions.Any())
            {
                var last = _positions.Last(); //Consider persist last position

                if (position.Time <= last.Time)
                {
                    throw new ArgumentException("New position must later than last position");
                }

                Distance += CalculateDistanceService.DistanceInBetween(last.Latitude, last.Longitude, position.Latitude, position.Longitude);
            }

            _positions.Add(position);
        }
    }

    public class Position
    {
        public Position(DateTimeOffset time, decimal latitude, decimal longitude)
        {
            Time = time.ToUniversalTime();
            Latitude = latitude;
            Longitude = longitude;
        }

        public DateTimeOffset Time { get; set; } //Utc, so it is GEO-aware
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
    }
}
