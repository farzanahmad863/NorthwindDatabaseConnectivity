using System;
using System.Data.SqlClient;


namespace NorthwindDatabaseConnectivity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Database!");
            string connectionString = "Data Source=DESKTOP-KF048ET;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection conn = new SqlConnection("Data Source = DESKTOP - KF048ET; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlDataReader dataReader = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Do work here; connection closed on following line.
                    SqlCommand command = new SqlCommand("SELECT * FROM Northwind.dbo.Products", connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Console.WriteLine(dataReader);
                    }
                }

                finally
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }

                    // 5. Close the connection
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
