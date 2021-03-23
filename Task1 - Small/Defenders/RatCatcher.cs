using System;
using Enemies;

namespace Defenders
{
    class RatCatcher : IDefender
    {
        protected readonly string name;
        private bool hasRat;

        public RatCatcher(string name)
        {
            this.name = name;
            hasRat=false;
        }

        public virtual int Attack(Giant g)
        {
            Console.WriteLine($"Ratcatcher {name} ignores Giant {g.Name}");
            return 0;
        }

        public virtual int Attack(Ogre o)
        {
            if (hasRat)
            {
                Console.WriteLine($"Ratcatcher {name} throws the rat he has at Ogre {o.Name}");
                hasRat = false;
                return 1000000000;
            }
            else
            {
                Console.WriteLine($"Ratcatcher {name} does not have a rat in his bag and ignores Ogre {o.Name}");
                return 0;
            }
        }

        public virtual int Attack(Rat r)
        {
            if (hasRat)
            {
                Console.WriteLine($"Ratcatcher {name} has a rat in his bag and ignores Rat {r.Name}");
                return 0;
            }
            else
            { 
                Console.WriteLine($"RatCatcher {name} catches, kills and puts in his bag Rat {r.Name}");
                hasRat = true;
                return 1000000000;
            }
        }
    }
}