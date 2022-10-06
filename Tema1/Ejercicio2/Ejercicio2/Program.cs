#define FRASE
namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase1 = Console.ReadLine();
            string frase2 = Console.ReadLine();

#if FRASE
            Console.WriteLine("\"{0}\"\t\\{1}\\", frase1, frase1);
#else
            Console.WriteLine("{0}\t{1}\n{0}\n{1}", frase1, frase2);
#endif
        }
    }
}