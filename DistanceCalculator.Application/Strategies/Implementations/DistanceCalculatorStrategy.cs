using DistanceCalculator.Application.Strategies.Contracts;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Application.Strategies.Implementations
{
    public class DistanceCalculatorStrategy : IDistanceCalculatorStrategy
    {
        private readonly IEnumerable<IDistanceFormulaStrategy> _formulas;

        public DistanceCalculatorStrategy(IEnumerable<IDistanceFormulaStrategy> formulas)
        {
            _formulas = formulas;
        }

        /// <summary>
        /// Determines which implementation of distance calculator to use at run-time based on passed formula type
        /// </summary>
        /// <param name="start">Start coordinates</param>
        /// <param name="distination">Destination coordinates</param>
        /// <param name="measurementUnit">Unit of measure</param>
        /// <param name="formula">Calculation formula type</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string CalculateDistance(Coordinates coordinates, MeasurementUnit measurementUnit, Formula formula)
        { 
            if (coordinates.StartLat == coordinates.DestinationLat && coordinates.StartLong == coordinates.DestinationLong)
              return $"0 {measurementUnit}";
            
            return _formulas.FirstOrDefault(f => f.Formula == formula)
                     ?.CalculateDistance(coordinates, measurementUnit) + $" {measurementUnit}"?? throw new ArgumentNullException(nameof(formula));
        }
    }
}
