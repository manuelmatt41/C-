using Microsoft.VisualBasic.FileIO;
using System;

public class InterfazUsuario
{
    public InterfazUsuario()
    {
        GestorPersona = new GestorPersona();
    }

    private void Add(int type)
    {
        switch (type)
        {
            case 0:
                Empleado e = new Empleado();
                e.PedirDatos();
                GestorPersona.Workers.Insert(GestorPersona.Posicion(e.Edad) != -1 ? GestorPersona.Posicion(e.Edad) : GestorPersona.Workers.Count, e);
                break;
            case 1:
                Directivo d = new Directivo();
                d.PedirDatos();
                GestorPersona.Workers.Insert(GestorPersona.Posicion(d.Edad) != -1 ? GestorPersona.Posicion(d.Edad) : GestorPersona.Workers.Count, d);
                break;
        }
        //int edad = 20;
        //char a = 'a';
        //for (int i = 0; i < 5; i++)
        //{
        //    GestorPersona.Workers.Insert(GestorPersona.Posicion(edad) != -1 ? GestorPersona.Posicion(edad) : GestorPersona.Workers.Count, new Empleado(a + "", "", 0, "32721824t", 111, ""));
        //    edad += 2;
        //    a++;
        //}
    }

    private void ShowPersons()
    {
        Console.Clear();
        for (int i = 0; i < GestorPersona.Workers.Count; i++)
        {
            ShowPerson(i);
        }
    }

    private void ShowPerson(int index)
    {
        Console.WriteLine($"{(GestorPersona.Workers[index] is Empleado ? "E" : "D")}");
        Console.WriteLine($"{index + 1,-3} Name: {CutNames(GestorPersona.Workers[index].Nombre, 10),-13} Surname: {CutNames(GestorPersona.Workers[index].Apellidos, 20),-22}");
    }

    private string CutNames(string name, int maxCharacters)
    {
        return name.Length > maxCharacters ? name.Substring(0, maxCharacters) + "..." : name;
    }

    private void PaintMenu(String[] options, int option)
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");

        for (int i = 0; i < options.Length; i++)
        {
            if (i == option)
            {
                Console.Write(">");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

            Console.WriteLine(options[i]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private int InteractiveMenu(int option, string[] options)
    {
        int selection = -1;
        do
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    option = option < options.Length - 1 ? option + 1 : option;
                    break;
                case ConsoleKey.UpArrow:
                    option = option > 0 ? option - 1 : option;
                    break;
                case ConsoleKey.Enter:
                    return option;
            }

            PaintMenu(options, option);
        } while (selection != options.Length - 1);

        return selection;
    }

    //private bool InsertPerson()
    //{

    //}

    public void Start()
    {
        int option = 0;
        int selection;
        string[] options = { "Insert a person", "Remove a person", "View persons", "View a person", "Exit" };
        string[] employees = { "Employee", "Executive" };
        Console.CursorVisible = false;

        do
        {
            PaintMenu(options, option);
            selection = InteractiveMenu(option, options);
            option = 0;

            switch (selection)
            {
                case 0:
                    PaintMenu(employees, option);
                    selection = InteractiveMenu(option, employees);
                    Add(selection);
                    break;
                case 1:
                    if (GestorPersona.Workers.Count > 1)
                    {

                        bool flag;
                        int min;
                        int max;
                        Console.WriteLine("Escribe el rango que quieres eliminar:");

                        do
                        {
                            do
                            {
                                Console.WriteLine("Escribe el minimo del rango");
                                flag = int.TryParse(Console.ReadLine(), out min);

                                if (!flag)
                                {
                                    Console.WriteLine("No se ha escrito bien el minimo");
                                }

                                if (min < 0)
                                {
                                    Console.WriteLine("No existe ese valor minimo");
                                }
                            } while (!flag || min - 1 < 0);

                            do
                            {
                                Console.WriteLine("Escribe el maximo del rango");
                                flag = int.TryParse(Console.ReadLine(), out max);

                                if (!flag)
                                {
                                    Console.WriteLine("No se ha escrito bien el maximo");
                                }

                                if (max - 1 > GestorPersona.Workers.Count)
                                {
                                    Console.WriteLine("No existe tantos valores en la lista");
                                }
                            } while (!flag || max >= GestorPersona.Workers.Count);
                        } while (!GestorPersona.Eliminar(max - 1, min - 1));
                    } 
                    else
                    {
                        Console.WriteLine("No hay personas guardadas");
                    }
                    break;
                case 2:
                    if (GestorPersona.Workers.Count > 0)
                    {
                        ShowPersons();
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    if (GestorPersona.Workers.Count > 0)
                    {
                        string apellido;
                        int index;

                        do
                        {
                            Console.WriteLine("Escribe el indice de la persona que quieres ver");
                            apellido = Console.ReadLine();
                            index = GestorPersona.Posicion(apellido);

                            if (index == -1)
                            {
                                Console.WriteLine("No existe ninguna persona con ese apellido");
                            }
                        } while (index == -1);

                        ShowPerson(index);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No hay personas guardadas");
                    }
                    break;
                default:
                    break;
            }

            option = 0;

        } while (selection != options.Length - 1);


    }
    public GestorPersona GestorPersona;
}

