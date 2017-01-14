using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    interface IEquippable
    {
        //Equip method
        //returns void with Character parameter
        void Equip(Character _character);

        //get set weapon attack
        int Attack { get; set; }
        //get set armor defense 
        int Defense { get; set; }
    }
}
