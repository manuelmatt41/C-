using System;

public class Directivo : Persona, IPastaGansa
{
    public Directivo(string Nombre, string Apellidos, int Edad, string Dni, string Departamento, int NumeroPersonasACargo)
        : base(Nombre, Apellidos, Edad, Dni)
    {
        this.Departamento = Departamento;
        this.NumeroPersonasACargo = NumeroPersonasACargo;
    }

    public Directivo() : this("", "", 0, "33444555", "", 0)
    {
    }
    public override double Hacienda()
    {
        return 30 * PastaGanada / 100;
    }

    public override void MostrarDatos()
    {
        base.MostrarDatos();
        Console.WriteLine("Departamento: {0}\n" +
                            "Numero de personas a cargo: {1}\n" +
                            "Beneficios: {2}", Departamento, NumeroPersonasACargo, Beneficios);
    }

    public override void PedirDatos()
    {
        base.PedirDatos();
        Console.WriteLine("Escribe el departamento:");
        this.Departamento = Console.ReadLine();

        try
        {
            Console.WriteLine("Escribe la numeros de personas a cargo:");
            this.NumeroPersonasACargo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Escribe el beneficios:");
            this.beneficios = Convert.ToDouble(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public double PastaGansa(double Beneficios)
    {
        if (Beneficios < 0)
        {
            Directivo d1 = this;
            d1--;
            return 0;
        }
        pastaGanada = Beneficios * (this.Beneficios / 100);
        return PastaGanada;
    }

    public static Directivo operator --(Directivo d1)
    {
        if (d1.Beneficios >= 1)
        {
            d1.beneficios--;
        }

        return d1;
    }


    public string Departamento { get; set; }
    private int numerosPersonasACargo;
    public int NumeroPersonasACargo
    {
        set
        {
            switch (value)
            {
                case < 10:
                    beneficios = 2;
                    break;
                case >= 10 and <= 50:
                    beneficios = 3.5;
                    break;
                case > 50:
                    beneficios = 4;
                    break;
            }

            numerosPersonasACargo = value;
        }

        get
        {
            return numerosPersonasACargo;
        }
    }
    private double beneficios;
    public double Beneficios
    {
        get
        {
            return beneficios;
        }
    }

    private double pastaGanada;
    public double PastaGanada
    {
        get
        {
            return pastaGanada;
        }
    }

}

