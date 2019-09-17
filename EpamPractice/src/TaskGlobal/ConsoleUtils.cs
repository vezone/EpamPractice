namespace EpamPractice
{
    static class Utils
    {
        static public void PrintErrorMessage(string message)
        {
            var foregroundColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Error: " + message);
            System.Console.ForegroundColor = foregroundColor;
        } 
    }
}