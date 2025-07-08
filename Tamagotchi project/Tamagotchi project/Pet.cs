using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_project
{
    abstract class Pet
    {
        protected abstract string name { get; set; }
        protected abstract string species { get; set; }
        protected abstract string favouriteFood { get; set; }
        protected abstract string favouriteToy { get; set; }

        protected abstract int age { get; set; }
        protected abstract int hunger { get; set; }
        protected abstract int happiness { get; set; }
        protected void Sleep()
        {
            Console.WriteLine($"{name} is sleeping.");
        }

    }
}
