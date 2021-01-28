using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TruckPlan.Domain.Test
{
    [TestClass]
    public class TrackTest
    {
        [TestMethod]
        public void AddLocation_WhenAddNew_ThenCorrectDistance()
        {
            var sut = new Track(Guid.NewGuid(), Guid.NewGuid(), DateTime.Today);
            sut.AddLocation(new Location(0m, 0m));
            sut.AddLocation(new Location(3m, 4m));

            Assert.AreEqual(5.00m, Math.Round(sut.Distance, 2));
        }
    }
}
