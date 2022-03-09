using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Application.Strategies.Contracts
{
    public interface IDistanceFormulaStrategy
    {
        Formula Formula { get; }
        double CalculateDistance (Coordinates coordinates, MeasurementUnit measurementUnit);
    }
}
