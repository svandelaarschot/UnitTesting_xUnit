using CarsAPI.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return new List<Car>()
            {
                new Car
                {
                    Id = 1,
                    Brand = "Tesla",
                    CarType = CarType.Electric,
                    ConstructionYear = new DateTime(2021, 8, 5),
                    FuelType = FuelType.Electric,
                    IsFirstOwner = true,
                    LicensePlateNr = "21-SV-ZV",
                },
                new Car
                {
                    Id = 1,
                    Brand = "Seat",
                    CarType = CarType.Hatchback,
                    ConstructionYear = new DateTime(2008, 8, 5),
                    FuelType = FuelType.Gasoline,
                    IsFirstOwner = false,
                    LicensePlateNr = "33-AG-KL",
                }
            };
        }
    }
}
