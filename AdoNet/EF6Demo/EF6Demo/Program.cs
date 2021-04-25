using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace EF6Demo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "server=localhost;port=3306;" +
                                      "user id=root;database=testdatabase;" +
                                      "password=xf716924;characterset=utf8;sslmode=none;";
            
            GetSalesByCategory(connectionString,"dfdfd");

          //  SqlDemo(connectionString);
        }

        private static void SqlDemo(string connectionString)
        {
            var queryString = "select t.* from  tproducts t where t.unitprice>@pricePoint";

            var paramValue = 5;
            using (var connection =
                new MySqlConnection(connectionString))
            {
                var command = new MySqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

                Console.ReadLine();
            }
        }

        static void GetSalesByCategory(string connectionString, string categoryName)
        {
            using (MySqlConnection connection=new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "testproduce";
                command.CommandType = CommandType.StoredProcedure;

                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@CategoryName";
                parameter.MySqlDbType = MySqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = categoryName;

                MySqlParameter parameter1 = new MySqlParameter();
                parameter1.ParameterName = "@testStr";
                parameter1.MySqlDbType = MySqlDbType.VarChar;
                parameter1.Direction = ParameterDirection.Output;
                parameter1.Value = "fdsf";
                
                MySqlParameter parameter2 = new MySqlParameter();
                parameter2.ParameterName = "@testInout";
                parameter2.MySqlDbType = MySqlDbType.VarChar;
                parameter2.Direction = ParameterDirection.InputOutput;
                parameter2.Value = "123";
                
                command.Parameters.Add(parameter);
                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                
                connection.Open();
                using (MySqlDataReader reader=command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}:{1}",reader[0],reader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found");
                    }
                    Console.WriteLine(parameter1.Value);
                    reader.Close();
                }
                
                Console.WriteLine(parameter2.Value);
            }
            
            
        }
    }
}