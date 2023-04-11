using Bigproject.DataAccess;
using Bigproject.Interfaces;


namespace Bigproject.Models
{
    public class Gas_Car
    {
        public string GasCarId {get; set;}
        public string Make {get; set;}
        public string Model {get; set;}
        public int Year {get; set;}
        public int Range {get; set;}
        public double Price {get; set;}
        public double MPG {get; set;}
        public string AddOn {get; set;}

        public ISaveGasCar SaveGasCar {get; set;}

        public Gas_Car()
        {
            GasCarId = Guid.NewGuid().ToString();
            SaveGasCar = new SaveGasCar();
        }

        public override string ToString()
        {
            return $"{Make} {Model} {Year} {Range} {Price} {MPG} {AddOn}";
        }
    }
}