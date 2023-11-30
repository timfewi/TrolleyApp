using System.ComponentModel.DataAnnotations;

namespace Trolley.API.Utils
{
    public class RandomPriceGenerator
    {
        private Random _random;

        public RandomPriceGenerator()
        {
            _random = new Random();
        }

        public double GenerateRandomPrice(double min, double max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min value cannot be greater than max value");
            }

            double range = max - min;
            double randomNumber = _random.NextDouble() * range + min;
            double floorNumber = Math.Floor(randomNumber * 10) / 10;
            return floorNumber + 0.09;
        }
    }
}
