using Hedin.ChangeTires.Infrastructure.Services.Price.PriceComponents;

namespace Hedin.ChangeTires.Infrastructure.Services.Price
{
    public interface IChangeTirePriceCalculator
    {
        decimal CalculateChangeTireAmount(ChangeTiresComponentsModel model);
    }

    public class ChangeTirePriceCalculator : IChangeTirePriceCalculator
    {
        private readonly IEnumerable<BaseComponent> _priceComponents;

        public ChangeTirePriceCalculator(IEnumerable<BaseComponent> priceComponents)
        {
            _priceComponents = priceComponents;
        }

        public decimal CalculateChangeTireAmount(ChangeTiresComponentsModel model)
        {
            decimal price = 0;

            foreach (var component in _priceComponents)
            {
                if (component.IncludeComponentPrice(model))
                    price += component.GetComponentAmount(model);
            }

            return price;
        }
    }
}
