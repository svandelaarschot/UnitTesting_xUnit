/*
    SUT = System Under Test 
*/

using CarsAPI.Classes;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Cars.Tests
{
    [CollectionDefinition("CarFixture collection")]
    public class CarTests : IClassFixture<CarFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly CarFixture _carFixture;

        public CarTests(ITestOutputHelper output, CarFixture carFixture)
        {
            _output = output;
            _carFixture = carFixture;
        }


        [Fact]
        public void Car_IsInvalid_WithoutLicensePlateOrBrand()
        {
            // Arrange
            var sut = _carFixture.Car;
            sut.Brand = null;
            sut.FuelType = FuelType.Electric;
            sut.CarType = CarType.Electric;
            sut.IsFirstOwner = true;
            sut.LicensePlateNr = null;
            sut.ConstructionYear = DateTime.Now;

            // Act
            bool result = sut.IsValid();
            
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Car_CalculateCarName()
        {
            // Arrange
            var sut = _carFixture.Car;
            sut.Brand = "Seat";
            sut.FuelType = FuelType.Gasoline;
            sut.CarType = CarType.Hatchback;
            sut.IsFirstOwner = true;
            sut.LicensePlateNr = "21-SV-ZV";
            sut.ConstructionYear = DateTime.Now;

            // Act

            // Assert
            Assert.Equal("Seat Hatchback Gasoline", sut.CarName, ignoreCase: true);
        }
    }
}
