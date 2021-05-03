using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }

        // ---------------------

        public void Vaccinate(Dog dog)
        {
            if (randomElement.NextDouble() <= DeathRate) // death chance
            {
                dog.Alive = false;
                Console.WriteLine($"Dog [{dog.ID}] died by vaccination from {this}!");
            }
            else
            {
                var sb = new StringBuilder();
                for (int i = 0; i < 3000; i++)
                {
                    sb.Append(Immunity[randomElement.Next(Immunity.Length)]);
                }

                dog.Immunity = sb.ToString();
                Console.WriteLine($"Dog [{dog.ID}] is now immune to {dog.Immunity}!");
            }
        }

        public void Vaccinate(Cat cat)
        {
            if (randomElement.NextDouble() <= DeathRate) // death chance
            {
                cat.Alive = false;
                Console.WriteLine($"Cat [{cat.ID}] died by vaccination from {this}!");
            }
            else
            {
                var sb = new StringBuilder();
                for (int i = 0; i < 300; i++)
                {
                    sb.Append(Immunity[randomElement.Next(Immunity.Length)]);
                }

                cat.Immunity = sb.ToString();
                Console.WriteLine($"Cat [{cat.ID}] is now immune to {cat.Immunity}!");
            }

        }

        public void Vaccinate(Pig pig)
        {
            if (randomElement.NextDouble() <= DeathRate) // death chance
            {
                pig.Alive = false;
                Console.WriteLine($"Pig [{pig.ID}] died by vaccination from {this}!");
            }
            else
            {
                var sb = new StringBuilder();
                for (int i = 0; i < 15; i++)
                {
                    sb.Append(Immunity[randomElement.Next(Immunity.Length)]);
                }

                pig.Immunity = sb.ToString();
                Console.WriteLine($"Pig [{pig.ID}] is now immune to {pig.Immunity}!");
            }
        }
    }
}
