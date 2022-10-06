using System;

public class MyTimer
{
    public MyTimer(MyTimerEventHandler myTimerEventHandler)
    {
        this.myTimerEventHandler = myTimerEventHandler;
        new Thread(Execute).Start();
    }

    private void Execute()
    {
        lock (l)
        {
            Monitor.Wait(l);
        }

        while (!finish)
        {
            myTimerEventHandler.Invoke();
            Thread.Sleep(Interval);
        }

        Execute();
    }

    public void Run()
    {
        lock (l)
        {
            finish = false;
            Monitor.Pulse(l);
        }
    }

    public void Pause()
    {
        finish = true;
    }

    public delegate void MyTimerEventHandler();
    public readonly Object l = new Object();
    public int Interval { get; set; }
    private bool finish;
    private MyTimerEventHandler myTimerEventHandler;
}
