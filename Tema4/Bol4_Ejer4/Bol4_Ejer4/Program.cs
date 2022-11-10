namespace Bol4_Ejer4
{
    internal class Program
    {
        public static readonly Object l = new object();
        public static bool finish;


        static void Main(string[] args)
        {
            Map map;
            ConsoleKeyInfo keyInfo;
            Console.CursorVisible = false;
            do
            {
                finish = false;
                Console.Clear();
                map = new Map(5);
                map.RunAllHorses();
                lock (l)
                {
                    Monitor.Wait(l);
                }
                Console.SetCursorPosition(6, 6);
                Console.WriteLine("Press Enter to play again");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key == ConsoleKey.Enter);

        }
    }
}