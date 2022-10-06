//#define FLAG
using System.Diagnostics;

namespace Ejercicio6
{
    internal class Program
    {
        static bool factorial(int num, ref int resultado)
        {
            int acumulador = 1;

            for (int i = 1; i <= num; i++)
            {
                acumulador *= i;
            }
            if (num >= 0 && num < 11)
            {
                resultado = acumulador;
                return true;
            }
            else
            {
                return false;
            }
        }

        static void pintarAsteriscos(int numAsteriscos = 10)
        {
            Random r = new Random();
            for (int i = 0; i < numAsteriscos; i++)
            {
                Console.SetCursorPosition(r.Next(1, 11), r.Next(1, 20));
                Console.Write("*");
            }
        }
        static void Main(string[] args)
        {
#if FLAG
            int resultado = 0;
            Console.WriteLine(factorial(5, ref resultado));
            Console.WriteLine(resultado);
#else
            pintarAsteriscos(100);
#endif
            Console.ReadKey();
        }
    }
}