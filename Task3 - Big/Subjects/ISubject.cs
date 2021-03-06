﻿using Task3.Vaccines;

namespace Task3.Subjects
{
    interface ISubject
    {
        public string ID { get; set; }
        public bool Alive { get; set; }
        public string Immunity { get; set; }

        void GetTested(VirusData virus);

        //-----

        public int ReverseVaccineShots { get; set; } // number of ReverseVaccineShots received
        public void GetVaccinatedBy(IVaccine vaccine);
    }
}
