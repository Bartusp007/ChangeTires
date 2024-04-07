using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedin.ChangeTires.Infrastructure.Services.Price.PriceComponents
{
    public class IncludeWheelAlignmentComponent : BaseComponent
    {
        public override bool IncludeComponentPrice(ChangeTiresComponentsModel changeTiresComponentsModel)
        {
            return changeTiresComponentsModel.IncludeWheelAlignment;
        }
        public override decimal GetComponentAmount(ChangeTiresComponentsModel changeTiresComponentsModel)
        {
            return 50;
        }
    }
}
