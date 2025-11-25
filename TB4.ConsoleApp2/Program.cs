namespace TB4.ConsoleApp2
{
    internal class Program
    {
        static List<Product> Products = new List<Product>()
        {
            new Product(1, "Apple", 1000, 10),
            new Product(2, "Orange", 2000, 30),
        };

        static void Main(string[] args)
        {
        //Console.WriteLine("Hello, World!");

        Start:
            Console.WriteLine("--- Mini POS ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Please choose an option: "); // 1, 2, 3

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    AddProduct();
                    goto Start;

                case 2:
                    GetProduct();
                    goto Start;

                case 3:
                    EditProduct();
                    goto Start;

                case 4:
                    DeleteProduct();
                    goto Start;

                case 5:
                default:
                    break;
            }
            //Console.Write("Please enter product name: ");
            //string name = Console.ReadLine();

            //Console.Write("Please enter price: ");
            //decimal price = Convert.ToDecimal(Console.ReadLine());

            //Console.Write("Please enter quantity: ");
            //int quantity = Convert.ToInt32(Console.ReadLine());

            //string name = "";
            //decimal price = 0;
            //int quantity = 0;

            //Console.WriteLine("Product Saved.");

            //Console.ReadKey();
            Console.ReadLine();
        }

        private static void DeleteProduct()
        {
            Console.Write("Please enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Are you sure want to delete? (Y/N): ");
            string confirm = Console.ReadLine();
            //if (confirm.ToUpper() == "Y")
            //{
            //    // delete case
            //}
            //else
            //{
            //    return;
            //}

            if (confirm.ToUpper() != "Y")
            {
                return;
            }

            // delete case

            var product = Products.Where(x => x.Id == id).FirstOrDefault();
            if (product is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Products.Remove(product);

            Console.WriteLine("Product deleted.");
        }

        private static void EditProduct()
        {
            Console.Write("Please enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            //foreach (var x in collection)
            //{
            //}

            var product = Products.Where(x => x.Id == id).FirstOrDefault();
            //if(product == null)
            if (product is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine($"{product.Id}. / N - {product.Name} / P - {product.Price} / Q - {product.Quantity}");
            Console.WriteLine("------------------------");

            Console.Write("Please enter new product name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = product.Name;
            }

            Console.Write("Please enter new price: ");
            string str = Console.ReadLine();
            decimal price = 0;
            if (string.IsNullOrEmpty(str))
            {
                price = product.Price;
            }
            else
            {
                price = Convert.ToDecimal(str);
            }

            Console.Write("Please enter new quantity: ");
            str = Console.ReadLine();
            int quantity = 0;
            if (string.IsNullOrEmpty(str))
            {
                quantity = product.Quantity;
            }
            else
            {
                quantity = Convert.ToInt32(str);
            }

            int index = Products.FindIndex(x => x.Id == id);
            Products[index].Name = name;
            Products[index].Price = price;
            Products[index].Quantity = quantity;

            Console.WriteLine("Product updated.");
        }

        private static void GetProduct()
        {
            Console.WriteLine("Product List:");
            //Console.WriteLine("Product Count: " + Products.Count);
            Console.WriteLine($"Product Count: {Products.Count}");
            foreach (Product product in Products)
            {
                Console.WriteLine($"{product.Id}. / N - {product.Name} / P - {product.Price} / Q - {product.Quantity}");
                Console.WriteLine("------------------------");
            }
        }

        private static void AddProduct()
        {
            Console.Write("Please enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Please enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Please enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            //int no = Products.Count + 1;

            int no = Products.Max(x => x.Id) + 1;
            Product product = new Product(no, name, price, quantity);
            //Product product = new Product()
            //{
            //    Name = name,
            //    Price = price,
            //    Quantity = quantity
            //};
            Products.Add(product);

            Console.WriteLine("Product Saved.");
        }

        public class Product
        {
            //public Product()
            //{

            //}

            public Product(int id, string name, decimal price, int quantity)
            {
                Id = id;
                Name = name;
                Price = price;
                Quantity = quantity;
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
