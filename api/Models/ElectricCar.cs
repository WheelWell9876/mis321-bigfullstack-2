using Bigproject.DataAccess;
using Bigproject.Interfaces;


namespace Bigproject.Models
{
    public class Electric_Car
    {
        public string ElectricCarId {get; set;}
        public string Make {get; set;}
        public string Model {get; set;}
        public int Year {get; set;}
        public int Range {get; set;}
        public double Price {get; set;}
        public double KWH {get; set;}
        public string AddOn {get; set;}

        public ISaveElectricCar SaveElectricCar {get; set;}

        public Electric_Car()
        {
            ElectricCarId = Guid.NewGuid().ToString();
            SaveElectricCar = new SaveElectricCar();
        }

        public override string ToString()
        {
            return $"{Make} {Model} {Year} {Range} {Price} {KWH} {AddOn}";
        }
    }
}