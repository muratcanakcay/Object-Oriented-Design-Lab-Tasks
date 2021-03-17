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

        override public void GetAttackedBy(IDefender defender)
        {
            int damage = defender.Attack(this);
            GetDamage(damage);
        }
    }
}