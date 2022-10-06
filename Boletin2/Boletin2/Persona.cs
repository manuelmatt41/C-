using System;

public abstract class Persona
{
    public Persona(string Nombre, string Apellidos, int Edad, string Dni)
    {
        this.Nombre = Nombre;
        this.Apellidos = Apellidos;
        this.Edad = Edad;
        this.Dni = Dni;
    }

    public Persona() : this("", "", 0, "")
    {
    }


    public abstract double Hacienda();

    public virtual void MostrarDatos()
    {
        Console.WriteLine("Los datos son:\n" +
                        "Nombre: {0}\n" +
                        "Apellidos: {1}\n" +
                        "Edad: {2}\n" +
                        "Dni: {3}", Nombre, Apellidos, Edad, Dni);
    }

    public virtual void PedirDatos()
    {
        bool flag;

        Console.WriteLine("Escribe el nombre:");
        Nombre = Console.ReadLine();

        Console.WriteLine("Escribe los apellidos:");
        Apellidos = Console.ReadLine();

        do
        {
            Console.WriteLine("Escribe la edad:");
            flag = int.TryParse(Console.ReadLine(), out edad);

        } while (!flag);

        Console.WriteLine("Escribe el dni:");
        Dni = Console.ReadLine();
    }

    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    private int edad;
    public int Edad
    {
        set
        {
            if (value < 0)
            {
                edad = 0;
            }
            else
            {
                edad = value;
            }
        }

        get
        {
            return edad;
        }
    }
    private string dni;
    public string Dni
    {
        set
        {
            if (value.Length > 8)
            {
                dni = value.Substring(0, 8);
            }
        }

        get
        {
            string letraDni = "TRWAGMYFPDXBNJZSQVHLCKE";

            return dni + letraDni[(Convert.ToInt32(dni) % 23)];
        }
    }
}
