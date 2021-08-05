using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAPI.Classes
{
    public class CarDealer : IDisposable
    {
        [Required]
        public string DealerName { get; set; }
        public List<Car> AvailableCars { get; set; }

        public List<CarType> SupportedCarTypes { get; set; }

        public bool HasUnSupportedCars(out List<Car> unSupportedCars)
        {
            unSupportedCars = AvailableCars.Where(x => !SupportedCarTypes.Contains(x.CarType)).ToList();
            return AvailableCars.Select(x => x.CarType).Any(x => !SupportedCarTypes.Contains(x));
        }

        public void Dispose()
        {

        }

        public CarDealer() { }

        public CarDealer(string dealerName, List<Car> availableCars, List<CarType> supportedCars) 
        {
            DealerName = dealerName;
            AvailableCars = availableCars;
            SupportedCarTypes = supportedCars;
        }
    }
}
