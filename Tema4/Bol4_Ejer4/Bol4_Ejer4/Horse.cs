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
        while (!Map.finish)
        {
            Thread.Sleep(new Random().Next(1, 4) * 100);

            lock (Map.l)
            {
                switch (new Random().Next(1, 101))
                {
                    case <= 75:
                        position++;
                        break;
                    case <= 100:
                        position += 2;
                        break;
                }
            }
        }
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
}
