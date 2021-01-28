using System.Collections.Generic;
using System.Threading.Tasks;

namespace TruckPlan.Application.FindRoute
{
    public interface IRouteAPIService
    {
        Task<IEnumerable<LocationDTO>> GetRoute(decimal longitude, decimal latitude);
    }

    /// <summary>
    /// Use own DTO, since this is usually defined by API
    /// </summary>
    public class LocationDTO
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
