using System;
using System.Collections.Generic;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation.Reproduction
{
    public class RandomReproduction : ReproductionType
    {
        private string Name = "random";
        private string Description = "there will be no regulation on reproductions";

        public string GetName()
        {
            return this.Name;
        }

        public string GetDescription()
        {
            return this.Description;
        }

        public List<Human> Handle(List<Human> humans)
        {
            Random rng = new Random();
            for (int i = 0; i < humans.Count / 8; i += 1)
            {
                Human mother = humans[rng.Next(humans.Count)];
                Human father = humans[rng.Next(humans.Count)];

                byte[] childGeneticCode = {
                    mother.GeneticCode[0],
                    mother.GeneticCode[1],
                    mother.GeneticCode[2],
                    mother.GeneticCode[3],
                    father.GeneticCode[4],
                    father.GeneticCode[5],
                    father.GeneticCode[6],
                    father.GeneticCode[7],
                };
                humans.Add(Human.Of(childGeneticCode));
            }
            return humans;
        }
    }
}
