using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TruckPlan.Domain.Test
{
    [TestClass]
    public class CalculateDistanceServiceTest
    {
        [TestMethod]
        public void DistanceInBetween_GivenInputs_ThenCorrect()
        {
            var l1 = new Location(0m, 0m);
            var l2 = new Location(3m, 4m);
            var result = CalculateDistanceService.DistanceInBetween(l1, l2);

            Assert.AreEqual(5.00m, Math.Round(result, 2));
        }
    }
}
