/*
    SUT = System Under Test 
    Mocks<> works with Interfaces else there is nothing you need to mock.
 */

using CarsAPI.Classes;
using System;
using Xunit;
using Xunit.Abstractions;
using Moq;
using CarsAPI.Classes.Evaluators;
using System.Collections.Generic;

namespace Cars.Tests
{
    [Trait("Car Class", "Objects")]
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
        public void Car_CarBrandIsRequired()
        {
            // Arrange
            var sut = _carFixture.Car;
            sut.Brand = null;

            // Act

            // Assert
            Assert.True(string.IsNullOrEmpty(sut.Brand));
        }

        [Theory]
        [InlineData("21-SV")]
        [InlineData("21")]
        [InlineData(null)]
        public void Car_IsValidLicensePlateNr_Invalid(string licensePlateNr)
        {
            // Arrange
            var carValidatorService = new CarValidatorService();
            var sut = _carFixture.Car = new Car(carValidatorService); // We going to test IsValidLicensePlateNr();
            sut.Brand = "Peugeot 307";
            sut.LicensePlateNr = licensePlateNr;
            sut.FuelType = FuelType.Gasoline;
            sut.CarType = CarType.Hatchback;
            sut.IsFirstOwner = true;
            sut.ConstructionYear = DateTime.Now;

            // Act

            // Assert
            Assert.Throws<FormatException>(() => sut.IsValidLicensePlateNr());
        }

        [Theory]
        [InlineData("21-SV-ZV")]
        [InlineData("21-SV-ZV-XX")]
        [InlineData("21-SV-ZV-XX-XX-XX")]
        public void Car_IsValidLicensePlateNr_Valid(string licensePlateNr)
        {
            // Arrange
            var carValidatorService = new CarValidatorService();
            var sut = _carFixture.Car = new Car(carValidatorService); // We going to test IsValidLicensePlateNr();
            sut.Brand = "Peugeot 307";
            sut.LicensePlateNr = licensePlateNr;
            sut.FuelType = FuelType.Gasoline;
            sut.CarType = CarType.Hatchback;
            sut.IsFirstOwner = true;
            sut.ConstructionYear = DateTime.Now;

            // Act
            bool result = sut.IsValidLicensePlateNr();

            // Assert
            Assert.True(result);
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
        
        [Fact(Skip = "Reason: Example of Ignoring Tests")]
        public void SkippedTestExample()
        {
            // Skipped Test
        }

        [Theory]
        [InlineData("Example1", "Example 2")]
        public void MultipleTestsCombinedExample(string example, string expectedExample)
        {
            // Arrange
            // sut.DoSomething(example)
            // Act

            // Assert
            // Assert.Equal(expectedExample, example)
        }

    }
}
