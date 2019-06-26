using System;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class LightCar : Car
    {
        public LightCar()
        {

        }

        public LightCar(int id, string brand, int year, decimal fuelConsumption, decimal startPrice, int passangerCapacity) : base(id, brand, year, fuelConsumption, startPrice)
        {
            PassangerCapacity = passangerCapacity;
        }
        [XmlElement("passangerCapacity")]
        public int PassangerCapacity { get; set; }
    }
}
