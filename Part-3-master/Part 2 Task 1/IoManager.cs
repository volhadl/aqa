using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    public class IoManager
    {
        private const string tableLine = "-----------------------------------------------------------------------------------";

        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public void WritePrice(object prc)
        {
            Console.WriteLine(prc);
        }

        public string Read()
        {
            return Console.ReadLine();
        }

        public string ReadMenuStep()
        {
            string menuResponseStep = string.Empty;
            menuResponseStep = Console.ReadLine().ToUpper();
            return menuResponseStep;
        }

        public void WriteStepMessage(string msg)
        {
            Console.WriteLine($"{tableLine}{Environment.NewLine}{msg}{Environment.NewLine}{tableLine}");
        }

        public void ExitMessage()
        {
            Console.WriteLine("Press any key to exit...");
        }

        public void DBOSubMenu()
        {
            Console.WriteLine("1. For Add default Car to DataBase write - ADD");
            Console.WriteLine("2. For Delete Car from Data Base write - DELETE");
            Console.WriteLine("3. For Add Cars to Data Base write - CARS");
            Console.WriteLine("4. Select Car from Data Base write - SELECT");
            Console.WriteLine("5. For update Car price write - UPDATE");
            Console.WriteLine("6. Write EXITE for return to Main Menu");
        }

        public void ParkMenu()
        {
            Console.WriteLine("1. For create Car Park with default cars write - CREATE");
            Console.WriteLine("2. For calculate price of Car Park write - PRICE");
            Console.WriteLine("3. For sort cars by Fuel consumption write - SORT");
            Console.WriteLine("4. For search cars by Production year range write - SEARCH");
            Console.WriteLine("5. For save Car Park to DataFail.bin write - SAVEBIN");
            Console.WriteLine("6. For save Car Park to XML file write - XML");
            Console.WriteLine("7. For open DataFail.bin write - OPENBIN");
            Console.WriteLine("8. For open XML file write - OPENXML");
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
}
