using System;

namespace Task1
{
    class MenuWorker
    {
        public static void MainMenu()
        {
            var ioManager = new IoManager();

            while (true)
            {
                ioManager.WriteStepMessage("Menu:");
                ioManager.WriteStepMessage("For work with Data base write: DBO");
                ioManager.WriteStepMessage("For work with Taxi Park write: PARK");
                
                string menuResponse = ioManager.ReadMenuStep();

                if (menuResponse == "EXITE")
                {
                    Environment.Exit(0);
                }
                else if (menuResponse == "DBO")
                {
                    ioManager.WriteStepMessage("Connection check:");
                    DBOWorker.DBOConnect();
                    DBOMenu();
                }
                else if (menuResponse == "PARK")
                {
                    try
                    {
                        var worker = new CarWorker();
                        worker.ParkMenu();
                    }
                    catch (Exception ex)
                    {
                        ioManager.Write("Somthing went wrong..." + ex.Message);
                        ioManager.Read();
                    }
                    ioManager.Read();
                }
                else
                {
                    ioManager.WriteStepMessage("There is no such command. Try again or write Exite for close programm");
                }
            }
            
        }

        public static void DBOMenu()
        {
            var dboIoManager = new IoManager();

            dboIoManager.WriteStepMessage("Data Base Menu:");
            dboIoManager.DBOSubMenu();
            while (true)
            {
                string dboMenuResponse = dboIoManager.ReadMenuStep();
                if (dboMenuResponse == "EXITE")
                {
                    dboIoManager.Write("Connection Closed");
                    break;
                }
                else if (dboMenuResponse == "ADD")
                {
                    DBOWorker.CarInsert();
                }
                else if (dboMenuResponse == "DELETE")
                {
                    DBOWorker.CarDelete();
                }
                else if (dboMenuResponse == "CARS")
                {
                    DBOWorker.SqlInsertMenu();
                }
                else if (dboMenuResponse == "SELECT")
                {
                    DBOWorker.GetCar();
                }
                else if (dboMenuResponse == "UPDATE")
                {
                    DBOWorker.CarPriceUpdate();
                }
                else
                {
                    dboIoManager.Write("There is no such command... Try again or write EXITE for return to Main menu. ");
                }
            }
            
        }
    }
}
