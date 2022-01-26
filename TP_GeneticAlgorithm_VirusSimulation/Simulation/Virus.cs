using System;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation
{
    public class Virus
    {
        public byte[] GeneticCode { get; private set; }

        public Virus()
        {
            this.GeneticCode = this.GenerateGeneticCode();
        }

        private byte[] GenerateGeneticCode()
        {
            byte[] geneticCode = new byte[8];
            Random rng = new Random();
            for (int i = 0; i < 8; i += 1)
            {
                geneticCode[i] = (byte)rng.Next(2);
            }
            return geneticCode;
        }
    }
}
