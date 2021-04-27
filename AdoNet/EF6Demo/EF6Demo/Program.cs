using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;
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

            GetSalesByCategory(connectionString, "dfdfd");

            TransactionDemo(connectionString);

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlDataAdapter adapter = new MySqlDataAdapter("select customerId,CompanyName form customers order by" +
                                                            "customerid", connection);
            adapter.UpdateCommand = new MySqlCommand(
                "update customers set customerid=@customerid,CompanyName=@CompanyName" +
                "where CustomerId=@oldCustomerId and companyname=@oldCompanyName",
                connection);
            adapter.UpdateCommand.Parameters.Add("@customerid", MySqlDbType.VarChar, 5, "CustomerId");
            adapter.UpdateCommand.Parameters.Add("@companyname", MySqlDbType.VarChar, 30, "CompanyName");


            MySqlParameter parameter = adapter.UpdateCommand.Parameters.Add("@oldCustomerId",
                MySqlDbType.VarChar, 5, "CustomerID");
            parameter.SourceVersion = DataRowVersion.Original;
            parameter = adapter.UpdateCommand.Parameters.Add(
                "@oldCompanyName", MySqlDbType.VarChar, 30, "CompanyName");
            parameter.SourceVersion = DataRowVersion.Original;

             adapter.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdated);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Customers");
            foreach (DataRow dataRow in dataSet.Tables["Customers"].Rows)
            {
                if (dataRow.HasErrors)
                {
                    Console.WriteLine(dataRow[0]+"\n"+dataRow.RowError);
                }
            }
            
          

        }

        private static void TransactionDemo(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlTransaction mysqlTran = connection.BeginTransaction();
                MySqlCommand command = connection.CreateCommand();
                command.Transaction = mysqlTran;
                try
                {
                    command.CommandText =
                        "INSERT INTO `testdatabase`.`tproducts` " +
                        "( `ProductID`, `UnitPrice`, `ProductName` " +
                        "VALUES( 1, 10.00, '10' );";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO `testdatabase`.`tproducts` " +
                                          "( `ProductID`, `UnitPrice`, `ProductName` " +
                                          "VALUES( 1, 10.00, '10' );";
                    command.ExecuteNonQuery();
                    mysqlTran.Commit();
                    Console.WriteLine("Both records were written to database");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    try
                    {
                        mysqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
            }
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
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}:{1}", reader[0], reader[1]);
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

        static public int CreateTransactionScope(string connectString1,
            string connectString2,
            string commandText1,
            string commandText2)
        {
            int returnValue = 0;
            System.IO.StringWriter writer = new System.IO.StringWriter();
            using (TransactionScope scope = new TransactionScope())
            {
                using (MySqlConnection connection1 = new MySqlConnection(connectString1))
                {
                    try
                    {
                        connection1.Open();
                        MySqlCommand command1 = new MySqlCommand(commandText1, connection1);
                        returnValue = command1.ExecuteNonQuery();
                        writer.WriteLine("Rows to be affected by command1:{0}", returnValue);
                        using (MySqlConnection connection2 = new MySqlConnection(connectString2))
                        {
                            try
                            {
                                connection2.Open();
                                returnValue = 0;
                                MySqlCommand command2 = new MySqlCommand(commandText2, connection2);
                                returnValue = command2.ExecuteNonQuery();
                                writer.WriteLine("Rows to be affected by command2:{0}", returnValue);
                            }
                            catch (Exception e)
                            {
                                writer.WriteLine("returnValue for command2:{0}", returnValue);
                                writer.WriteLine("Exception Message1:{0}", e.Message);

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        writer.WriteLine("returnValue for command1:{0}", returnValue);
                        writer.WriteLine("Exception Message1:{0}", e.Message);

                    }
                }

                scope.Complete();
            }

            if (returnValue > 0)
            {
                writer.WriteLine("Transaction was committed.");
            }
            else
            {
                writer.WriteLine("Transaction rolled back");
            }

            Console.WriteLine(writer.ToString());
            return returnValue;
        }



        protected static void OnRowUpdated(object sender, MySqlRowUpdatedEventArgs args)
        {
            if (args.RecordsAffected==0)
            {
                args.Row.RowError = "Optimistic ConCurrency Violation Encountered";
                args.Status = UpdateStatus.SkipCurrentRow;
            }
        }

        private static void RetreveIdentity(string connectionString)
        {
            using (MySqlConnection connection=new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("select categoryid,categoryname from categories",
                    connection);

                adapter.InsertCommand = new MySqlCommand("InseartCategory", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new MySqlParameter("@categoryName",
                    MySqlDbType.VarChar, 15, "categoryName"));

                MySqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Identity",
                    MySqlDbType.Int32,
                    0, "CategoryID");
            }
           
        }

        static DataTable GetProviderFactoryClasses()
        {
            DataTable table = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }

            return table;
        }
        
        static DbConnection CreateDbConnection(
            string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }
        

    }
}