namespace EpamPractice
{
    ///<summary>
    ///Класс для выполнения первого задания
    ///</summary>
    class Task1 : ITask
    {
        ///<summary>
        ///Конструктор по умолчанию
        ///</summary>
        public Task1()
        {
        }

        ///<summary>
        ///Метод для парсинга строки с двумя числами decimal типа
        ///</summary>
        ///<param name="input">строка с двумя числами decimal типа</param>
        private void ParseInput(string input)
        {
            System.String[] parsedString = input.Split(',');
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
            System.Console.Write("Press any button to continue ...");
            System.Console.ReadKey();
        }

        ///<summary>   
        ///Метод, реализующий логику
        ///</summary>
        private void Process()
        {
            while (true)
            {
                System.Console.WriteLine("1. Input from console\n2. Input from file\nPrint \'b\' to back!");
                System.Console.Write("select option: ");
                var consoleKey = System.Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case System.ConsoleKey.D1:
                    {
                        System.Console.WriteLine("Input pattern\n\t\t{x},{y}\nExample\n\t\tif x = 23.0123 and y = 0.123 then input \"23.0123,0.123\" without \"");
                        System.Console.Write("input: ");
                        System.String readedString = System.Console.ReadLine();
                        if (readedString.IndexOf(',') != -1)
                        {
                            ParseInput(readedString);
                        }
                        else
                        {
                            Utils.PrintErrorMessage("Input error! Look at the input pattern.\n");
                        }
                        break;
                    }
                    case System.ConsoleKey.D2:
                    {
                        var currentDirectory = 
                            System.IO.Directory.GetCurrentDirectory();
                        System.Console.WriteLine($"Current directory: {currentDirectory}");
                        var currentFiles = 
                            System.IO.Directory.GetFiles(currentDirectory);
                        System.Console.WriteLine("Current files:");
                        foreach (var file in currentFiles)
                        {
                            System.Console.WriteLine($"\t\t- {file}");
                        }    
                        System.Console.Write("write file path: ");
                        System.String filePath = System.Console.ReadLine();
                        if (System.IO.File.Exists(filePath))
                        {
                            System.String fileData = System.IO.File.ReadAllText(filePath);
                            if (fileData.IndexOf(',') != -1)
                            {
                                ParseInput(fileData);
                            }
                            else
                            {
                                Utils.PrintErrorMessage($"Data of {fileData} is incorrect!");
                            }
                        }
                        else 
                        {
                            Utils.PrintErrorMessage($"File {filePath} doesnt exist!");
                        }
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
            System.Console.WriteLine("Task1 [Introduction to .net framework 4]");
            Process();
            System.Console.Write("Press any button to continue ...");
            System.Console.ReadKey();
        }
    }
}