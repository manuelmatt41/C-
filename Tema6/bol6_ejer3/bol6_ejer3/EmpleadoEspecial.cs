using System;

namespace bol6_ejer3
{
    public class EmpleadoEspecial : Empleado, IPastaGansa
    {
        public EmpleadoEspecial(string Nombre, string Apellidos, int Edad, string Dni, double Salario, string Telefono)
            : base(Nombre, Apellidos, Edad, Dni, Salario, Telefono)
        {
        }

        public double PastaGansa(double Beneficios)
        {
            return 5 * Beneficios / 1000;
        }

        public override double Hacienda()
        {
            return base.Hacienda() + PastaGansa(base.Hacienda());
        }
    }
}
