using System;

public class Empleado : Persona
{
    public Empleado(string Nombre, string Apellidos, int Edad, string Dni, double Salario, string Telefono)
        : base(Nombre, Apellidos, Edad, Dni)
    {
        this.Salario = Salario;
        this.Telefono = Telefono;
    }

    public Empleado() : this("", "", 0, "", 0, "")
    {
    }

    public override double Hacienda()
    {
        return IRPF * Salario / 100;
    }

    public override void MostrarDatos()
    {
        base.MostrarDatos();
        Console.WriteLine("Salario: {0}\n" +
                            "IRPF: {1}\n" +
                            "Telefono: {2}", Salario, IRPF, Telefono);
    }

    public override void PedirDatos()
    {
        base.PedirDatos();
        bool flag;
        do
        {
            Console.WriteLine("Escribe la salario:");
            flag = double.TryParse(Console.ReadLine(), out salario);

        } while (!flag);
        Console.WriteLine("Escribe los telefono:");
        Telefono = Console.ReadLine();

    }

    public void MostrarDatos(int index)
    {
       switch(index)
        {
            case 0:
                Console.WriteLine("Nombre: {0}", Nombre);
                break;
            case 1:
                Console.WriteLine("Apellidos: {0}", Apellidos);
                break;
            case 2:
                Console.WriteLine("Edad: {0}", Edad);
                break;
            case 3:
                Console.WriteLine("Dni: {0}", Dni);
                break;
            case 4:
                Console.WriteLine("Salario: {0}", Salario);
                break;
            case 5:
                Console.WriteLine("IRPF: {0}", IRPF);
                break;
            case 6:
                Console.WriteLine("Telefono: {0}", Telefono);
                break;
        }
    }

    private double salario;
    public double Salario
    {
        set
        {
            switch (value)
            {
                case < 600:
                    irpf = 7;
                    break;
                case >= 600 and < 3000:
                    irpf = 15;
                    break;
                case >= 3000:
                    irpf = 20;
                    break;
            }

            salario = value;
        }

        get
        {
            return salario;
        }
    }

    private int irpf;
    public int IRPF
    {
        get
        {
            return irpf;
        }
    }

    private string telefono;
    public string Telefono
    {
        set
        {
            telefono = value;
        }
        get
        {
            return "+34" + telefono;
        }
    }
}
