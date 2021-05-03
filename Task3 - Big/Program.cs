using System;
using System.Collections.Generic;
using Task3.Decorators;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(IVirusDatabaseIterator dbIterator)
            {
                while(dbIterator.HasNext())
                {
                    dbIterator.Next();
                    System.Console.WriteLine(dbIterator.Current());
                }
            }
            
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"\nTesting {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        // process of vaccination
                        subject.GetVaccinatedBy(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function

                    var simpleDatabaseIterator = simpleDatabase.GetIterator(genomeDatabase);
                    // iterating over simpleDatabase
                    
                    while (simpleDatabaseIterator.HasNext())
                    {
                        simpleDatabaseIterator.Next();

                        foreach (var subject in subjects)
                        {
                            subject.GetTested(simpleDatabaseIterator.Current());
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!\n");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            // Part 1 - publishing each virus database
            Console.WriteLine("\n-------------simpleDatabase output ----------------\n");
            var simpleIterator = simpleDatabase.GetIterator(genomeDatabase);
            mediaOutlet.Publish(simpleIterator);
            
            Console.WriteLine("\n-------------excellDatabase output ----------------\n");
            var excellIterator = excellDatabase.GetIterator(genomeDatabase);
            mediaOutlet.Publish(excellIterator);

            Console.WriteLine("\n-------------overcomplicatedDatabase output -------\n");
            var overcomplicatedIterator = overcomplicatedDatabase.GetIterator(genomeDatabase);
            mediaOutlet.Publish(overcomplicatedIterator);

            
            // Part 2 - decorators
            Console.WriteLine("\n-------------filtering DeathRate > 15 of data from the ExcellDatabase database -------\n");
            var filteredIterator1 = new Filter((virus) => virus.DeathRate > 15, excellDatabase.GetIterator(genomeDatabase));
            mediaOutlet.Publish(filteredIterator1);

            Console.WriteLine("\n-------------mapping f => new VirusData(f.VirusName, f.DeathRate + 10, f.InfectionRate, f.Genomes) and the filter f => f.DeathRate > 15 simultaneously of data from the ExcellDatabase database -------\n");
            var filteredMappedIterator = new Filter(f => f.DeathRate > 15, 
                                  new Map(f => new VirusData(f.VirusName, f.DeathRate + 10, f.InfectionRate, f.Genomes), 
                                         excellDatabase.GetIterator(genomeDatabase)));
            mediaOutlet.Publish(filteredMappedIterator);

            Console.WriteLine("\n-------------concatenation of data from the ExcellDatabase database and data from the OvercomplicatedDatabase database -------\n");
            var concatonatedIterator = new Concatenate(excellDatabase.GetIterator(genomeDatabase), overcomplicatedDatabase.GetIterator(genomeDatabase));
            mediaOutlet.Publish(concatonatedIterator);

            // Part 3 - visitor

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
