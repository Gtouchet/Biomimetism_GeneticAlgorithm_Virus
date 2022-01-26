using System.Collections.Generic;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation.Reproduction
{
    public interface ReproductionType // TODO add more types (concours etc)
    {
        public List<Human> Handle(List<Human> humans);
    }
}
