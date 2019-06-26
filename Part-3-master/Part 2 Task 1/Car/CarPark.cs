using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class CarPark
    {
        [XmlElement("cars")]
        public List<Car> Cars { get; set; }

        public CarPark()
        {
            Cars = new List<Car>();
        }

        public decimal GetPrice()
        {
            return new ParkPrice().CarParkPrice(Cars);
        }       
    }
}
