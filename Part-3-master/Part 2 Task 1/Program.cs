using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                MenuWorker.MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error:\n" + ex);
            }
        }

    }
}
