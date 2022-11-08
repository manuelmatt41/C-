using bol6_ejer3;
using System;

namespace bol6_ejer3
{

    public class GestorPersona
    {
        public GestorPersona()
        {
            Workers = new List<Persona>();
            InitializeList();
        }

        public int Posicion(int edad)
        {
            for (int i = 0; i < Workers.Count; i++)
            {
                if (edad > Workers[i].Edad)
                {
                    return i;
                }
            }

            return -1;
        }

        public int Posicion(string apellido)
        {
            for (int i = 0; i < Workers.Count; i++)
            {
                if (Workers[i].Apellidos.StartsWith(apellido))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Eliminar(int max, int min = 0)
        {
            if (Workers.Count < max || min < 0)
            {
                return false;
            }

            for (int i = max; i >= min; i--)
            {
                Workers.RemoveAt(i);
            }

            return true;
        }

        private void InitializeList()
        {
            try
            {
                using (PersonReader pr = new PersonReader(new FileStream($"{Environment.GetEnvironmentVariable("appdata")}\\persons\\empleado.dat", FileMode.OpenOrCreate)))
                {
                    while (pr.BaseStream.Position < pr.BaseStream.Length)
                    {
                        Workers.Add(pr.ReadEmpleado());
                    }
                }

                using (PersonReader pr = new PersonReader(new FileStream($"{Environment.GetEnvironmentVariable("appdata")}\\persons\\directivo.dat", FileMode.OpenOrCreate)))
                {
                    while (pr.BaseStream.Position < pr.BaseStream.Length)
                    {
                        Workers.Add(pr.ReadDirectivo());
                    }
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException || e is IOException)
            {
                Console.WriteLine(e.StackTrace);
                Directory.CreateDirectory($"{Environment.GetEnvironmentVariable("appdata")}\\persons");
            }
        }

        public void SaveList()
        {
            try
            {
                using (PersonWritter pr = new PersonWritter(new FileStream($"{Environment.GetEnvironmentVariable("appdata")}\\persons\\directivo.dat", FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < Workers.Count; i++)
                    {
                        if (Workers[i] is Directivo)
                        {
                        pr.Write((Directivo)Workers[i]);
                        }
                    }
                }
                using (PersonWritter pr = new PersonWritter(new FileStream($"{Environment.GetEnvironmentVariable("appdata")}\\persons\\empleado.dat", FileMode.OpenOrCreate)))
                {
                    for (int i = 0; i < Workers.Count; i++)
                    {
                        if (Workers[i] is Empleado)
                        {
                            pr.Write((Empleado)Workers[i]);
                        }
                    }
                }
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException || e is IOException)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public List<Persona> Workers;
    }
}
