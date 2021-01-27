using System.Threading;
using System.Threading.Tasks;

namespace TruckPlan.Domain
{
    public interface ITruckPlanRepository
    {
        //Cancellation token
        Task<TruckPlan> GetByName(string name);
    }
}
