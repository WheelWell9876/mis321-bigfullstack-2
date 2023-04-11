using Bigproject.Models;

namespace Bigproject.Interfaces
{
    public interface ISaveElectricCar
    {
        public void CreateElectricCar(Electric_Car myElectricCar);
        public void SaveElectricCar(Electric_Car myElectricCar);
    }
}