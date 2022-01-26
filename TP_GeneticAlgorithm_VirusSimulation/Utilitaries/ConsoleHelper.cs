using System;

namespace TP_GeneticAlgorithm_VirusSimulation.Utilitaries
{
    public class ConsoleHelper
    {
        public void Display(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
