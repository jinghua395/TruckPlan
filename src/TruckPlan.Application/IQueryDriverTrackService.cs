using System;
using System.Threading.Tasks;

namespace TruckPlan.Application
{
    public interface IQueryDriverTrackService
    {
        Task<DriverTrackDTO> Handle(int ageFrom, DateTime dateFrom, DateTime dateTo);
    }

    public class DriverTrackDTO
    {
        public decimal Distance { get; set; }
    }
}
