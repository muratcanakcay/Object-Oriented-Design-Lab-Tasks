using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }
        
        // ---------------------

        public void Vaccinate(Dog dog)
        {
            dog.Immunity = Immunity;
            Console.WriteLine($"Dog [{dog.ID}] is now immune to {dog.Immunity}!");
        }

        public void Vaccinate(Cat cat)
        {
            
            if (randomElement.NextDouble() < this.DeathRate) // death chance
            {
                cat.Alive = false;
                Console.WriteLine($"Cat [{cat.ID}] died by vaccination from {this}!");
            }
            else
            {
                cat.Immunity = new string(Immunity.Skip(3).ToArray());
                Console.WriteLine($"Cat [{cat.ID}] is now immune to {cat.Immunity}!");
            }
        }

        public void Vaccinate(Pig pig) // kills the pig
        {
            pig.Alive = false;
            Console.WriteLine($"Pig [{pig.ID}] died by vaccination from {this}!");
        }
    }
}
