namespace TB4.ConsoleApp2
{
    internal class Program
    {
        static List<Product> Products = new List<Product>();    

        static void Main(string[] args)
        {
        //Console.WriteLine("Hello, World!");

        Start:
            Console.WriteLine("--- Mini POS ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Exit");

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

        private static void GetProduct()
        {
            Console.WriteLine("Product List:");
            //Console.WriteLine("Product Count: " + Products.Count);
            Console.WriteLine($"Product Count: {Products.Count}");
            foreach (Product product in Products)
            {
                Console.WriteLine($"N - {product.Name} / P - {product.Price} / Q - {product.Quantity}");
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

            //Product product = new Product(name, price, quantity);
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };
            Products.Add(product);

            Console.WriteLine("Product Saved.");
        }

        public class Product
        {
            public Product()
            {

            }
            //public Product(string name, decimal price, int quantity)
            //{
            //    Name = name;
            //    Price = price;
            //    Quantity = quantity;
            //}
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
