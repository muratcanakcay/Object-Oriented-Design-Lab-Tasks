using Task3.Subjects;

namespace Task3.Vaccines
{
    interface IVaccine // IVisitor will be accepted by the ISubject to "visit"
    {
        public string Immunity { get; }
        public double DeathRate { get; }

        // ---------

        public void Vaccinate(Dog dog);
        public void Vaccinate(Cat cat);
        public void Vaccinate(Pig pig);
    }
}
