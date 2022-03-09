using DistanceCalculator.Application.Strategies;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator.Application.UnitTests.Strategies
{
    [TestClass]
    public class PythagoreanDistanceStrategyTests
    {

        private readonly PythagoreanDistanceStrategy _sut;
        private readonly Coordinates _coordinates;
        private readonly Coordinates _sameCoordinates;
        public PythagoreanDistanceStrategyTests()
        {
            _sut = new PythagoreanDistanceStrategy();

            _coordinates = new Coordinates
            { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 41.385101, DestinationLong = -81.440440 };

            _sameCoordinates = new Coordinates
            { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 53.297975, DestinationLong = -6.372663 };

        }


        [TestMethod]
        public void PythagoreanDistanceStrategy_CalculateDistanceInKM_ReturnsResultAndResultIsAccurate()
        {
            double result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Kilometers);
            Assert.IsNotNull(result);
            Assert.AreEqual(8450.48, result);
        }

        [TestMethod]
        public void PythagoreanDistanceStrategy_CalculateDistanceInMiles_ReturnsResultAndResultIsAccurate()
        {
            double result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Miles);
            Assert.IsNotNull(result);
            Assert.AreEqual(5251.33, result);
        }


        [TestMethod]
        public void PythagoreanDistanceStrategy_CalculateDistanceInKM_ReturnsResultAndResultIsZero()
        {
            double result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Kilometers);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void PythagoreanDistanceStrategy_CalculateDistanceInMiles_ReturnsResultAndResultIsZero()
        {
            double result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Miles);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }
    }
}
