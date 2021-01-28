using System;

namespace TruckPlan.Domain
{
    //Aggregate root
    public class Driver
    {
        public Driver(Guid id, string name, DateTime birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
    }
}
