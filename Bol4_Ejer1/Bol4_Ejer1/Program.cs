delegate void MyDelegate();

class Program
{
    void MenuGenerator(string[] options, MyDelegate[] myDelegates)
    {
        if (options.Length == myDelegates.Length)
        {
            int option;
            bool error;
            do
            {
                Console.WriteLine("Choose an option:");
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}.{options[i]}");
                }

                Console.WriteLine($"{options.Length + 1}.Exit");

                do
                {
                    error = int.TryParse(Console.ReadLine(), out option);

                    if (option < 1 || option > options.Length + 1)
                    {
                        Console.WriteLine("The option doesnt exist");
                    }

                    if (!error)
                    {
                        Console.WriteLine("Only numebrs are allowed");
                    }
                } while (!error || option < 1 || option > options.Length + 1);

                if (option < options.Length + 1)
                {
                    myDelegates[option - 1].Invoke();
                }

            } while (option != options.Length + 1);
        }
        else
        {
            Console.WriteLine("Invalid menu");
        }
    }

    static void Main(string[] args)
    {
        Program p = new Program();
        p.MenuGenerator(new string[] { "Op1", "Op2", "Op3","Q"}, new MyDelegate[] { () => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C") , () => Console.WriteLine("d") });
    }
}
