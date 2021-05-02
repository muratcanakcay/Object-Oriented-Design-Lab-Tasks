using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "ReverseVaccine";
        }
        
        // ---------------------

        public void Vaccinate(Dog dog)
        {
            dog.Immunity = new string(Immunity.Reverse().ToArray());
            Console.WriteLine($"Dog [{dog.ID}] is now immune to {dog.Immunity}!");
        }

        public void Vaccinate(Cat cat) // kills the cat
        {
            cat.Alive = false;
            Console.WriteLine($"Cat [{cat.ID}] died by vaccination from {this}!");
        }

        public void Vaccinate(Pig pig)
        {
            if (randomElement.NextDouble() < this.DeathRate * pig.ReverseVaccineShots) // death chance
            {
                pig.Alive = false;
                Console.WriteLine($"Pig [{pig.ID}] died by vaccination from {this}!");
            }
            else
            {
                pig.Immunity = Immunity + new string(Immunity.Reverse().ToArray());
                Console.WriteLine($"Pig [{pig.ID}] had {++pig.ReverseVaccineShots} {this} shots and is now immune to {pig.Immunity}!");
            }
        }
    }
}
