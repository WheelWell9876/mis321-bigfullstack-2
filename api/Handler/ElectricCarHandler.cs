using Bigproject.Models;
using Bigproject.DataAccess;

namespace Bigproject.Handler
{
    public class ElectricCarHandler
    {
        public static List<Electric_Car> allElectricCars = new List<Electric_Car>();

        public ElectricCarHandler()
        {

        }

        public List<Electric_Car> GetAllElectricCars()
        {
            return allElectricCars;
        }

        public void AddElectricCar(Electric_Car newElectricCar)
        {
            SaveElectricCar saveElectricCar = new SaveElectricCar();
            saveElectricCar.CreateElectricCar(newElectricCar);
            allElectricCars.Add(newElectricCar);
        }

        public void EditElectricCar(string id, Electric_Car editElectricCar)
        {
            int index = allElectricCars.FindIndex(s => s.ElectricCarId == id);
            allElectricCars.RemoveAt(index);

            SaveElectricCar saveElectricCar = new SaveElectricCar();
            saveElectricCar.UpdateElectricCar(editElectricCar);
            allElectricCars.Add(editElectricCar);
        }

        public void DeleteElectricCar(string id)
        {
            int index = allElectricCars.FindIndex(s => s.ElectricCarId == id);
            allElectricCars.RemoveAt(index);

            DeleteElectricCar deleteElectricCar = new DeleteElectricCar();
            deleteElectricCar.DeleteElectricCarByID(id);
        }
    }
}