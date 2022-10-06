namespace Boletin2
{
    internal class Program
    {

        //static void mostrarPasta(IPastaGansa IPastaGansa)
        //{
        //    int BeneficiosEmpresa = 0;
        //    bool Error = false;
        //    Console.WriteLine("Cuanto dinero ha ganado la empresa");

        //    do
        //    {
        //        try
        //        {
        //            BeneficiosEmpresa = Convert.ToInt32(Console.ReadLine());
        //        }
        //        catch (FormatException e)
        //        {
        //            Console.WriteLine(e.Message);
        //            Error = true;
        //        }

        //    } while (BeneficiosEmpresa < 0 || Error);

        //    Console.WriteLine("Has generado: {0}", IPastaGansa.PastaGansa(BeneficiosEmpresa));
        //}

        //static void mostrarHacienda(Persona Persona)
        //{
        //    Console.WriteLine("Hacienda ha ganado: {0}", Persona.Hacienda());
        //}
        static void Main(string[] args)
        {
            InterfazUsuario interfaz = new InterfazUsuario();
            interfaz.Start();

        }
    }
}