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
        Console.Clear();
    }

    public void RunAllHorses()
    {
        for (int i = 0; i < horsesThreads.Length; i++)
        {
            horsesThreads[i] = new Thread(horses[i].Run);
            horsesThreads[i].Start();
        }
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
}
