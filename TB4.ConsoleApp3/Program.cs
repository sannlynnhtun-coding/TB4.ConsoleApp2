using Microsoft.Data.SqlClient;
using TB4.ConsoleApp3;

AdoDotNetSample sample = new AdoDotNetSample();
sample.Read();
sample.Create();
sample.Edit();

//AdoDotNetSample sample2 = new AdoDotNetSample(new SqlConnectionStringBuilder
//{
//    DataSource = ".",
//    InitialCatalog = "Batch5MiniPOS",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true
//});
//AdoDotNetSample sample3 = new AdoDotNetSample(new SqlConnectionStringBuilder
//{
//    DataSource = ".",
//    InitialCatalog = "Batch6MiniPOS",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true
//});

// CRUD - Group 2 - Query, Execute

Console.ReadLine();