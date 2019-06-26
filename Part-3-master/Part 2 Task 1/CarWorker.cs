using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    public class CarWorker
    {
        private readonly IoManager _ioManager = new IoManager();

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

        private void ShowSerchResultByYear(IEnumerable<Car> cars)
        {
                _ioManager.WriteStepMessage("Enter year from:");
                int yearCreteriaOne = int.Parse(_ioManager.Read());
                _ioManager.WriteStepMessage("Enter year to:");
                int yearCreteriaTwo = int.Parse(_ioManager.Read());

                _ioManager.WriteStepMessage($"Search result by Production Year: from {yearCreteriaOne} to {yearCreteriaTwo}");
                _ioManager.ShowTable(cars.Where(x => x.Year <= yearCreteriaTwo && x.Year >= yearCreteriaOne));          
        }

        public void ParkMenu()
        {
            var parkIoManager = new IoManager();

            try
            {
                var carPark = GetDefaultCarPark();

                parkIoManager.WriteStepMessage("Park Menu");
                parkIoManager.ParkMenu();
                while (true)
                {
                    string menuStepResp = parkIoManager.ReadMenuStep();
                    parkIoManager.Write(menuStepResp);

                    if (menuStepResp == "CREATE")
                    {
                        parkIoManager.WriteStepMessage("Taxi park is created:");
                        parkIoManager.ShowTable(carPark.Cars);
                    }
                    else if (menuStepResp == "PRICE")
                    {
                        parkIoManager.WriteStepMessage("Car park price:");
                        parkIoManager.WritePrice(carPark.GetPrice());
                    }
                    else if (menuStepResp == "SORT")
                    {
                        parkIoManager.WriteStepMessage("Cars sorted by Fuel Consumption:");
                        parkIoManager.ShowTable(carPark.Cars.OrderBy(car => car.FuelConsumption));
                    }
                    else if (menuStepResp == "SEARCH")
                    {
                        ShowSerchResultByYear(carPark.Cars);
                    }
                    else if (menuStepResp == "SAVEBIN")
                    {
                        ReadWriteDataManager.SerializeBin(carPark.Cars);
                    }
                    else if (menuStepResp == "OPENBIN")
                    {
                        if(!File.Exists(@"D:\\lol.xml"))
                        {
                            throw new OpenFileException("File doesn't exist...");
                        }
                        ReadWriteDataManager.DeserializeBin();
                    }
                    else if (menuStepResp == "XML")
                    {
                        parkIoManager.WriteStepMessage("XML fail is created:");
                        ReadWriteDataManager.SerializeXml(carPark);
                    }
                    else if (menuStepResp == "OPENXML")
                    {
                        if (!File.Exists(@"D:\\lol.xml"))
                        {
                            throw new OpenFileException("File doesn't exist...");
                        }

                        var result = ReadWriteDataManager.DeserializeXml();
                        parkIoManager.ShowTable(result.Cars);
                    }
                    else if (menuStepResp == "EXIT")
                    {
                        break;
                    }
                    else
                    {
                        parkIoManager.Write("There is no such command... Try again or write EXITE for return to Main menu. ");
                    }
                }
            }
            catch (Exception ex)
            {
                parkIoManager.Write("Somthing went wrong...\n" + ex);
            }
        }

        public class OpenFileException : Exception
        {
            public OpenFileException(string message)
            : base(message)
            { }
        }
    }
}
