using System;
using System.Collections.Generic;
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
                    System.Console.WriteLine(dbIterator.Current().ToString());
                    dbIterator.Next();
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
                    Console.WriteLine($"Testing {vaccine}");
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
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function


                    // iterating over simpleDatabase
                    //{
                        //foreach (var subject in subjects)
                        //{
                        //    subject.GetTested();
                        //}
                    //}

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
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
            var excellIterator = IteratorFactory.GetIterator(excellDatabase, genomeDatabase);
            mediaOutlet.Publish(excellIterator);
            Console.WriteLine("\n-------------overcomplicatedDatabase output -------\n");
            var overcomplicatedIterator = IteratorFactory.GetIterator(overcomplicatedDatabase, genomeDatabase);
            mediaOutlet.Publish(overcomplicatedIterator);


            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
