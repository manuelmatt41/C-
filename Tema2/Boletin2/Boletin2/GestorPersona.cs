using System;

public class GestorPersona
{
	public GestorPersona()
	{
		Workers = new List<Persona>();
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

	public bool Eliminar(int max,int min = 0)
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

	public List<Persona> Workers;
}
