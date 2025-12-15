using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB4.ConsoleApp3.Database.AppDbContextModels;

namespace TB4.ConsoleApp3
{
    internal class EfCore2Sample
    {
        private readonly AppDbContext _db;

        public EfCore2Sample()
        {
            _db = new AppDbContext();
        }

        public void Read()
        {
            List<TblProduct> lst = _db.TblProducts.ToList(); // select * from tbl_product

            foreach (TblProduct item in lst)
            {
                Console.WriteLine(item.ProductId);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Quantity);
            }
        }

        public void Edit()
        {
            var item = _db.TblProducts.Where(x => x.ProductId == 1).FirstOrDefault();
            if (item is null) return;

            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.ProductName);
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Quantity);
        }

        public void Create()
        {
            TblProduct item = new TblProduct
            {
                CreatedDateTime = DateTime.Now,
                IsDelete = false,
                Price = 1000,
                ProductName = "Mango",
                Quantity = 100,
            };
            _db.TblProducts.Add(item);
            int result = _db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            var item = _db.TblProducts.Where(x => x.ProductId == 1).FirstOrDefault();
            if (item is null) return;

            item.ProductName = "Banana";

            int result = _db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            var item = _db.TblProducts.Where(x => x.ProductId == 1).FirstOrDefault();
            if (item is null) return;

            item.IsDelete = true; // soft delete
            //_db.Products.Remove(item); // hard delete

            int result = _db.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
