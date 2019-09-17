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
                    "1. Task1 [Introduction to .net framework 4]");
                System.Console.Write("print number: ");
                var consoleKey = System.Console.ReadKey().Key;
                System.Console.WriteLine();
                switch(consoleKey)
                {
                    case System.ConsoleKey.E:
                    {
                        return;
                    }
                    case System.ConsoleKey.D1:
                    {
                        task = new ReaderFormatter();
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