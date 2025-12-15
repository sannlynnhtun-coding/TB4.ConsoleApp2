using Microsoft.Data.SqlClient;
using TB4.ConsoleApp3;
using TB4.TestClassLibary;

//AdoDotNetSample adoDotNetSample = new AdoDotNetSample();
//adoDotNetSample.Read();
//adoDotNetSample.Create();
//adoDotNetSample.Edit();

//DapperSample dapperSample = new DapperSample();
//dapperSample.Read();

EfCoreSample efCoreSample = new EfCoreSample();
efCoreSample.Read();
efCoreSample.Edit();
efCoreSample.Create();
efCoreSample.Update();
efCoreSample.Delete();

TestClass testClass = new TestClass();
testClass.Add(1, 2);

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