using System;

namespace TruckPlan.Domain
{
    public class CalculateDistanceService
    {
        public static decimal DistanceInBetween(Location l1, Location l2)
        {
            return (decimal)Math.Sqrt(
                Math.Pow((double)l2.Latitude - (double)l1.Latitude, 2)
                +
                Math.Pow((double)l2.Longitude - (double)l1.Longitude, 2)
            );
        }
    }
}
