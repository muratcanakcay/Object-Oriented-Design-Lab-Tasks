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

        virtual public int Attack(Giant g)
        {
            Console.WriteLine($"Ratcatcher {name} ignores the giant {g.Name}.");
            return 0;
        }

        virtual public int Attack(Ogre o)
        {
            if (hasRat)
            {
                Console.WriteLine($"Ratcatcher {name} throws the rat he has at ogre {o.Name} and the ogre flees!");
                hasRat = false;
                return 1000000000;
            }
            else
            {
                Console.WriteLine($"Ratcatcher {name} does not have a rat in his bag and ignores the ogre {o.Name}.");
                return 0;
            }
        }

        virtual public int Attack(Rat r)
        {
            if (hasRat)
            {
                Console.WriteLine($"Ratcatcher {name} ignores the rat {r.Name} because he already has a rat in his bag.");
                return 0;
            }
            else
            { 
                Console.WriteLine($"RatCatcher {name} catches the rat {r.Name}, kills it and puts it in his bag!");
                hasRat = true;
                return 1000000000;
            }
        }
    }
}