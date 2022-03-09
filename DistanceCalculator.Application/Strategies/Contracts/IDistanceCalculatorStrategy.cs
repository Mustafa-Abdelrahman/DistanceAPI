using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Application.Strategies.Contracts
{
    public interface IDistanceCalculatorStrategy
    {
        string CalculateDistance(Coordinates coordinates, MeasurementUnit measurementUnit, Formula formula );
    }
}
