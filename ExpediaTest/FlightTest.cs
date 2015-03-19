using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		private readonly DateTime leaves = new DateTime(2011,12,13);
        private readonly DateTime returns = new DateTime(2011,12,17);
        private readonly int distance = 1000;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(leaves, returns, distance);
            Assert.IsNotNull(target);
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatPlaneThrowsOnBadFlightLength()
        {
            new Flight(leaves, returns, -5);
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatPlaneThrowsOnBadFlightDays()
        {
            new Flight(new DateTime(2012,12,13),returns,distance);
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayStay()
        {
            var target = new Flight(new DateTime(2012, 12, 13), new DateTime(2012, 12, 14), distance);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayStay()
        {
            var target = new Flight(new DateTime(2012, 12, 13), new DateTime(2012, 12, 15), distance);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayStay()
        {
            var target = new Flight(new DateTime(2012, 12, 13), new DateTime(2012, 12, 23), distance);
            Assert.AreEqual(400, target.getBasePrice());
        }
	}
}
