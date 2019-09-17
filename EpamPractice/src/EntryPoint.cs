namespace EpamPractice
{
    class EntryPoint
    {
        public static void Main(string[] args)
        {
            ITask task;

            System.Console.WriteLine("It works!");
            while(true)
            {
                System.Console.Clear();
                System.Console.WriteLine(
                    "Choice what task to run!\n" +
                    "1. Task1 [Introduction to .net framework 4]\n" +
                    "2. Task2 [Basic programming constructs]\n" +
                    "Press \'e\' to exit");
                System.Console.Write("select option: ");
                var consoleKey = System.Console.ReadKey().Key;
                System.Console.WriteLine();
                switch(consoleKey)
                {
                    case System.ConsoleKey.E:
                    {
                        System.Console.WriteLine();
                        return;
                    }
                    case System.ConsoleKey.D1:
                    {
                        task = new Task1();
                        task.Visualize();
                        break;
                    }
                    case System.ConsoleKey.D2:
                    {
                        task = new Task2();
                        task.Visualize();
                        break;
                    }
                    default:
                    {
                        System.Console.WriteLine();
                        break;
                    }
                }
            }

        }
    }
}