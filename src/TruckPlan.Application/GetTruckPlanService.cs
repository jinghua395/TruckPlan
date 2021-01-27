using System;
using System.Threading.Tasks;

namespace TruckPlan.Application
{
    public class GetTruckPlanService
    {
        public Task<TruckPlanDTO> Handle(string planName)
        {
            throw new NotImplementedException();
        }
    }

    public class TruckPlanDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Distance { get; set; }
    }
}
