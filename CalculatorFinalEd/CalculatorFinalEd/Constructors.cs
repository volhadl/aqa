using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorFinalEd
{
    public class Operands
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public abstract string Label { get; set; }
        public double Result { get; set; }
        public int[,] Matrix1 { get; set; }
        public int[,] Matrix2 { get; set; }
        public int[,] MatrixResult { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public string name { get; set; }
        public double BMI { get; set; }

        public static List<Operands> history = new List<Operands>();
        public Operands(string name, double weight, double height, double BMI)
        {

            this.name = name;
            this.weight = weight;
            this.height = height;
            this.BMI = BMI;
            history.Add(this);

        }
        public Operands()
        {

            this.name = name;
            this.weight = weight;
            this.height = height;
            this.BMI = BMI;
            history.Add(this);

        }
    }

        public abstract class Operands
    {
        public double Operand1 { get; set; }
        public double Operand2 { get; set; }
        public abstract string Label { get; set; }
        public double Result { get; set; }
        public int[,] Matrix1 { get; set; }
        public int[,] Matrix2 { get; set; }
        public int[,] MatrixResult { get; set; }

        public Operands() { }

    public Operands(
        double operand1,
        string label,
        double operand2,
        double result
        )
        
        {
            Operand1 = operand1;
            Label = label;
            Operand2 = operand2;
            Result = result;
        }
        
    }
    public class Num : Operands
    {
        public Num()
        {

        }

        public CargoCar(int id, string brand, int year, decimal fuelConsumption, decimal startPrice, decimal weight) : base(id, brand, year, fuelConsumption, startPrice)
        {
            Weight = weight;
        }
        [XmlElement("weight")]
        public decimal Weight { get; set; }
    }

    private CarPark GetDefaultCarPark()
    {
        var carPark = new CarPark();

        carPark.Cars.Add(new LightCar(1, "BMW", 2011, 6.3m, 18000, 4));
        carPark.Cars.Add(new LightCar(2, "BMW", 2016, 4.7m, 2800, 4));
        carPark.Cars.Add(new LightCar(3, "Audi", 2008, 4.0m, 12000, 4));
        carPark.Cars.Add(new LightCar(4, "Renault", 2014, 3.7m, 1200, 4));
        carPark.Cars.Add(new LightCar(5, "Lada", 2016, 4.2m, 12000, 4));
        carPark.Cars.Add(new LightCar(6, "Volkswagen", 2004, 8m, 19000, 8));
        carPark.Cars.Add(new LightCar(7, "Lada", 2002, 6.3m, 6000, 4));
        carPark.Cars.Add(new LightCar(8, "Volkswagen", 2011, 6.3m, 18000, 4));
        carPark.Cars.Add(new LightCar(9, "Renault", 2011, 6.3m, 18000, 4));
        carPark.Cars.Add(new LightCar(10, "Volvo", 2016, 6.3m, 23000, 4));
        carPark.Cars.Add(new CargoCar(11, "BMW", 2011, 6.3m, 18000, 1200));
        carPark.Cars.Add(new CargoCar(12, "Volvo", 2010, 8m, 14000, 3800));
        carPark.Cars.Add(new CargoCar(13, "Mercedes", 2012, 5.6m, 16500, 3200));

        return carPark;
    }

    public void ShowTable(IEnumerable<Car> cars)
    {
        var builder = new StringBuilder();

        foreach (var item in cars)
        {
            builder.AppendLine($"ID:{item.Id} Brand: {item.Brand} Production year: {item.Year} Fuel Consumption: {item.FuelConsumption} Price: {item.StartPrice}");
        }

        Write(builder.ToString());
    }
}
