using System;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    [XmlInclude(typeof(LightCar))]
    [XmlInclude(typeof(CargoCar))]
    [XmlRoot("carPark", Namespace = "http://lol.by/catalog")]
    public abstract class Car
    {
        public Car() { }

        public Car(
            int id,
            string brand,
            int year,
            decimal fuelConsumption,
            decimal startPrice)
        {
            Id = id;
            Brand = brand;
            Year = year;
            FuelConsumption = fuelConsumption;
            StartPrice = startPrice;
        }
        [XmlAttribute("id")]
        public int Id { get; set; }
        
        [XmlElement("brand")]
        public string Brand { get; set; }
        
        [XmlElement("year")]
        public int Year { get; set; }

        [XmlElement("fuelConsumption")]
        public decimal FuelConsumption { get; set; }

        [XmlElement("startPrice")]
        public decimal StartPrice { get; set; }
    }
}

