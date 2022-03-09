using DistanceCalculator.Application.Strategies.Contracts;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Application.Strategies
{
    /// <summary>
    /// This class applies Law of Cosines to calculate the distance as a Geodesic Curve considering the earth as a sphere.
    /// </summary>
    public class LawofCosinesDistanceStrategy : IDistanceFormulaStrategy
    {
        /// <summary>
        /// Strategy calculation formula type
        /// </summary>
        public Formula Formula => Formula.LawOfCosines;

        /// <summary>
        /// Returns the distance between two points by applying the Spherical Law of Cosines
        /// </summary>
        /// <param name="x">Point X</param>
        /// <param name="y"> Point Y</param>
        /// <param name="unit">Measrement Unit</param>
        /// <returns></returns>
        public double CalculateDistance(Coordinates coordinates, MeasurementUnit measurementUnit)
        {
            // cos p = (cos A) (cos B) +(sin A) (sin B) cos γ.

            double radianTheta = (Math.PI / 180.0) * (coordinates.DestinationLong - coordinates.StartLong); // γ = theta = angle between the two longs and Earth's north pool

            double radianA = (Math.PI / 180.0) * (90 - coordinates.StartLat);

            double radianB = (Math.PI / 180.0) * (90 - coordinates.DestinationLat);

            double CosineP = Math.Cos(radianA) * Math.Cos(radianB) + Math.Sin(radianA) * Math.Sin(radianB) * Math.Cos(radianTheta);

            // earth raduis in KM = 6371 and = 3958.8 in miles 
            double distance = (measurementUnit == MeasurementUnit.Kilometers) ? Math.Acos(CosineP) * 6371 : Math.Acos(CosineP) * 3958;

            return Math.Round(distance, 2);
        }
    }
}
