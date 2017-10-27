using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE03
{
    interface IUsable
    {
        //IUsable interface
        //void Use method (Character as parameter)
        //abstract Item class will implenet this IUsable interface
       void Use(Character _character);
    }
}
