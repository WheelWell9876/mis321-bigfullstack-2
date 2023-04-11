using Bigproject.Models;

namespace Bigproject.Interfaces
{
    public interface ISaveGasCar
    {
        public void CreateGasCar(Gas_Car myGasCar);
        public void SaveGasCar(Gas_Car myGasCar);
    }
}