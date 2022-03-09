using DistanceCalculator.Application.Strategies;
using DistanceCalculator.Application.Strategies.Contracts;
using DistanceCalculator.Application.Strategies.Implementations;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistanceCalculator.Application.UnitTests.Strategies
{
    [TestClass]
    public class DistanceCalculatorStrategyTests
    {
        private readonly DistanceCalculatorStrategy _sut;
        private readonly Coordinates _coordinates; 
        private readonly Coordinates _sameCoordinates; 
        public DistanceCalculatorStrategyTests()
        {
            _sut = new DistanceCalculatorStrategy( new List<IDistanceFormulaStrategy>()  
                { new LawofCosinesDistanceStrategy(), new PythagoreanDistanceStrategy() });

            _coordinates = new Coordinates
            { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 41.385101, DestinationLong = -81.440440 };

            _sameCoordinates = new Coordinates
            { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 53.297975, DestinationLong = -6.372663 };
        }

        [TestMethod]
        public void CalculateDistanceViaPythogorasFormulaInKM_ReturnsResultAndResultIsAccurate()
        {
            string result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Kilometers, Formula.Pythagoras);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("8450.48 Kilometers", result);
        }

        [TestMethod]
        public void CalculateDistanceViaPythogorasFormulaInMiles_ReturnsResultAndResultIsAccurate()
        {
            string result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Miles, Formula.Pythagoras);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("5251.33 Miles", result);
        }

        [TestMethod]
        public void CalculateDistanceViaCosinesFormulaInMiles_ReturnsResultAndResultIsAccurate()
        {
            string result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Miles, Formula.LawOfCosines);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("3439.46 Miles", result);
        }

        [TestMethod]
        public void CalculateDistanceViaCosinesFormulaInKM_ReturnsResultAndResultIsAccurate()
        {
            string result = _sut.CalculateDistance(_coordinates, MeasurementUnit.Kilometers, Formula.LawOfCosines);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("5536.34 Kilometers", result);
        }


        [TestMethod]
        public void CalculateDistanceViaPythogorasFormulaInKM_ReturnsZero()
        {
            string result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Kilometers, Formula.Pythagoras);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("0 Kilometers", result);
        }

        [TestMethod]
        public void CalculateDistanceViaPythogorasFormulaInMiles_ReturnsResult_ReturnsZero()
        {
            string result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Miles, Formula.Pythagoras);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("0 Miles", result);
        }

        [TestMethod]
        public void CalculateDistanceViaCosinesFormulaInMiles_ReturnsResult_ReturnsZero()
        {
            string result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Miles, Formula.LawOfCosines);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("0 Miles", result);
        }

        [TestMethod]
        public void CalculateDistanceViaCosinesFormulaInKM_ReturnsResult_ReturnsZero()
        {
            string result = _sut.CalculateDistance(_sameCoordinates, MeasurementUnit.Kilometers, Formula.LawOfCosines);
            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.AreEqual("0 Kilometers", result);
        }


    }
}
