using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedin.ChangeTires.Infrastructure.Services.Price.PriceComponents
{
    public class TireSizeComponent : BaseComponent
    {
        public override bool IncludeComponentPrice(ChangeTiresComponentsModel changeTiresComponentsModel) => true;
        public override decimal GetComponentAmount(ChangeTiresComponentsModel changeTiresComponentsModel)
        {
            if (changeTiresComponentsModel.TireSize <= 16)
            {
                return 20;
            }
            else if (changeTiresComponentsModel.TireSize > 16 && changeTiresComponentsModel.TireSize <= 18)
            {
                return 40;
            }
            else
            {
                return 60;
            }
        }
    }
}
