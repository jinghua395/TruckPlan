using System;
using System.Collections.Generic;

namespace TruckPlan.Application.Infrastructure
{
    public class DbContext
    {
        public IEnumerable<Domain.TruckPlan> TruckPlans { get; set; }
        public IEnumerable<Domain.Track> Tracks { get; set; }
        public IEnumerable<Domain.Driver> Drivers { get; set; }
    }
}
