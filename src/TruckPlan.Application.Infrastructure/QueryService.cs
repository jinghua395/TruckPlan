using System;
using System.Linq;
using System.Threading.Tasks;

namespace TruckPlan.Application.Infrastructure
{
    public class QueryService: IQueryTruckPlanService, IQueryDriverTrackService
    {
        private readonly DbContext _context;

        public QueryService(DbContext context)
        {
            _context = context;
        }

        public Task<TruckPlanDTO> Handle(string planName)
        {
            var plan = _context.TruckPlans.SingleOrDefault(x => x.Name == planName);

            if (plan == null) return null;

            var result = new TruckPlanDTO
            {
                Id = plan.Id,
                Name = plan.Name,
                Distance = Math.Round(plan.Distance, 2),
            };

            return Task.FromResult(result);
        }

        public Task<DriverTrackDTO> Handle(int ageFrom, DateTime dateFrom, DateTime dateTo)
        {
            //Consider use TimeService so it is GEO-aware
            var birthdayFrom = DateTime.Today.AddYears(ageFrom * -1);

            //If this is a performance issue, persist the driver age in the trace Aggregate root
            var drivers = _context.Drivers
                .Where(d => d.Birthday <= birthdayFrom)
                .Select(d => d.Id)
                .ToList();

            var totalDistance = _context.Tracks.Where(t =>
                    t.Date >= dateFrom
                    && t.Date <= dateTo
                    && drivers.Contains(t.DriverId))
                .Sum(t => t.Distance);

            return Task.FromResult(new DriverTrackDTO
            {
                Distance = totalDistance
            });
        }
    }
}
