namespace Bol3_Ejer1
{
    internal class Program
    {
        static void Request(Dictionary<string, int> datosOrdenadores)
        {
            string ip;
            int ram;
            bool flag;

            do
            {
                Console.WriteLine("Escribe una ip: ");
                ip = Console.ReadLine();
                ip = ip.Trim();

                if (!CheckIp(ip))
                {
                    Console.WriteLine("Ip no valida");
                }

                if (datosOrdenadores.ContainsKey(ip))
                {
                    Console.WriteLine("Ip repetida");
                }
            } while (!CheckIp(ip) || datosOrdenadores.ContainsKey(ip));

            do
            {
                Console.WriteLine("Escribe la cantidad de RAM que desea: ");
                try
                {
                    flag = int.TryParse(Console.ReadLine(), out ram);
                }
                catch (FormatException)
                {
                    ram = -1;
                    Console.WriteLine("La RAM tiene que se positiva");
                }
            } while (ram < 0);

            datosOrdenadores.Add(ip, ram);
        }

        static bool CheckIp(String ip)
        {
            if (ip == null)
            {
                return false;
            }

            string[] ipNumbers = ip.Split(".");


            if (ipNumbers.Length != 4)
            {
                return false;
            }

            foreach (string ipNumber in ipNumbers)
            {
                int number;
                bool flag;

                flag = int.TryParse(ipNumber, out number);

                if (number < 0 || number > 255)
                {
                    return false;
                }
            }

            return true;
        }

        static void Show(Dictionary<string, int> datosOrdenadores, string key)
        {
            Console.WriteLine($"Clave: {key} --- Valor: {datosOrdenadores[key]}GB");
        }

        static void Show(Dictionary<string, int> datosOrdenadores)
        {
            foreach (KeyValuePair<string, int> keyValuePair in datosOrdenadores)
            {
                Show(datosOrdenadores, keyValuePair.Key);
            }
        }
        static void Main(string[] args)
        {

            Dictionary<string, int> pcData = new Dictionary<string, int>();
            int opcion;
            bool flag;

            do
            {
                Console.WriteLine("Elige una opcion:\n" +
                                    "1.Introducir datos\n" +
                                    "2.Eliminar datos\n" +
                                    "3.Mostrar los datos\n" +
                                    "4.Mostrar un dato\n" +
                                    "5.Salir");

                flag = int.TryParse(Console.ReadLine(), out opcion);


                switch (opcion)
                {
                    case 1:
                        Request(pcData);
                        Console.WriteLine(pcData.Count);
                        break;
                    case 2:
                        if (pcData.Count > 0)
                        {
                            string ipEliminar;
                            do
                            {
                                Console.WriteLine("Escribe la ip del ordenador que quieres eliminar");
                                ipEliminar = Console.ReadLine();
                                ipEliminar.Trim();
                            } while (!CheckIp(ipEliminar) || !pcData.ContainsKey(ipEliminar));

                            pcData.Remove(ipEliminar);
                        }
                        else
                        {
                            Console.WriteLine("No hay nada en el diccionario");
                        }
                        break;
                    case 3:
                        if (pcData.Count > 0)
                        {
                            Show(pcData);
                        }
                        else
                        {
                            Console.WriteLine("No hay datos guardados");
                        }
                        break;
                    case 4:
                        if (pcData.Count > 0)
                        {
                            string ipMostrada;
                            do
                            {
                                Console.WriteLine("Escribe la ip del ordenador que quieres ver");
                                ipMostrada = Console.ReadLine();
                                ipMostrada.Trim();
                            } while (!CheckIp(ipMostrada) || !pcData.ContainsKey(ipMostrada));

                            Show(pcData, ipMostrada);
                        }
                        else
                        {
                            Console.WriteLine("No hay nada en el diccionario");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Cerrando el programa");
                        break;
                }
            } while (opcion != 5 || !flag);

        }
    }
}