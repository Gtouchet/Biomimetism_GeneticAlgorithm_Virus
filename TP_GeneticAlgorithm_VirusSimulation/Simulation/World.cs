using System;
using System.Collections.Generic;
using System.Linq;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation
{
    public class World
    {
        private WorldConfiguration Configuration;

        private Virus Virus;
        private List<Human> Humans;

        private int YearCount;
        private int AliveCountBeforeYear;
        private int DeathThisYear;
        private int BirthThisYear;
        private int InfectionThisYear;

        private World(WorldConfiguration configuration)
        {
            this.Configuration = configuration;

            this.Virus = new Virus();
            this.Humans = this.PopulateWorld().ToList();
            this.YearCount = 0;

            this.RunSimulation();
        }

        public static World Of(WorldConfiguration configuration)
        {
            return new World(configuration);
        }

        private IEnumerable<Human> PopulateWorld()
        {
            for (int i = 0; i < this.Configuration.StartingHumanCount; i += 1)
            {
                yield return Human.Of();
            }
        }

        private void RunSimulation()
        {
            Console.WriteLine(this.Configuration);
            Console.ReadKey();
            Console.Clear();

            while (Enumerable.Range(1, this.Configuration.MaximumHumansCount).Contains(this.Humans.Count))
            {
                this.InfectionStep();
                this.ReproductionStep();

                Console.WriteLine(this);
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void InfectionStep()
        {
            this.YearCount += 1;
            this.AliveCountBeforeYear = this.Humans.Count;
            this.InfectionThisYear = 0;
            this.DeathThisYear = 0;

            List<Human> deadHumans = new List<Human>();
            this.Humans.ForEach(human =>
            {
                if (!human.Infected)
                {
                    if (this.TryToInfect(human))
                    {
                        human.Infect();
                        this.InfectionThisYear += 1;
                    }
                }
                else
                {
                    human.AddWeekOfInfection();

                    if (human.InfectedWeekCount.Equals(this.Configuration.YearsBeforeDyingWhenInfected))
                    {
                        deadHumans.Add(human);
                        this.DeathThisYear += 1;
                    }
                }
            });

            deadHumans.ForEach(deadHuman =>
            {
                this.Humans.Remove(deadHuman);
            });
        }

        private void ReproductionStep()
        {
            int humanCountBeforeBirths = this.Humans.Count;

            this.Humans = this.Configuration.ReproductionType.Handle(this.Humans);

            this.BirthThisYear = this.Humans.Count - humanCountBeforeBirths;
        }

        private bool TryToInfect(Human human)
        {
            int sameGeneticCodeCount = 0;

            for (int i = 0; i < 8; i += 1)
            {
                if (this.Virus.GeneticCode[i].Equals(human.GeneticCode[i]))
                {
                    sameGeneticCodeCount += 1;
                }
            }

            return new Random().Next(9) > sameGeneticCodeCount / 2;
        }

        override
        public string ToString()
        {
            return
                $"Year {this.YearCount} :\n" +
                $" - Alive humans at the beginning of the year : {this.AliveCountBeforeYear}\n" +
                $" - Death : {this.DeathThisYear}\n" +
                $" - Birth : {this.BirthThisYear}\n" +
                $" - Infections : {this.InfectionThisYear}\n" +
                $" - Alive humans at the end of the year : {this.Humans.Count}\n\n" +
                $"Press any key to continue";
        }
    }
}
