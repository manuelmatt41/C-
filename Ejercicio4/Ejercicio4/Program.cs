namespace Ejercicio4
{
    internal class Program
    {
        static void menu(string[] opciones, int opcion)
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion:");

            for (int i = 0; i < opciones.Length; i++)
            {
                if (i == opcion)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(opciones[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void opcionDado()
        {
            int numeroCaras;
            int numeroApuesta;
            int[] tiradasDado = new int[10];
            int contador = 0;

            try
            {
                do
                {
                    Console.WriteLine("Cuantas caras tiene el dado que quieres tirar?");
                    numeroCaras = Convert.ToInt16(Console.ReadLine());
                } while (numeroCaras < 1);
                do
                {
                    Console.WriteLine("Que numero apuestas que aparece");
                    numeroApuesta = Convert.ToInt16(Console.ReadLine());

                } while (numeroApuesta < 1 || numeroApuesta > numeroCaras);
            }
            catch (FormatException)
            {
                numeroCaras = 6;
                numeroApuesta = -1;
            }

            Random generador = new Random();
            for (int i = 0; i < tiradasDado.Length; i++)
            {
                tiradasDado[i] = generador.Next(1, numeroCaras + 1);
                Console.WriteLine("Ha salido el numero {0}", tiradasDado[i]);
                contador += numeroApuesta == tiradasDado[i] ? 1 : 0;
            }

            Console.WriteLine("Has acertado {0} veces", contador);
        }

        static void opcionNumeroAleatorio()
        {
            Console.WriteLine("El ordenador ha pensado un numero, intenta adivinarlo");
            int numeroAleatorio = new Random().Next(1, 101);
            int numeroUsuario = -1;
            int intentos = 5;
            bool error = false;
            do
            {
                Console.WriteLine("Escribe un numero");
                do
                {
                    try
                    {
                        numeroUsuario = Convert.ToInt16(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        error = true;
                    }
                } while (error || (numeroUsuario < 1 && numeroUsuario > 100));

                if (numeroUsuario != numeroAleatorio)
                {
                    intentos--;
                    Console.WriteLine("El numero es {0}", numeroUsuario < numeroAleatorio ? "mayor" : "menor");
                    Console.WriteLine("Te quedan {0} intentos", intentos);
                }
                else
                {
                    intentos = 0;
                }
            } while (intentos > 0);

            Console.WriteLine("Has {0} el numero, era el {1}", numeroAleatorio == numeroUsuario ? "adivinado" : "perdido", numeroAleatorio);
        }

        static char resultadoPonderado()
        {
            switch (new Random().Next(1, 101))
            {
                case <= 60:
                    return '1';
                case <= 85:
                    return 'X';
                case <= 100:
                    return '2';
            }

            return ' ';
        }

        static void quiniela()
        {
            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine(resultadoPonderado());
            }
        }
        static void Main(string[] args)
        {
            int opcion = 0;
            int seleccion = -1;
            string[] opciones = { "1.Tirar dado", "2.Juego adivina el numero", "3.Realizar quiniela", "4.Jugar a todo", "5.Salir" };

            Console.CursorVisible = false;

            menu(opciones, opcion);

            do
            {
                ConsoleKeyInfo tecla = Console.ReadKey();

                switch (tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcion = opcion < opciones.Length - 1 ? opcion + 1 : opcion;
                        break;
                    case ConsoleKey.UpArrow:
                        opcion = opcion > 0 ? opcion - 1 : opcion;
                        break;
                    case ConsoleKey.Enter:
                        seleccion = opcion;
                        switch (seleccion)
                        {
                            case 0:
                                opcionDado();
                                if (seleccion == 3) goto case 1;
                                break;
                            case 1:
                                opcionNumeroAleatorio();
                                if (seleccion == 3) goto case 2;
                                break;
                            case 2:
                                quiniela();
                                break;
                            case 3:
                                goto case 0;
                        }
                        Console.WriteLine("Pulsa una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

                if (tecla.Key == ConsoleKey.Enter)
                {

                }

                menu(opciones, opcion);


            } while (seleccion != opciones.Length - 1);
        }
    }
}