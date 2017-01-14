using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE03
{
    public abstract class Item : IUsable
    {
        //member variables
        public int intEffect;
        public string strEffect;
        public string description;

        //should not have implementation  for Use method
        //use abstract keyword with method signature to avoid errors
        public abstract void Use(Character _character);
    }
}
