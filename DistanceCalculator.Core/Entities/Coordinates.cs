using System.ComponentModel.DataAnnotations;

namespace DistanceCalculator.Core.Entities
{
    public class Coordinates
    {
        [Required]
        public double StartLat { get; set; }

        [Required]
        public double StartLong { get; set; }

        [Required]
        public double DestinationLat { get; set; }

        [Required]
        public double DestinationLong { get; set; }
    }
}