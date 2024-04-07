namespace Hedin.ChangeTires.Infrastructure.Services.Price.PriceComponents
{
    public abstract class BaseComponent
    {
        public virtual bool IncludeComponentPrice(ChangeTiresComponentsModel changeTiresComponentsModel) => false;

        public abstract decimal GetComponentAmount(ChangeTiresComponentsModel changeTiresComponentsModel);
      }
}
