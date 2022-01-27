using TP_GeneticAlgorithm_VirusSimulation.Simulation;
using TP_GeneticAlgorithm_VirusSimulation.Simulation.Reproduction;

namespace TP_GeneticAlgorithm_VirusSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            World world = World.Of(new WorldConfiguration()
            {
                StartingHumanCount = 100,
                MaximumHumansCount = 10000,
                YearsBeforeDyingWhenInfected = 3,
                ReproductionType = new RandomReproduction(),
            });
        }
    }
}
