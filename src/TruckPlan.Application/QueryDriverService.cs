using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Application
{
    public class QueryDriverService
    {
        public Task<QueryResult> Handle(int ageFrom, int ageTo, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }
    }

    public class QueryResult
    {
        public decimal DistanceKm { get; set; }
    }
}
