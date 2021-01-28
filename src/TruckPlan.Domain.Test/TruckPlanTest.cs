using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TruckPlan.Domain.Test
{
    [TestClass]
    public class TruckPlanTest
    {

        [TestMethod]
        public void TotalDistance_GivenTestData_ThenOk()
        {
            var sut = new TruckPlan("a", new List<Location>
            {
                new Location(0, 0),
                new Location(3, 4),
            });

            var result = sut.Distance;

            Assert.AreEqual(5.00m, Math.Round(result, 2));
        }
    }
}
