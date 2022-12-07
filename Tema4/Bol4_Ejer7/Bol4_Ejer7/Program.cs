namespace Bol4_Ejer7
{
    internal class Program
    {
        static readonly Object l = new Object();
        static int points = 0;
        static bool pause = false;
        static bool finish = false;
        static void Main(string[] args)
        {
            string[] animation = { "|", "/", "-", "\\" };
            Console.CursorVisible = false;
            new Thread(() =>
            {
                int player1RandomNumber;

                while (!finish)
                {
                    lock (l)
                    {
                        player1RandomNumber = new Random().Next(1, 11);
                        if (!finish)
                        {
                            Console.SetCursorPosition(2, 1);
                            Console.WriteLine($"Player 1: {player1RandomNumber}");

                            if (player1RandomNumber >= 5 && player1RandomNumber <= 7)
                            {
                                points += pause ? 5 : 1;
                                pause = true;
                            }

                            if (points == 10 || points == -10)
                            {
                                lock (l)
                                {
                                    finish = true;
                                    pause = true;
                                    Monitor.Pulse(l);
                                }
                            }
                        }

                    }
                    Thread.Sleep(new Random().Next(100, 100 * player1RandomNumber));
                }
            }).Start();

            new Thread(() =>
            {
                int player2RandomNumber;
                bool first = true;
                while (!finish)
                {
                    lock (l)
                    {
                        player2RandomNumber = new Random().Next(1, 11);
                        if (!finish)
                        {
                            Console.SetCursorPosition(2, 8);
                            Console.WriteLine($"Player 2: {player2RandomNumber}");

                            if (player2RandomNumber >= 5 && player2RandomNumber <= 7)
                            {
                                points -= !pause && !first ? 5 : 1;
                                pause = false;
                                first = false;
                            }

                            if (points == 10 || points == -10)
                            {
                                lock (l)
                                {
                                    finish = true;
                                    pause = true;
                                    Monitor.Pulse(l);
                                }
                            }
                        }

                    }
                    Thread.Sleep(new Random().Next(100, 100 * player2RandomNumber));
                }

            }).Start();

            new Thread(() =>
            {
                while (!finish)
                {
                    while (!pause)
                    {
                        lock (l)
                        {
                            for (int i = 0; i < animation.Length && !pause; i++)
                            {
                                Console.SetCursorPosition(6, 4);
                                Console.WriteLine(animation[i]);
                                Thread.Sleep(200);
                            }
                        }
                    }

                }
            }).Start();

            lock (l)
            {
                Monitor.Wait(l);
            }

            Console.Clear();
            Console.WriteLine($"Ha ganado el {(points == 20 ? "Jugador1" : "Jugador2")}");
        }
    }
}