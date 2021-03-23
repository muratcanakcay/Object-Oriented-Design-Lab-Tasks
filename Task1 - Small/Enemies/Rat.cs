using System;
using Defenders;

namespace Enemies
{
    class Rat : Enemy
    {
        public int Speed { get; private set; }

        public Rat(string name, int hp, int speed) : base(name, hp)
        {
            Speed = speed;
        }

        //-------------------------

        public override void GetAttackedBy(IDefender defender)
        {
            int damage = defender.Attack(this);
            GetDamage(damage);

            if (damage > 0 && Alive)
            {
                Speed++;
                Console.WriteLine($"----Rat {Name} panics and starts moving faster!");
            }
        }
    }
}