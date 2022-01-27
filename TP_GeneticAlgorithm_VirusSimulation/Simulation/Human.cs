using System;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation
{
    public class Human
    {
        public byte[] GeneticCode { get; private set; }
        public bool Infected { get; private set; }
        public int InfectedWeekCount { get; private set; }

        private Human()
        {
            this.GeneticCode = this.GenerateGeneticCode();
            this.Infected = false;
            this.InfectedWeekCount = 0;
        }

        private Human(byte[] geneticCode)
        {
            this.GeneticCode = geneticCode;
            this.Infected = false;
            this.InfectedWeekCount = 0;
        }

        public static Human Of()
        {
            return new Human();
        }

        public static Human Of(byte[] geneticCode)
        {
            return new Human(geneticCode);
        }

        private byte[] GenerateGeneticCode()
        {
            byte[] geneticCode = new byte[8];
            Random rng = new Random();
            for (int i = 0; i < 8; i += 1)
            {
                geneticCode[i] = (byte) rng.Next(2);
            }
            return geneticCode;
        }

        public void Infect()
        {
            this.Infected = true;
        }

        public void AddWeekOfInfection()
        {
            this.InfectedWeekCount += 1;
        }

        override
        public string ToString()
        {
            string code = "";
            for (int i = 0; i < 8; i += 1)
            {
                code += this.GeneticCode[i];
            }
            return code;
        }
    }
}
