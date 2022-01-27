using TP_GeneticAlgorithm_VirusSimulation.Simulation.Reproduction;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation
{
    public class WorldConfiguration
    {
        public int StartingHumanCount;
        public int MaximumHumansCount;
        public int YearsBeforeDyingWhenInfected;
        public ReproductionType ReproductionType;

        override
        public string ToString()
        {
            return
                $"Biomimetism - Genetic Algorithm - Virus vs Humans\n\n" +
                $"Starting configuration :\n" +
                $" - {this.StartingHumanCount} humans\n" +
                $" - {this.YearsBeforeDyingWhenInfected} years before dying when infected\n" +
                $" - The simulation will stop when all humans are dead or if their population exceeds {this.MaximumHumansCount}\n" +
                $" - The reproduction type is {this.ReproductionType.GetName()}, this means {this.ReproductionType.GetDescription()}.\n\n" +
                $"Press any key to continue";
        }
    }
}
