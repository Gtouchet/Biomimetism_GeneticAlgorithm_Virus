using System.Collections.Generic;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation.Reproduction
{
    public interface ReproductionType // TODO add more types (concours etc)
    {
        public string GetName();
        public string GetDescription();
        public List<Human> Handle(List<Human> humans);
    }
}
