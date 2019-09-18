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
                    x1 = (1.0 / n) * ((n - 1.0) * x0 + number / Pow(x0, n - 1.0));
                }
                return x1;
            }
        }

        private struct Converter
        {
            private static System.UInt32 GetRankOf(System.UInt32 number)
            {
                System.UInt32 rank = 0;
                while (true)
                {
                    number /= 10;
                    if (number != 0) { rank++; }
                    else { return rank; }
                }
            }

            private static System.UInt32 GetNumberWithRank(System.UInt32 number, System.UInt32 rank)
            {
                if (rank > 0)
                {
                    for (System.UInt32 i = 0; i < rank; i++) { number *= 10; }
                }
                return number;
            }

            private static System.UInt32 GetNumberOfDigit(System.UInt32 number, System.UInt32 digit)
            {
                if (GetRankOf(number) < digit) { return 0; }
                if (digit == 0) { return (number % 10); }
                number %= GetNumberWithRank(1, digit + 1);
                number /= GetNumberWithRank(1, digit);
                return number;
            }


            //1023
            public static System.String ConvertUint32ToString(System.UInt32 number)
            {
                System.UInt32 rank = GetRankOf(number);
                System.UInt32 numberLength = rank + 1;
                System.Char[] result = new System.Char[numberLength];
                for (System.UInt32 i = 0; i < numberLength; i++)
                {
                    result[i] = (System.Char)(GetNumberOfDigit(number, rank)) + '0';
                    rank--;
                }
                System.Console.WriteLine($"rank={rank}");
                return result.ToString();
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
                System.Console.WriteLine();
                switch (consoleKey)
                {
                    case System.ConsoleKey.D1:
                    {
                        System.Double eps;
                        System.Int32 n;
                        System.Console.Write("Write number: ");
                        System.String readedValue = System.Console.ReadLine();
                        System.Console.Write("Write eps [press enter if eps == 0.001]: ");
                        System.String readedEps = System.Console.ReadLine();
                        System.Console.Write("Write n [press enter if n == 2]: ");
                        System.String readedN = System.Console.ReadLine();
                        if (readedEps.Length > 0)
                        {
                            if (!System.Double.TryParse(readedEps, out eps))
                            {
                                eps = 0.001;
                                Utils.PrintErrorMessage("Eps value is not correct! Eps set to 0.001");
                            }
                        }
                        else { eps = 0.001; }

                        if (readedN.Length > 0)
                        {
                            if (!System.Int32.TryParse(readedN, out n))
                            {
                                n = 2;
                                Utils.PrintErrorMessage("N value is not correct! N set to 2.");
                            }
                        }
                        else { n = 2; }

                        if (readedValue.Contains("."))
                        {
                            System.Double value;
                            if (System.Double.TryParse(readedValue, out value))
                            {
                                var result = Newton.CalculateSqrtOfN(value, (System.Double)n);
                                System.Console.WriteLine($"eps: {eps}");
                                System.Console.WriteLine($"result: {result}");
                                System.Console.WriteLine($"right result: {System.Math.Pow(value, 1.0/n)}");
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
                                var result = Newton.CalculateSqrtOfN((System.Double)value, (System.Double)n);
                                System.Console.WriteLine($"eps: {eps}");
                                System.Console.WriteLine($"result: {result}");
                                System.Console.WriteLine($"right result: {System.Math.Pow((System.Double)value, 1.0/n)}");
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
                        System.Console.WriteLine($"result: {Converter.ConvertUint32ToString(1023)}");
                        System.Console.Write("Press any button to continue ...");
                        System.Console.ReadKey();
                        break;
                    }
                    case System.ConsoleKey.D3:
                    {
                        //With .net
                        System.Console.Write("Press any button to continue ...");
                        System.Console.ReadKey();
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