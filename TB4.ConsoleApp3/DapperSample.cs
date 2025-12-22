using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB4.ConsoleApp3;

internal class DapperSample
{
    private SqlConnectionStringBuilder sb;

    public DapperSample()
    {
        sb = new SqlConnectionStringBuilder();
        sb.DataSource = "."; // server name
        sb.InitialCatalog = "Batch4MiniPOS"; // database name
        sb.UserID = "sa";
        sb.Password = "sasa@123";
        sb.TrustServerCertificate = true;
    }

    public void Read()
    {
        using (IDbConnection db = new SqlConnection(sb.ConnectionString))
        {
            db.Open();
            string query = "select * from tbl_product";
            List<ProductDto> lst = db.Query<ProductDto>(query).ToList();

            foreach (ProductDto item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Quantity);
            }
        }
    }

    public void Edit()
    {
        using (IDbConnection db = new SqlConnection(sb.ConnectionString))
        {
            db.Open();
            string query = "select * from tbl_product where productid = 1;";
            ProductDto item = db.Query<ProductDto>(query).FirstOrDefault()!;

            //if (item == null) return;
            if (item is null) return;

            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Quantity);
        }
    }

    public void Create()
    {
        using (IDbConnection db = new SqlConnection(sb.ConnectionString))
        {
            db.Open();

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
            int result = db.Execute(query);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
    }

    public void Update()
    {
        using(IDbConnection db = new SqlConnection(sb.ConnectionString))
        {
            db.Open();
            string query = @"Delete from  [dbo].[Tbl_Product] set productname = mango where productid = 1";
            int result = db.Execute(query);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);

        }
    }

    public void Delete()
    {
        using (IDbConnection db = new SqlConnection(sb.ConnectionString))
        {
            db.Open();

            string query = @"Delete from  [dbo].[Tbl_Product] where productid = 1";
            int result = db.Execute(query);

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
