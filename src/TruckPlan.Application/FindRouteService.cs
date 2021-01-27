using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TruckPlan.Application
{
    public class FindRouteService
    {
        public Task<RouteDTO> Handle()
        {
            throw new NotImplementedException();
        }

        public class RouteDTO
        {
            public IEnumerable<LocationDTO> Locations { get; set; }
        }

        public class LocationDTO
        {
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
        }
    }
}
