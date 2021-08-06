using CarsAPI.Classes;
using CarsAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase, ICarsController
    {
        private readonly ILogger<CarsController> _logger;
        private readonly ICarsRepository _carsRepository;

        public CarsController(ILogger<CarsController> logger, ICarsRepository carsRepository)
        {
            _logger = logger;
            _carsRepository = carsRepository; 
        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return _carsRepository.GetAll();
        }

        public Car GetCarById(int id)
        {
            return _carsRepository.GetCarById(id);
        }
    }
}
