using System;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class CargoCar : Car
    {
        public CargoCar()
        {

        }

        public CargoCar(int id, string brand, int year, decimal fuelConsumption, decimal startPrice, decimal weight) : base(id, brand, year, fuelConsumption, startPrice)
        {
            Weight = weight;
        }
        [XmlElement("weight")]
        public decimal Weight { get; set; }
    }
}
