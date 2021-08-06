using CarsAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI.Contracts
{
    public interface ICarsController
    {
        IEnumerable<Car> GetAll();
        Car GetCarById(int Id);
    }
}
