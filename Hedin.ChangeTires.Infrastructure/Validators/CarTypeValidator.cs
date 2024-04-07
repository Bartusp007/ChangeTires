using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedin.ChangeTires.Infrastructure.Validators
{
    public interface ICarTypeValidator
    {
        bool VerifyCarTypeCorrectness(string carType);
    }

    public class CarTypeValidator : ICarTypeValidator
    {
        //If number car grow up car type should be moved to some persistant service.
        public bool VerifyCarTypeCorrectness(string carType)
        {
            return carType == "Sedan" || carType == "SUV";
        }
    }
}
 