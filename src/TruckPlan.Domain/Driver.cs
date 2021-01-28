using System;

namespace TruckPlan.Domain
{
    //Aggregate root
    public class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
