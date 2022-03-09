using DistanceCalculator.Application.Strategies;
using DistanceCalculator.Application.Strategies.Implementations;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistanceCalculator.Application.UnitTests.Strategies
{
    [TestClass]
    public class LawofCosinesDistanceStrategyTests
    {
        private readonly LawofCosinesDistanceStrategy _sut;
        private readonly Coordinates _coordinates;
        private readonly Coordinates _sameCoordinates;
        public LawofCosinesDistanceStrategyTests()
        {
            _sut = new LawofCosinesDistanceStrategy();

            _coordinates = new Coordinates
            { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 41.385101, DestinationLong = -81.440440 };

            _sameCoordinates = new Coordinates
            { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 53.297975, DestinationLong = -6.372663 };
        }


        [TestMethod]
        public void LawofCosinesDistanceStrategy_CalculateDistanceInKM_ReturnsResultAndResultIsAccurate()
        {
            double result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Kilometers);
            Assert.IsNotNull(result);
            Assert.AreEqual(5536.34, result);
        }

        [TestMethod]
        public void LawofCosinesDistanceStrategy_CalculateDistanceInMiles_ReturnsResultAndResultIsAccurate()
        {
            double result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Miles);
            Assert.IsNotNull(result);
            Assert.AreEqual(3439.46, result);
        }


        [TestMethod]
        public void LawofCosinesDistanceStrategy_CalculateDistanceInKM_ReturnsZero()
        {
            double result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Kilometers);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LawofCosinesDistanceStrategy_CalculateDistanceInMiles_ReturnsZero()
        {
            double result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Miles);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }
    }
}
