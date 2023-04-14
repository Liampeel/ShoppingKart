
class Program
{
    static void Main(string[] args)
    {
        var shop = new Shop();

        var allowedItems = new string[] { "A", "B", "C", "D" };

        var scannedItems = new List<string>();

        Console.WriteLine("Enter item to scan (A,B,C or D) or type 'total' to finish");

        var input = Console.ReadLine();

        while (input != "total")
        {

            if (allowedItems.Contains(input.ToUpper()))
            {
                Console.WriteLine($"You scanned: {input}");
                scannedItems.Add(input.ToUpper());
                input = Console.ReadLine();
            }

            else
            {
                Console.WriteLine($"Invalid Item");
                input = Console.ReadLine();

            }
        }


        var totalPrice = shop.Total(scannedItems);

        Console.WriteLine($"Total price: £{totalPrice}");
    }
}