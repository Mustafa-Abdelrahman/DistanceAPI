using DistanceCalculator.Application.Strategies.Contracts;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Application.Strategies
{
    /// <summary>
    /// This class applies Pythagorean Theorem to calculate the horizontal distance between two points on a Cartesian Plain.
    /// </summary>
    public class PythagoreanDistanceStrategy : IDistanceFormulaStrategy
    {
        /// <summary>
        /// Strategy calculation formula type
        /// </summary>
        public Formula Formula => Formula.Pythagoras;

        /// <summary>
        /// Returns the distance between two points by applying the Pythagorean Theorem
        /// </summary>
        /// <param name="x">Point X</param>
        /// <param name="y"> Point Y</param>
        /// <param name="unit">Measrement Unit</param>
        /// <returns></returns>
        public double CalculateDistance(Coordinates coordinates, MeasurementUnit measurementUnit)
        {
            double eastToWest = (coordinates.StartLong - coordinates.DestinationLong);

            double northToSouth = coordinates.StartLat - coordinates.DestinationLat ;

            double distance = Math.Sqrt(Math.Pow(eastToWest,2) + Math.Pow(northToSouth,2));

            distance = (measurementUnit == MeasurementUnit.Kilometers) ? distance * 111.18 : distance * 69.09;

            return Math.Round(distance, 2);
        }
    }
}
