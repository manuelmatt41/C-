namespace Bol4_Ejer3
{
    internal class Program
    {
        static readonly object l = new object();
        static int result = 0;
        static int GOAL = 1000;
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                while (result > -GOAL && result < GOAL)
                {
                    lock (l)
                    {
                        if (result > -GOAL && result < GOAL)
                        {
                            result++;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Thread1: {result}  ");
                        }
                    }
                }

                lock (l)
                {
                    Monitor.Pulse(l);
                }
            }).Start();

            new Thread(() =>
            {
                while (result > -GOAL && result < GOAL)
                {
                    lock (l)
                    {
                        if (result > -GOAL && result < GOAL)
                        {
                            result--;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Thread2: {result}  ");
                        }
                    }
                }

                lock (l)
                {
                    Monitor.Pulse(l);
                }
            }).Start();

            lock (l)
            {
                Monitor.Wait(l);
            }

            if (result == GOAL)
            {
                Console.WriteLine($"Win thread1");
            }

            if (result == -GOAL)
            {
                Console.WriteLine($"Win thread2");
            }
            Console.ReadKey();
        }
    }
}