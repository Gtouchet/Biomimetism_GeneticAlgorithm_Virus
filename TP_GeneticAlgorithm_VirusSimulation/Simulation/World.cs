using System;
using System.Collections.Generic;
using System.Linq;
using TP_GeneticAlgorithm_VirusSimulation.Utilitaries;

namespace TP_GeneticAlgorithm_VirusSimulation.Simulation
{
    public class World
    {
        private WorldConfiguration Configuration;
        private ConsoleHelper Console;

        private Virus Virus;
        private List<Human> Humans;

        private int WeekCount;
        private int InfectedThisWeek;
        private int DeadThisWeek;
        private int BirthThisWeek;

        private World(WorldConfiguration configuration, ConsoleHelper console)
        {
            this.Configuration = configuration;
            this.Console = console;

            this.Virus = new Virus();
            this.Humans = this.PopulateWorld().ToList();
            this.WeekCount = 0;

            this.RunSimulation();
        }

        public static World Of(WorldConfiguration configuration, ConsoleHelper console)
        {
            return new World(configuration, console);
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
            while (Enumerable.Range(0, this.Configuration.MaximumHumansCount).Contains(this.Humans.Count))
            {
                this.InfectionStep();
                this.ReproductionStep();

                this.Display();
            }
        }

        private void InfectionStep()
        {
            this.WeekCount += 1;
            this.InfectedThisWeek = 0;
            this.DeadThisWeek = 0;

            List<Human> deadHumans = new List<Human>();
            this.Humans.ForEach(human =>
            {
                if (!human.Infected)
                {
                    if (this.TryToInfect(human))
                    {
                        human.Infect();
                        this.InfectedThisWeek += 1;
                    }
                }
                else
                {
                    human.AddWeekOfInfection();

                    if (human.InfectedWeekCount.Equals(this.Configuration.WeeksBeforeDyingWhenInfected))
                    {
                        deadHumans.Add(human);
                        this.DeadThisWeek += 1;
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

            this.BirthThisWeek = this.Humans.Count - humanCountBeforeBirths;
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

            return new Random().Next(9) > sameGeneticCodeCount;
        }

        private void Display()
        {
            this.Console.Display($"{this.WeekCount}\n");
        }
    }
}
