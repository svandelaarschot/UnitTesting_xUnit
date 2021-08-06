using CarsAPI;
using CarsAPI.Classes;
using CarsAPI.Contracts;
using CarsAPI.Controllers;
using CarsAPI.Repository;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Cars.Tests
{
    [Trait("CarsController", "Tests")]
    public class CarsControllerTests :  IClassFixture<CarFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly CarFixture _carFixture;
        private readonly Mock<ILogger<CarsController>> _mockedLogger;
        private readonly CarsController _carsController;

        public CarsControllerTests(ITestOutputHelper output, CarFixture carFixture)
        {
            _output = output;
            _carFixture = carFixture;
            _mockedLogger = new Mock<ILogger<CarsController>>();
            _carsController = new CarsController(_mockedLogger.Object, new CarsRepository());
        }

        [Fact]
        public void CarsController_GetAllCars()
        {
            // Arrange

            // Act
            var actualCars = _carsController.GetAll();

            _output.WriteLine($"We found car(s):");
            _output.WriteLine($"--------------------------------");

            foreach (var item in actualCars)
            {
                _output.WriteLine($"- Id ({item.Id})");
                _output.WriteLine($"- Brand ({item.Brand})");
                _output.WriteLine($"--------------------------------");
            }

            // Assert
            Assert.IsType<List<Car>>(actualCars);
            Assert.NotEmpty(actualCars);
        }

        [Fact]
        public void CarsController_GetCarById()
        {
            // Arrange
            var carId = 1;

            // Act
            var actualCar = _carsController.GetCarById(carId);

            _output.WriteLine($"We found car:");
            _output.WriteLine($"--------------------------------");
            _output.WriteLine($"- Id ({actualCar.Id})");
            _output.WriteLine($"- Brand ({actualCar.Brand})");
            _output.WriteLine($"--------------------------------");

            // Assert
            Assert.IsType<Car>(actualCar);
            Assert.NotNull(actualCar);
            Assert.Equal(carId, actualCar.Id);
        }

    }
}
