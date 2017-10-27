using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    [DataContract]
    class Armor : IEquippable
    {
        [DataMember]
        int defense;

        public Armor(int defenseParameter)
        {
            defense = defenseParameter;
        }

        public int Defense
        {
            get { return defense;  }
            set { defense = value; }
        }

        public override string ToString()
        {
            return "Defense: " + Defense;
        }

        public void Equip(Character character)
        {

        }
    }
}
