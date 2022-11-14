using Bol4_Ejer4;
using System;

public class Horse
{
    public Horse(int position, int row)
    {
        this.position = position;
        this.row = row;
    }

    public void Run()
    {
        while (!Program.finish)
        {
            Thread.Sleep(50);// new Random().Next(1, 4) * 100);
            lock (Program.l)
            {
                if (!Program.finish)
                {
                    switch (1)//new Random().Next(1, 101))
                    {
                        case <= 75:
                            position++;
                            break;
                        case <= 100:
                            position += 2;
                            break;
                    }
                    Console.SetCursorPosition(0, Row);
                    Console.WriteLine(MAP);
                    Console.SetCursorPosition(Position, Row);
                    Console.Write("%");
                    if (ArriveGoal())
                    {
                        Program.finish = true;
                        Console.SetCursorPosition(position + 2, row);
                        Console.WriteLine("Win horse" + Row);
                        lock (Program.l)
                        {
                            Monitor.Pulse(Program.l);
                        }
                    }

                }
            }
        }
    }

    private bool ArriveGoal()
    {
        return Position >= MAP.Length;

    }

    private int row;
    public int Row
    {
        get
        {
            return row;
        }
    }
    private int position;
    public int Position
    {
        set
        {
            position = value;
        }

        get
        {
            return position;
        }
    }
    private const string MAP = "-------------------------------------------------------------------------|";
}
