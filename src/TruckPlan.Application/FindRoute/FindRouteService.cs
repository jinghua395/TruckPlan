using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPlan.Application.FindRoute
{
    public class FindRouteService
    {
        private readonly IRouteAPIService _routeApiService;

        public FindRouteService(IRouteAPIService routeApiService)
        {
            _routeApiService = routeApiService;
        }

        public async Task<RouteDTO> Handle(decimal longitude, decimal latitude)
        {
            var route = await _routeApiService.GetRoute(longitude, latitude);

            return new RouteDTO
            {
                Locations = route.Select(r => new LocationDTO
                {
                    Longitude = r.Longitude,
                    Latitude = r.Latitude
                })
            };
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
