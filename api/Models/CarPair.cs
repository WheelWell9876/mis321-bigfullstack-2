namespace Bigproject.Models
{
    public class CarPair
    {
        public string PairId { get; set; }
        public string GasCarId { get; set; }
        public string ElectricCarId { get; set; }
        public string UserId { get; set; }

        public CarPair()
        {
            PairId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{PairId} {GasCarId} {ElectricCarId} {UserId}";
        }
    }
}