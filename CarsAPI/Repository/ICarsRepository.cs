using CarsAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI
{
    public interface ICarsRepository
    {
        List<Car> GetAll();
        Car GetCarById(int id);
    }
}
