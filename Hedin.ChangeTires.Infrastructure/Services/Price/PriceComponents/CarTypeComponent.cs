using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedin.ChangeTires.Infrastructure.Services.Price.PriceComponents
{
    public class CarTypeComponent : BaseComponent
    {
        public override bool IncludeComponentPrice(ChangeTiresComponentsModel changeTiresComponentsModel) => true;
        public override decimal GetComponentAmount(ChangeTiresComponentsModel changeTiresComponentsModel)
        {
            if (changeTiresComponentsModel.CarType == "Sedan")
            {
                return 100;
            }
            else if (changeTiresComponentsModel.CarType == "SUV")
            {
                return 120;
            }
            else if (changeTiresComponentsModel.CarType == "Truck")
            {
                return 150;
            }
            else
            {
                return 90;
            }
        }
    }
}
