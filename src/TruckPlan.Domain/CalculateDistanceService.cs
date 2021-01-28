using System;

namespace TruckPlan.Domain
{
    public class CalculateDistanceService
    {
        public static decimal DistanceInBetween(Location from, Location to)
        {
            return DistanceInBetween(from.Latitude, from.Longitude, to.Latitude, to.Longitude);
        }

        public static decimal DistanceInBetween(decimal fromLatitude, decimal fromLongitude, decimal toLatitude, decimal toLongitude)
        {
            return (decimal)Math.Sqrt(
                Math.Pow((double)toLatitude - (double)fromLatitude, 2)
                +
                Math.Pow((double)toLongitude - (double)fromLongitude, 2)
            );
        }
    }
}
