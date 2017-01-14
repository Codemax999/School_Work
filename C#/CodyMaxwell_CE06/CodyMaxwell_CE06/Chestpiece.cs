using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE06
{
    class Chestpiece : Armor
    {
        public Chestpiece(int _defense) : base(_defense)
        {

        }

        //Equip method should place chestpiece into the equipped armor Dictionary of the Character parameter
        //store with a key of chestpiece
        public override void Equip(Character _character)
        { 
            _character.Armors.Add("chestpiece", this);
        }
    }
}
