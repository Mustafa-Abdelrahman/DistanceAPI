using DistanceCalculator.Application.Strategies.Contracts;
using DistanceCalculator.Core.Entities;
using DistanceCalculator.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DistanceCalculator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceCalculatorController : ControllerBase
    {
        private readonly IDistanceCalculatorStrategy _calculatorStrategy;

        public DistanceCalculatorController(IDistanceCalculatorStrategy calculatorStrategy)
        {
            _calculatorStrategy = calculatorStrategy;
        }

        [HttpGet]
        [Route("spherical/km")]
        public IActionResult GetSphericalDistanceInKM([FromQuery] Coordinates coordinates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var distance = this._calculatorStrategy.CalculateDistance(coordinates, MeasurementUnit.Kilometers, Formula.LawOfCosines);
            return  Ok(distance);
        }

        [HttpGet]
        [Route("spherical/miles")]
        public IActionResult GetSphericalDistanceInMiles([FromQuery] Coordinates coordinates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var distance = this._calculatorStrategy.CalculateDistance(coordinates, MeasurementUnit.Miles, Formula.LawOfCosines);
            return Ok(distance); 
        }


        [HttpGet]
        [Route("horizontal/km")]
        public IActionResult GetHorizontalDistanceInKM([FromQuery] Coordinates coordinates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var distance = this._calculatorStrategy.CalculateDistance(coordinates, MeasurementUnit.Kilometers, Formula.Pythagoras);
            return Ok(distance);
        }

        [HttpGet]   
        [Route("horizontal/miles")]
        public IActionResult GetHorizontalDistanceInMiles([FromQuery] Coordinates coordinates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var distance = this._calculatorStrategy.CalculateDistance(coordinates, MeasurementUnit.Miles, Formula.Pythagoras);
            return Ok(distance);
        }

    }
}
