using CarsAPI.Classes;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Cars.Tests
{
    [Trait("CarDealer Class", "Objects")]
    [CollectionDefinition("CarFixture collection")]
    public class CarDealerTests : IClassFixture<CarFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly CarFixture _carFixture;

        public CarDealerTests(ITestOutputHelper output, CarFixture carFixture)
        {
            _output = output;
            _carFixture = carFixture;
        }

        [Fact]
        public void CarDealer_DealerNameIsRequired()
        {
            // Arrange
            var sut = _carFixture.CardDealer;
            sut.DealerName = null;

            // Act

            // Assert
            Assert.True(string.IsNullOrEmpty(sut.DealerName));
        }

        [Fact]
        public void CarDealer_HasUnSupportedCars()
        {
            // Arrange
            var stockedCars = new List<Car>()
            {
                new Car()
                {
                    Brand = "Peugeut 206",
                    CarType = CarType.SUV,
                    ConstructionYear = DateTime.Now,
                    FuelType = FuelType.Gasoline,
                    IsFirstOwner = true,
                    LicensePlateNr = "UNKOWN"
                },
                new Car()
                {
                    Brand = "Peugeut 108",
                    CarType = CarType.Small,
                    ConstructionYear = DateTime.Now,
                    FuelType = FuelType.Gasoline,
                    IsFirstOwner = true,
                    LicensePlateNr = "UNKOWN"
                },
                new Car()
                {
                    Brand = "Peugeut 2008",
                    CarType = CarType.Electric,
                    ConstructionYear = DateTime.Now,
                    FuelType = FuelType.Electric,
                    IsFirstOwner = true,
                    LicensePlateNr = "UNKOWN"
                }
            };

            var supportedCarTypes = new List<CarType>()
            {
                CarType.Electric,
                CarType.Sport,
            };

            // Act
            var sut = _carFixture.CardDealer;
            sut.DealerName = "Welling";
            sut.SupportedCarTypes = supportedCarTypes;
            sut.AvailableCars = stockedCars;

            var unSupportedCars = new List<Car>();
            var hasUnSupportedCars = sut.HasUnSupportedCars(out unSupportedCars);

            // Logging
            _output.WriteLine($"Welcome to {sut.DealerName}");
            _output.WriteLine($"\nWe have expertise with: \n- {string.Join("\n- ", sut.SupportedCarTypes)}");
            _output.WriteLine($"\nCars found:\n- { string.Join("\n- ", stockedCars.Where(x => sut.SupportedCarTypes.Contains(x.CarType)).Select(x => x.CarName + $" supported Type: ({x.CarType})"))}");
            _output.WriteLine($"\nCars found we don't have expertise with:\n- { string.Join("\n- ", unSupportedCars.Select(x => x.CarName + $" Unsupported Type: ({x.CarType})"))}");
            
            // Assert
            Assert.True(hasUnSupportedCars);
        }
    }
}
