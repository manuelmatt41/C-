using System;
using System.Collections.Generic;

public class Aula
{
    public Aula(string[] students)
    {
        this.Students = RemoveNoStudents(students);
        Results = new int[Students.Count, Subjects.Length];

        for (int i = 0; i < Results.GetLength(0); i++)
        {
            for (int j = 0; j < Results.GetLength(1); j++)
            {
                Results[i, j] = new Random().Next(1, 11);
            }
        }

        StartResults();
    }
    public Aula(string students)
    {
        this.Students = RemoveNoStudents(students.Split(","));
        Results = new int[Students.Count, Subjects.Length];
        StartResults();
    }

    public double AllAverageResults()
    {
        int acum = 0;

        foreach (int result in Results)
        {
            acum += result;
        }

        return acum / Results.Length;
    }

    public double StudentAverageResults(int studentIndex)
    {
        int acum = 0;

        for (int i = 0; i < Results.GetLength(1); i++)
        {
            acum += Results[studentIndex, i];
        }

        return acum / Results.GetLength(1);
    }

    public double SubjectAverageResults(int subjectIndex)
    {
        int acum = 0;

        for (int i = 0; i < Results.GetLength(0); i++)
        {
            acum += Results[i, subjectIndex];
        }

        return acum / Results.GetLength(0);
    }

    public void MaxAndMinResults(out int max, out int min, int studentIndex)
    {
        max = -1;
        min = 11;
        if (studentIndex >= 0)
        {
            for (int i = 0; i < Results.GetLength(1); i++)
            {
                if (max < Results[studentIndex, i])
                {
                    max = Results[studentIndex, i];
                }

                if (min > Results[studentIndex, i])
                {
                    min = Results[studentIndex, i];
                }
            }
        }
    }

    public List<string> RemoveNoStudents(string[] possibleStudents)
    {
        List<String> trueStudents = new List<string>();
        bool isStudent;

        for (int i = 0; i < possibleStudents.Length; i++)
        {
            possibleStudents[i] = possibleStudents[i].Trim().ToUpper();
            isStudent = true;

            for (int j = 0; j < possibleStudents[i].Length; j++)
            {
                if (possibleStudents[i][j] < 'A' || possibleStudents[i][j] > 'Z')
                {
                    isStudent = false;
                }

            }

            if (isStudent)
            {
                trueStudents.Add(possibleStudents[i]);
            }
        }

        return trueStudents;
    }

    private void StartResults()
    {
        for (int i = 0; i < Results.GetLength(0); i++)
        {
            for (int j = 0; j < Results.GetLength(1); j++)
            {
                Results[i, j] = new Random().Next(1, 11);
            }
        }
    }

    public int[,] Results { get; set; }
    public int this[int row, int col]
    {
        set
        {
            Results[row, col] = value;
        }

        get
        {
            return Results[row, col];
        }
    }
    public List<string> Students;
    public string[] Subjects = Enum.GetNames(typeof(Subjects));
}
