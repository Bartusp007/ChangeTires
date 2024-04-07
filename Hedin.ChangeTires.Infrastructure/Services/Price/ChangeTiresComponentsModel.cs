namespace Hedin.ChangeTires.Infrastructure.Services.Price
{
    public class ChangeTiresComponentsModel
    {
        private ChangeTiresComponentsModel(string carType, int tireSize, bool includeWheelAlignment)
        {
            CarType = carType;
            TireSize = tireSize;
            IncludeWheelAlignment = includeWheelAlignment;
        }

        public string CarType { get; private set; }
        public int TireSize { get; private set; }
        public bool IncludeWheelAlignment { get; private set; }

        public static ChangeTiresComponentsModel Create(string carType, int tireSize, bool includeWheelAlignment)
                => new ChangeTiresComponentsModel(carType, tireSize, includeWheelAlignment);
    }
}
