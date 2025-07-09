using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_project
{
    internal class Cat : Pet
    {
        protected override string name { get; set; }
        protected override string favouriteFood { get; set; }
        protected override string favouriteToy { get; set; }
        protected override int age { get; set; }
        protected override int hunger { get; set; }
        protected override int happiness { get; set; }


    }
}
