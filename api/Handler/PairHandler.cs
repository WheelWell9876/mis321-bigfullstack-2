using Bigproject.Models;
using Bigproject.DataAccess;
using System.Collections.Generic;

namespace Bigproject.Handler
{
    public class CarPairHandler
    {
        public static List<CarPair> allCarPairs = new List<CarPair>();

        public CarPairHandler()
        {

        }

        public List<CarPair> GetAllCarPairs()
        {
            return allCarPairs;
        }

        public void AddCarPair(CarPair newCarPair)
        {
            SaveCarPair saveCarPair = new SaveCarPair();
            saveCarPair.SavePair(newCarPair);
            allCarPairs.Add(newCarPair);
        }

        public void EditCarPair(string id, CarPair editCarPair)
        {
            int index = allCarPairs.FindIndex(s => s.PairId == id);
            allCarPairs.RemoveAt(index);

            SaveCarPair saveCarPair = new SaveCarPair();
            saveCarPair.UpdateCarPair(editCarPair);
            allCarPairs.Add(editCarPair);
        }

        public void DeleteCarPair(string id)
        {
            int index = allCarPairs.FindIndex(s => s.PairId == id);
            allCarPairs.RemoveAt(index);

            DeleteCarPair deleteCarPair = new DeleteCarPair();
            deleteCarPair.DeleteCarPairByID(id);
        }
    }
}