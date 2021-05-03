﻿using System;
using Task3.Vaccines;

namespace Task3.Subjects
{
    class Pig : ISubject
    {
        public bool Alive { get; set; } = true;
        public string Immunity { get; set; } = "";
        public string ID { get; set; }
        public Pig(string id)
        {
            ID = id;
        }

        public void GetTested(VirusData virus)
        {
            if (!Alive) return;
            foreach (var genome in virus.Genomes)
            {
                if (!Immunity.Contains(genome.Genome))
                {
                    Alive = false;
                    Console.WriteLine($"Pig {ID} is dead");
                    return;
                }
            }
        }

        
        // ------------

        public int ReverseVaccineShots { get; set; } 
        public void GetVaccinatedBy(IVaccine vaccine)
        {
            if (!Alive) return;
            Console.WriteLine($"------- Pig [{ID}] is getting vaccinated by {vaccine}");
            vaccine.Vaccinate(this);
        }
    }
}
