using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;

// S - C - S - B
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = "."; // server name
sqlConnectionStringBuilder.InitialCatalog = "Batch4MiniPOS"; // database name
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sasa@123";
sqlConnectionStringBuilder.TrustServerCertificate = true;

string connectionString = sqlConnectionStringBuilder.ConnectionString;
Console.WriteLine(connectionString);

SqlConnection connection = new SqlConnection(connectionString);

connection.Open();

#region Read

//SqlCommand cmd = new SqlCommand("select * from tbl_product", connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt); // execute

#endregion

#region Create

string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductName]
           ,[Price]
           ,[Quantitty]
           ,[IsDelete]
           ,[CreatedDateTime])
     VALUES
           ('Pineapple'
           ,4000
           ,30
           ,0
           ,GETDATE())";
SqlCommand cmd = new SqlCommand(query, connection);
int result = cmd.ExecuteNonQuery();

#endregion

connection.Close();

string message = result > 0 ? "Saving Successful." : "Saving Failed.";
Console.WriteLine(message);

//// table > row > column
//foreach (DataRow dr in dt.Rows)
//{
//    string productName = Convert.ToString(dr["ProductName"]);
//    decimal price = Convert.ToDecimal(dr["Price"]);
//    Console.WriteLine("Product Name : " + productName);
//    Console.WriteLine($"Price : {price.ToString("n0")}");
//}

//Console.WriteLine("Connection Opening...");
//connection.Open();
//Console.WriteLine("Connection Opened.");

//Console.WriteLine("Connection Closing...");
//connection.Close();
//Console.WriteLine("Connection Closed.");

Console.ReadLine();