using System.Collections.Generic;
using System.Linq;
namespace Task1
{
    public class ParkPrice
    {
        public decimal CarParkPrice(IEnumerable<Car> cars)
        {
            return cars != null ? cars.Sum(x => x.StartPrice) : 0;
        }
    }

}
