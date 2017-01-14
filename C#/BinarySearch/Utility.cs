using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    //Don't modify this class, it reads in the json data that you use to sort.
    abstract class Utility
    {
        public static Character[] ReadJsonData()
        {
            Character[] charactersList = new Character[10];
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Character[]));

            StreamReader reader = new StreamReader(@"../../dataoutput.json");

            charactersList = json.ReadObject(reader.BaseStream) as Character[];

            return charactersList;
        }
    }
}
