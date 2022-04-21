// See https://aka.ms/new-console-template for more information
namespace Shopify2
{
    public class Program
    {
        public static void Main(String[] args)
        {
            LRUCache cache = new LRUCache(3);

            Console.WriteLine($"Writing Siva-Vissamsetty : { cache.Write("Siva", "Vissamsetty")}");
            cache.Print();

            Console.WriteLine($"Writing Lalita-Vissamsetty : {  cache.Write("Lalita", "Vissamsetty")}");
            cache.Print();

            Console.WriteLine($"Writing Yask-Srivastava : { cache.Write("Yask", "Srivastava")}");
            cache.Print();

            Console.WriteLine($"Reading Siva:{cache.Read("Siva")}");
            cache.Print();

            Console.WriteLine($"Deleting Siva:{ cache.Delete("Siva")}");
            cache.Print();

        }
    }
}
