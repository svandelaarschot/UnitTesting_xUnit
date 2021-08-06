using System;
using System.Collections.Generic;
using System.Text;

namespace CarsAPI.Classes.Evaluators
{
    public interface ICarValidator
    {
        bool IsValidLicensePlateNr(string licensePlateNr);
    }
}
