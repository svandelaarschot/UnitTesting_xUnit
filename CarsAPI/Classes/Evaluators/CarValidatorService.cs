using System;
using System.Collections.Generic;
using System.Text;

namespace CarsAPI.Classes.Evaluators
{
    public class CarValidatorService : ICarValidator
    {
        public bool IsValidLicensePlateNr(string licensePlateNr)
        {
            if(string.IsNullOrEmpty(licensePlateNr))
            {
                throw new FormatException($"LicensePlateNr cannot be empty.");
            }

            if (licensePlateNr.Length < 8)
            {
                throw new FormatException($"LicensePlateNr must be atleast 8 characters long.");    
            }

            return true;
        }
    }
}
