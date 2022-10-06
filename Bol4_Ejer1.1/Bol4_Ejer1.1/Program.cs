namespace Bol4_Ejer1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };

            if (Array.Exists(v, (v) => v >= 5))
            {
                Console.WriteLine("There is a approved");
            }
            else
            {
                Console.WriteLine("There is no a approved");
            }

            int lastApproved = Array.FindLastIndex(v, (v) => v >= 5);
            Console.WriteLine($"The last approved is {lastApproved}");
            Array.ForEach(v, (v) => Console.WriteLine($"{1.0 / v:0.00}"));
            Console.ReadKey();
        }

    }
}