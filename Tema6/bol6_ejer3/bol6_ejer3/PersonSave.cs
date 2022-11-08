using System;

namespace bol6_ejer3
{
    internal class PersonWritter : BinaryWriter
    {
        public PersonWritter(Stream str) : base(str)
        {
        }

        public void Write(Persona p)
        {
            base.Write(p.Nombre);
            base.Write(p.Apellidos);
            base.Write(p.Edad);
            base.Write(p.Dni);
        }

        public void Write(Empleado e)
        {
            Write((Persona)e);
            base.Write(e.Salario);
            base.Write(e.Telefono);
        }

        public void Write(Directivo d)
        {
            Write((Persona)d);
            base.Write(d.Departamento);
            base.Write(d.NumeroPersonasACargo);
        }
    }

    internal class PersonReader : BinaryReader
    {
        public PersonReader(Stream str) : base(str)
        {
        }

        public Empleado ReadEmpleado()
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = base.ReadString();
            empleado.Apellidos = base.ReadString();
            empleado.Edad = base.ReadInt32();
            empleado.Dni = base.ReadString();
            empleado.Salario = base.ReadDouble();
            empleado.Telefono = base.ReadString();
            return empleado;
        }
        public Directivo ReadDirectivo()
        {
            Directivo directivo = new Directivo();
            directivo.Nombre = base.ReadString();
            directivo.Apellidos = base.ReadString();
            directivo.Edad = base.ReadInt32();
            directivo.Dni = base.ReadString();
            directivo.Departamento = base.ReadString();
            directivo.NumeroPersonasACargo = base.ReadInt32();
            return directivo;
        }
    }
}
