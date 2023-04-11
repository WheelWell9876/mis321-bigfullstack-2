using Bigproject.Models;
using Bigproject.DataAccess;

namespace Bigproject.Handler
{
    public class GasCarHandler
    {
        public static List<Gas_Car> allGasCars = new List<Gas_Car>();

        public GasCarHandler()
        {

        }

        public List<Gas_Car> GetAllGasCars()
        {
            return allGasCars;
        }

        public void AddGasCar(Gas_Car newGasCar)
        {
            SaveGasCar saveGasCar = new SaveGasCar();
            saveGasCar.CreateGasCar(newGasCar);
            allGasCars.Add(newGasCar);
        }

        public void EditGasCar(string id, Gas_Car editGasCar)
        {
            int index = allGasCars.FindIndex(s => s.GasCarId == id);
            allGasCars.RemoveAt(index);

            SaveGasCar saveGasCar = new SaveGasCar();
            saveGasCar.UpdateGasCar(editGasCar);
            allGasCars.Add(editGasCar);
        }

        public void DeleteGasCar(string id)
        {
            int index = allGasCars.FindIndex(s => s.GasCarId == id);
            allGasCars.RemoveAt(index);

            DeleteGasCar deleteGasCar = new DeleteGasCar();
            deleteGasCar.DeleteGasCarByID(id);
        }
    }
}