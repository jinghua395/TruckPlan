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
            var time = new DateTimeOffset(2021, 1, 1, 10, 0,0, TimeSpan.Zero);
            var sut = new Track(Guid.NewGuid(), Guid.NewGuid(), DateTime.Today);
            sut.AddPosition(new Position(time, 0m, 0m));
            sut.AddPosition(new Position(time.AddMinutes(5), 3m, 4m));

            Assert.AreEqual(5.00m, Math.Round(sut.Distance, 2));
            Assert.AreEqual(2, sut.Positions.Count);
        }

        [TestMethod]
        public void AddLocation_WhenInverseTime_ThenThrow()
        {
            var time = new DateTimeOffset(2021, 1, 1, 10, 0, 0, TimeSpan.Zero);
            var sut = new Track(Guid.NewGuid(), Guid.NewGuid(), DateTime.Today);
            sut.AddPosition(new Position(time, 0m, 0m));

            Assert.ThrowsException<ArgumentException>(() =>
                sut.AddPosition(new Position(time.AddMinutes(-5), 3m, 4m)));
        }
    }
}
