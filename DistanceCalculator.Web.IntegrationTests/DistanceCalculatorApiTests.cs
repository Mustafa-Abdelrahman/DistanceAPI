using DistanceCalculator.Core.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace DistanceCalculator.Web.IntegrationTests
{
    public class DistanceCalculatorApiTests
    {
        private readonly WebApplicationFactory<Program> _webAppFactory = new WebApplicationFactory<Program>();
        private readonly HttpClient _httpClient;
        private readonly Coordinates _coords;
        public DistanceCalculatorApiTests()
        {
            this._httpClient = _webAppFactory.CreateDefaultClient();
            this._coords = new Coordinates() { StartLat = 53.297975, StartLong = -6.372663, DestinationLat = 41.385101, DestinationLong = -81.440440 };
        }

        #region Sending Correct inputs
       
        [Fact]
        public async void GetSphericalDistanceInKM_ReturnsAccurateSphericalDistanceInKM()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/spherical/km?StartLat={_coords.StartLat}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("5536.34 Kilometers", result);
        }


        [Fact]
        public async void GetSphericalDistanceInMiles_ReturnsOK_ReturnsAccurateSphericalDistanceInMiles()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/spherical/miles?StartLat={_coords.StartLat}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("3439.46 Miles", result);
        }

        [Fact]
        public async void GetHorizontalDistanceInKM_ReturnsAccurateSphericalDistanceInKM()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/horizontal/km?StartLat={_coords.StartLat}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("8450.48 Kilometers", result);
        }

        [Fact]
        public async void GetHorizontalDistanceInMiles_ReturnsAccurateSphericalDistanceInMiles()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/horizontal/miles?StartLat={_coords.StartLat}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("5251.33 Miles", result);
        }
        #endregion

        #region Sending Faulty Coordinates
        [Fact]
        public void GetSphericalDistanceInKM_ReturnsBadRequest()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/spherical/km?StartLat={_coords.StartLat + "abc"}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

      
      
        [Fact]
        public void GetSphericalDistanceInMiles_ReturnsBadRequest()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/spherical/miles?StartLat={_coords.StartLat + "abc"}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");

            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public void GetHorizontalDistanceInKM_ReturnsBadRequest()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/horizontal/km?StartLat={_coords.StartLat + "abc"}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");

            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public void GetHorizontalDistanceInMiles_ReturnsBadRequest()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/horizontal/miles?StartLat={_coords.StartLat + "abc"}&StartLong={_coords.StartLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.BadRequest);

        }
        #endregion

        #region Sending Same Coordinates

        [Fact]
        public async void GetSphericalDistanceInKM_ReturnsOK_ReturnsZeroKM()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/spherical/km?StartLat={_coords.StartLat}&StartLong={_coords.StartLong}&DestinationLat={_coords.StartLat}&DestinationLong={_coords.StartLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("0 Kilometers", result);
        }


        [Fact]
        public async void GetSphericalDistanceInMiles_ReturnsOK_ReturnsZeroMiles()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/spherical/miles?StartLat={_coords.DestinationLat}&StartLong={_coords.DestinationLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("0 Miles", result);
        }

        [Fact]
        public async void GetHorizontalDistanceInKM_ReturnsOK_ReturnsZeroKM()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/horizontal/km?StartLat={_coords.DestinationLat}&StartLong={_coords.DestinationLong}&DestinationLat={_coords.DestinationLat}&DestinationLong={_coords.DestinationLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("0 Kilometers", result);
        }

        [Fact]
        public async void GetHorizontalDistanceInMiles_ReturnsOK_ReturnsZeroMiles()
        {
            var response = _httpClient
                .GetAsync($"/api/DistanceCalculator/horizontal/miles?StartLat={_coords.StartLat}&StartLong={_coords.StartLong}&DestinationLat={_coords.StartLat}&DestinationLong={_coords.StartLong}");
            var result = await response.Result.Content.ReadAsStringAsync();
            Assert.True(response.Result.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.Equal("0 Miles", result);
        }
        #endregion
    }
}
