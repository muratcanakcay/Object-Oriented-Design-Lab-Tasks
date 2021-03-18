using System;
using Defenders;

namespace Enemies
{
    class Giant : Enemy
    {

        public Giant(string name, int hp) : base(name, hp)
        {
        }

        override public void GetAttackedBy(IDefender defender)
        {
            GetDamage(defender.Attack(this));
        }
    }
}