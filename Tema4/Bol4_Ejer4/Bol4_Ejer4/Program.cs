namespace Bol4_Ejer4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map map;
            ConsoleKeyInfo keyInfo;
            Console.CursorVisible = false;
            do
            {
                Console.Clear();
                map = new Map(5);
                Console.SetCursorPosition(6, 6);
                Console.WriteLine($"Horse {map.WinnerHorse.Row}");
                Console.WriteLine("Press Enter to play again");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key == ConsoleKey.Enter);

        }
    }
}