using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BinarySearch
{
    [DataContract]
    class Character 
    {
        //primitive type member variables
        [DataMember]
        private int health;
        [DataMember]
        private int baseAttack;
        [DataMember]
        private string name;
        [DataMember]
        string gender;
        [DataMember]
        double accuracy;
        [DataMember]
        string statusEffect;

        //class member variables
        [DataMember]
        private Weapon equippedWeapon;

        //Equipped armor
        [DataMember]
        Dictionary<string, Armor> equippedArmor;

        //default constructor
        public Character()
        {
            EquippedArmor = new Dictionary<string, Armor>();
            name = "Default";
            health = 100;
            baseAttack = 1;
            gender = "male";
            accuracy = 85.5;
        }

        //constructor that sets all values
        public Character(string nameParam, int healthParam, int baseAttackParam, string genderParam, double accuracyParam) : this()
        {
            name = nameParam;
            health = healthParam;
            baseAttack = baseAttackParam;
            gender = genderParam;
            accuracy = accuracyParam;
        }

        //constructor to create a Character from a loaded string
        public Character(string str) : this()
        {
            string[] stats = str.Split(',');
            name = stats[0];
            gender = stats[1];
            int tempInt;
            if (Int32.TryParse(stats[2], out tempInt))
            {
                health = tempInt;
            }
            if (Int32.TryParse(stats[3], out tempInt))
            {
                baseAttack = tempInt;
            }
            double tempDouble;
            if (Double.TryParse(stats[4], out tempDouble))
            {
                accuracy = tempDouble;
            }
        }

        //property for setting all values
        public void SetValues(string nameParam, int healthParam, int baseAttackParam, string genderParam, double accuracyParam)
        {
            name = nameParam;
            health = healthParam;
            baseAttack = baseAttackParam;
            gender = genderParam;
            accuracy = accuracyParam;
        }

        //access baseAttack
        public int BaseAttack
        {
            get { return baseAttack; }
            set {  baseAttack = value; }
        }

        //access health
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        //get total attack value
        public int TotalAttack
        {
            get
            {
                if (equippedWeapon == null)
                {
                    return baseAttack;
                }
                else {
                    return baseAttack + equippedWeapon.Attack;
                }
            }
        }

        //access equippedWeapon
        public Weapon EquippedWeapon
        {
            get {  return equippedWeapon; }
            set
            {
                equippedWeapon = value;
            }
        }

        //access name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //access accuracy
        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        //access gender
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        //access statusEffect
        public string StatusEffect
        {
            get { return statusEffect; }
            set { statusEffect = value; }
        }

        public Dictionary<string, Armor> EquippedArmor
        {
            get
            {
                return equippedArmor;
            }

            set
            {
                equippedArmor = value;
            }
        }

        public override string ToString()
        {
            string retVal = "";
            retVal += ("Name: " + Name + "\n");
            retVal += ("Gender: " + Gender + "\n");
            retVal += ("Health: " + Health + "\n");
            retVal += ("Base Attack: " + BaseAttack + "\n");
            retVal += ("Accuracy: " + Accuracy + "\n");
            retVal += ("Status Effect: " + StatusEffect + "\n");
            retVal += ("Total Defense: " + GetTotalDefense() + "\n");

            if (EquippedWeapon != null)
            {
                retVal += (EquippedWeapon + "\n");
            }

            return retVal;
        }

        public string GetEquippedArmorDisplayString()
        {
            string retVal = "Equipped Armor: \n";
            //if there is no armor add that to the return value and return
            if(EquippedArmor.Count == 0)
            {
                retVal += "No armor equipped.";
                return retVal;
            }

            //add each armor's string to the return value
            foreach (string key in EquippedArmor.Keys)
            {
                Armor tempArmor;
                if (EquippedArmor.TryGetValue(key, out tempArmor))
                {
                    retVal += (tempArmor + "\n");
                }
            }

            return retVal;
        }

        //string to save this object out
        public string GetStringToSave()
        {
            string retVal = "";

            retVal = (Name + "," + Gender + "," + Health + "," + BaseAttack + "," + Accuracy);

            return retVal;
        }

        //Display information about this character
        public void DisplayStatus()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Gender: " + Gender);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Base Attack: " + BaseAttack);
            Console.WriteLine("Accuracy: " + Accuracy);
            Console.WriteLine("Status Effect: " + StatusEffect);
            Console.WriteLine("");
            if(equippedWeapon != null)
            {
                Console.WriteLine("Equipped Weapon:");
                EquippedWeapon.DisplayStatus();
            }
        }

        public void EquipArmor(string type, Armor armor)
        {
            equippedArmor.Add(type, armor);
        }

        public int GetTotalDefense()
        {
            int totalDefense = 0;
            foreach(string key in EquippedArmor.Keys)
            {
                Armor tempArmor;
                if (EquippedArmor.TryGetValue(key, out tempArmor))
                {
                    totalDefense += tempArmor.Defense;
                }
            }

            return totalDefense;
        }
    }
}
