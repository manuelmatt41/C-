using Bol4_Ejer4;
using System;

public class Map
{
    public Map(int numberHorses)
    {
        horsesThreads = new Thread[numberHorses];
        horses = new Horse[numberHorses];

        for (int i = 0; i < horses.Length; i++)
        {
            horses[i] = new Horse(0, i);
        }
        GOAL = MAP.Length;
        Console.Clear();
        RunAllHorses();
        UpdateMap();
    }

    public void UpdateMap()
    {
        while (!finish)
        {
            for (int i = 0; i < horses.Length && !finish; i++)
            {
                MoveHorses(horses[i]);

                if (ArriveGoal(horses[i]))
                {
                    finish = true;
                    winnerHorse = horses[i];
                }
            }
        }
    }

    private void RunAllHorses()
    {
        for (int i = 0; i < horsesThreads.Length; i++)
        {
            horsesThreads[i] = new Thread(horses[i].Run);
            horsesThreads[i].Start();
        }
    }

    private void MoveHorses(Horse horse)
    {
        Console.SetCursorPosition(0, horse.Row);
        Console.WriteLine(MAP);
        Console.SetCursorPosition(horse.Position, horse.Row);
        Console.Write("%");
    }

    private bool ArriveGoal(Horse horse)
    {
        return horse.Position == GOAL;

    }

    private Thread[] horsesThreads;
    public Thread[] HorseThreads
    {
        get
        {
            return horsesThreads;
        }
    }

    private Horse[] horses;
    private Horse winnerHorse;
    public Horse WinnerHorse
    {
        get
        {
            return winnerHorse;
        }
    }
    private const string MAP = "-------------------------------------------------------------------------|";
    private int GOAL;
    public static readonly Object l = new object();
    public static bool finish = false;
}
