using System;
using System.Collections.Generic;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation.Reproduction
{
    public class RandomReproduction : ReproductionType
    {
        public List<Human> Handle(List<Human> humans)
        {
            Random rng = new Random();
            for (int i = 0; i < humans.Count / 4; i += 1)
            {
                Human mother = humans[rng.Next(humans.Count)];
                Human father = humans[rng.Next(humans.Count)];

                byte[] childGeneticCode = new byte[8];
                for (int j = 0; j < 8; j += 1)
                {
                    childGeneticCode[j] = rng.Next(2) == 1 ? mother.GeneticCode[j] : father.GeneticCode[j];
                }
                humans.Add(Human.Of(childGeneticCode));
            }
            return humans;
        }
    }
}
