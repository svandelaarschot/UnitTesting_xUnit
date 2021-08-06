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

        /// <summary>
        /// Mocking Example
        /// </summary>
        [Fact]
        public void Car_IsValidLicensePlateNr()
        {
            // Arrange
            var licensePlateNr = "21-SV-ZV";
            Mock<ICarValidator> mockValidator = new Mock<ICarValidator>();

            // mockValidator.Setup(x => x.IsValidLicensePlateNr(It.IsAny<string>())).Returns(true); 
            
            /*
             [Description]
             So, If u mocking an Function you have to Setup this function and manipulate (It.Is etc) what this function should do.
             so it could be mocked (You code twice). 
             */
            mockValidator.Setup(x => x.IsValidLicensePlateNr(It.Is<string>(licensePlateNr => 
            !string.IsNullOrEmpty(licensePlateNr) && licensePlateNr.Length >= 8))).Returns(true); 

            var sut = _carFixture.Car = new Car(mockValidator.Object);
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
