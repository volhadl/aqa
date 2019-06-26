using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class DBOWorker
    {


        public static void DBOConnect()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection open");

                    // Connection Info
                    Console.WriteLine("Connection settings:");
                    Console.WriteLine("\tConnection string: {0}", connection.ConnectionString);
                    Console.WriteLine("\tDataBase: {0}", connection.Database);
                    Console.WriteLine("\tServer: {0}", connection.DataSource);
                    Console.WriteLine("\tServerVersion: {0}", connection.ServerVersion);
                    Console.WriteLine("\tState: {0}", connection.State);
                    Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
                }

                Console.WriteLine("Connection closed... Press Enter");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void GetCar()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SqlStatements.SelectCar, connection);
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Somthing went wrong..." + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Operation finished - Connection closed");
            }
        }

        public static void CarDelete()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SqlStatements.DeleteDefaultCar, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Operation finished - Connection closed");
            }
        }

        public static void CarInsert()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SqlStatements.InsertDefaultCar, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Somthing went wrong..." + ex);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Operation finished - Connection closed");
            }
        }

        public static void CarPriceUpdate()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(SqlStatements.UpdateCarPrice, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Somthing went wrong...\n" + ex);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Operation finished - Connection closed");
            }
        }

        public static void AddCar(int carIDSQL, string brandSQL, int yearSQL, decimal fuelConsumptionSQL, decimal startPriceSQL)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            string sqlExpression = "CreateDefaultCar";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@CarID",
                    Value = carIDSQL
                };
                command.Parameters.Add(idParam);

                SqlParameter brandParam = new SqlParameter
                {
                    ParameterName = "@Brand",
                    Value = brandSQL
                };
                command.Parameters.Add(brandParam);

                SqlParameter yearParam = new SqlParameter
                {
                    ParameterName = "@Year",
                    Value = yearSQL
                };
                command.Parameters.Add(yearParam);

                SqlParameter fuelParam = new SqlParameter
                {
                    ParameterName = "@FuelConsumption",
                    Value = fuelConsumptionSQL
                };
                command.Parameters.Add(fuelParam);

                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@StartPrice",
                    Value = startPriceSQL
                };
                command.Parameters.Add(priceParam);

                var result = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Somthing went wrong...\n" + ex);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Operation finished - Connection closed");
            }


        }

        public static void SqlInsertMenu()
        {
            try
            {

                    Console.Write("Write Car ID:");
                    int carIDSQL = Int32.Parse(Console.ReadLine());

                    Console.Write("Write Brand:");
                    string brandSQL = Console.ReadLine();

                    Console.Write("Write Production Year:");
                    int yearSQL = Int32.Parse(Console.ReadLine());

                    Console.Write("Write Fuel Consumption:");
                    decimal fuelConsumptionSQL = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Write Car Cost:");
                    decimal startPriceSQL = Convert.ToDecimal(Console.ReadLine());
                    AddCar(carIDSQL, brandSQL, yearSQL, fuelConsumptionSQL, startPriceSQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data was intered in incorrect format, please try again!\n" + ex);
            }
            
        }
    }
}

