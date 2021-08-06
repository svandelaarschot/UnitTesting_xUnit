using CarsAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI.Repository
{
    public class CarsRepository : ICarsRepository
    {
        public List<Car> GetAll() => new List<Car>()
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
                    Id = 2,
                    Brand = "Seat",
                    CarType = CarType.Hatchback,
                    ConstructionYear = new DateTime(2008, 8, 5),
                    FuelType = FuelType.Gasoline,
                    IsFirstOwner = false,
                    LicensePlateNr = "33-AG-KL",
                }
            };

        public Car GetCarById(int id) => GetAll().Find(x => x.Id == id);
    }
}
