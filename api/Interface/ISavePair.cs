using Bigproject.Models;

namespace Bigproject.Interfaces
{
    public interface ISaveCarPair
    {
        public void CreatePair(CarPair myPair);
        public void SavePair(CarPair myPair);
    }
}