using System;
using System.Threading.Tasks;
using TruckPlan.Domain;

namespace TruckPlan.Application
{
    public class GetTruckPlanService
    {
        private readonly ITruckPlanRepository _truckPlanRepository;

        public GetTruckPlanService(ITruckPlanRepository truckPlanRepository)
        {
            _truckPlanRepository = truckPlanRepository;
        }

        //TODO: with cancellation token
        public async Task<TruckPlanDTO> Handle(string planName)
        {
            var plan = await _truckPlanRepository.GetByName(planName);

            if (plan == null) return null;
            
            return new TruckPlanDTO
            {
                Id = plan.Id,
                Name = plan.Name,
                Distance = Math.Round(plan.Distance, 2),
            };
        }
    }
    
    public class TruckPlanDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Distance { get; set; }
    }
}
