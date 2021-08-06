using CarsAPI.Classes.Evaluators;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Classes
{
    public enum FuelType
    {
        Unknown,
        Diesel,
        Gasoline,
        LPG,
        Electric
    }

    public enum CarType
    {
        Unknown,
        SUV,
        Hybrid,
        Electric,
        FourFour,
        Hatchback,
        Small,
        Sport
    }

    public class Car
    {
        private readonly ICarValidator _carValidator;

        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }
        public FuelType FuelType { get; set; } = FuelType.Unknown;
        public CarType CarType { get; set; } = CarType.Unknown;
        public bool IsFirstOwner { get; set; }
        
        [Required]
        public string LicensePlateNr { get; set; }
        public DateTime ConstructionYear { get; set; }
        public string CarName => $"{Brand} {CarType} {FuelType}";
        

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Brand)
                || !string.IsNullOrEmpty(LicensePlateNr);
        }

        public bool IsValidLicensePlateNr()
        {
            return _carValidator.IsValidLicensePlateNr(LicensePlateNr);
        }

        public Car() { }
        public Car(
            string brand,
            FuelType fuelType,
            CarType carType,
            bool isFirstOwner,
            string licensePlateNr,
            DateTime constructionYear)
        {
            Brand = brand;
            FuelType = fuelType;
            CarType = carType;
            IsFirstOwner = isFirstOwner;
            LicensePlateNr = licensePlateNr;
            ConstructionYear = constructionYear;
        }

        public Car(ICarValidator validator) 
        {
            _carValidator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
    }
}
