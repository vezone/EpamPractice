using System;

namespace EpamPractice
{
    class ReaderFormatter : ITask
    {
        public ReaderFormatter()
        {
            //do nothing
        }

        private void Process()
        {
            System.Console.WriteLine("1. Input from console\n2. Input from file\nPrint \'e\' to exit!");
            var consoleKey = System.Console.ReadKey().Key;
            while (true)
            {
                switch (consoleKey)
                {
                    case System.ConsoleKey.D1:
                    {
                        System.Console.WriteLine("Input patter\n\t\t{x},{y}\nExample\n\t\tif x = 23.0123 and y = 0.123 then input \"23.0123,0.123\" without \"");
                        System.Console.Write("Input: ");
                        string readedString = System.Console.ReadLine();
                        if (readedString.IndexOf(',') != -1)
                        {
                            string[] parsedString = readedString.Split(',');
                            System.Decimal x; 
                            System.Decimal y;
                            if (System.Decimal.TryParse(parsedString[0], out x))
                            {
                                System.Console.Write($"X: {x} ");
                                if (System.Decimal.TryParse(parsedString[1], out y))
                                {
                                    System.Console.Write($"Y: {y}\n");
                                }
                                else
                                {
                                    Utils.PrintErrorMessage("Y is not System.Decimal");
                                }   
                            } 
                            else
                            {
                                Utils.PrintErrorMessage("X is not System.Decimal");
                            }
                        }
                        else
                        {
                            Utils.PrintErrorMessage("Input error! Look at the input pattern.\n");
                        }
                        break;
                    }
                    case System.ConsoleKey.D2:
                    {
                        //
                        break;
                    }
                    case System.ConsoleKey.E:
                    {
                        return;
                    }
                }
            }
        }

        public void Visualize()
        {
            Console.WriteLine("Visualizing ...");
            Process();
            System.Console.Write("Press any button to continue ...");
            System.Console.ReadKey();
        }
    }
}