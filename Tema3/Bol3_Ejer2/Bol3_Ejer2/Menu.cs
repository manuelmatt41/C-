using System;

public class Menu
{
    public Menu(params string[] students)
    {
        this.Aula = new Aula(students);
    }

    public void Inicio()
    {
        int option;
        bool flag;
        int index;
        do
        {
            Console.WriteLine("Elige una opcion:\n1.Calcula la media de todas las notas\n" +
                                "2.Media de un alumno\n" +
                                "3.Media de una asignatura\n" +
                                "4.Visualizar la notas de un alumno\n" +
                                "5.Visualizar las notas de una asignatura\n" +
                                "6.Nota maxima y minima de un alumno" +
                                "7.Mostrar tabla\n" +
                                "8.Salir");
            flag = int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    Console.WriteLine($"la media de todas las notas es {Aula.AllAverageResults()}");
                    break;
                case 2:
                    index = requestNumber("Escribe el numero del estudiante que quiere ver la media", 1, Aula.Students.Count) + 1;
                    Console.WriteLine($"La media del alumno {Aula.Students[index - 1]} es: {Aula.StudentAverageResults(index - 1):.00}");
                    break;
                case 3:
                    index = requestNumber("Escribe el numero de la asignatura que quiere ver la media", 1, Aula.Results.GetLength(1) + 1);
                    Console.WriteLine($"La media de la asignatura {Aula.Subjects[index - 1]} es: {Aula.SubjectAverageResults(index - 1):.00}");
                    break;
                case 4:
                    index = requestNumber("Escribe el numero del estudiante que quiere ver las notas", 1, Aula.Students.Count + 1);
                    ShowResults(true, index - 1);
                    break;
                case 5:
                    index = requestNumber("Escribe el numero de la asignatura que quiere ver las notas", 1, Aula.Results.GetLength(1) + 1);
                    ShowResults(false, index - 1);
                    break;
                case 6:
                    int max;
                    int min;
                    index = requestNumber("Escribe el numero del estudiante que quiere ver la nota maxima y minima", 1, Aula.Students.Count + 1);
                    Aula.MaxAndMinResults(out max, out min, index - 1);
                    Console.WriteLine($"La nota maxima del alumno {Aula.Students[index - 1]} es {max}, y la minima es {min}");
                    break;
                case 7:
                    ShowTable();
                    break;
            }
        } while (!flag || option != 8);
    }

    private void ShowTable()
    {
        Console.Write($"{"",-15}");
        foreach (string subject in Aula.Subjects)
        {
        Console.Write($"{subject, -15}");
        }

        Console.WriteLine();
        for (int i = 0; i < Aula.Results.GetLength(0); i++)
        {
            Console.Write($"{Aula.Students[i],-15}");

            for (int j = 0; j < Aula.Results.GetLength(1); j++)
            {
                Console.Write($"{Aula[i, j], -15}");
            }

            Console.WriteLine();
        }
    }

    private void ShowResults(bool flag, int index)
    {
        Console.WriteLine("{0}:\n", flag ? Aula.Students[index] : Aula.Subjects[index]);
        for (int i = 0; i < Aula.Results.GetLength(flag ? 1 : 0); i++)
        {
            Console.WriteLine($"{Aula[flag ? index : i, flag ? i : index]}");
        }
    }

    private int requestNumber(string question, int minNumebr, int maxNumber)
    {
        int number;
        bool error;
        do
        {
            Console.WriteLine(question);
            error = int.TryParse(Console.ReadLine(), out number);
        } while (!error || number < minNumebr || number >= maxNumber);

        return number;
    }

    public Aula Aula;
}
