using System;

namespace LegalX
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Processor p = new Processor();
                p.Process();

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine($"Error message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgram exited");
            }
        }
    }
}