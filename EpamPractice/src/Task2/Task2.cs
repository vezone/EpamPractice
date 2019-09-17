namespace EpamPractice
{
    class Task2 : ITask
    {

        private struct Newton
        {
            private static System.Double Abs(System.Double input)
            {
                if (input < 0) { return -input; }
                else           { return  input; }
            }

            private static System.Double Pow(System.Double input, System.Double n)
            {
                System.Double result = 1.0;
                while (n-- > 0) { result *= input; }
                return result;
            }

            public static System.Double CalculateSqrtOfN(
                System.Double number, System.Double n=2.0, System.Double eps=0.001)
            {
                var x0 = number / n;
                var x1 = (1.0 / n) * ((n - 1.0) * x0 + number / Pow(x0, (System.Int32)n - 1.0));
                while (Abs(x1 - x0) > eps) 
                {
                    x0 = x1;
                    x1 = (1.0 / n) * ((n - 1.0) * x0 + number / Pow(x0, (System.Double)n - 1.0));
                }
                return x1;
            }
        }

        public Task2()
        {
        }

        private void Process()
        {
            while (true)
            {
                System.Console.WriteLine("1. Calculate root of number\n2. \nPrint \'b\' to back!");
                System.Console.Write("select option: ");
                var consoleKey = System.Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case System.ConsoleKey.D1:
                    {
                        System.Console.WriteLine();
                        System.Double eps;
                        System.Console.Write("Write number: ");
                        System.String readedValue = System.Console.ReadLine();
                        System.Console.Write("Write eps [press enter if eps == 0.001]: ");
                        System.String readedEps = System.Console.ReadLine();
                        if (readedEps.Length > 0)
                        {
                            if (!System.Double.TryParse(readedEps, out eps))
                            {
                                eps = 0.001;
                                Utils.PrintErrorMessage("Eps value is not correct! Eps set to 0.001");
                            }
                        }
                        else { eps = 0.001; }

                        if (readedValue.Contains("."))
                        {
                            System.Double value;
                            if (System.Double.TryParse(readedValue, out value))
                            {
                                var result = Newton.CalculateSqrtOfN(value, 2.0);
                                System.Console.WriteLine($"eps: {eps}");
                                System.Console.WriteLine($"result: {result}");
                                System.Console.WriteLine($"right result: {System.Math.Pow(value, 0.5)}");
                            }
                            else
                            {
                                Utils.PrintErrorMessage("Unknown input type");
                            }
                        }
                        else
                        {
                            System.Int32 value;
                            if (System.Int32.TryParse(readedValue, out value))
                            {
                                var result = Newton.CalculateSqrtOfN((System.Double)value, 2.0);
                                System.Console.WriteLine($"eps: {eps}");
                                System.Console.WriteLine($"result: {result}");
                                System.Console.WriteLine($"right result: {System.Math.Pow((System.Double)value, 0.5)}");
                            }
                            else
                            {
                                Utils.PrintErrorMessage("Unknown input type");
                            }
                        }
                        System.Console.Write("Press any button to continue ...");
                        System.Console.ReadKey();
                        break;
                    }
                    case System.ConsoleKey.D2:
                    {
                        //MyConverter
                        System.Console.WriteLine();
                        break;
                    }
                    case System.ConsoleKey.D3:
                    {
                        //With .net
                        System.Console.WriteLine();
                        break;
                    }
                    case System.ConsoleKey.B:
                    {
                        System.Console.WriteLine();
                        return;
                    }
                }
                System.Console.Clear();
            }
        }

        ///<summary>
        ///Метод, вызываемый из EntryPoint
        ///</summary>
        public void Visualize()
        {
            System.Console.Clear();
            System.Console.WriteLine("Task2 [Basic programming constructs]");
            Process();
            System.Console.Write("Press any button to continue ...");
            System.Console.ReadKey();
        }
    }
}