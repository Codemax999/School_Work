using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureProject
{
    class Character
    {
        //primitive type member variables
        private int health;
        private int baseAttack;
        private string name;
        string gender;
        float accuracy;
        string statusEffect;

        //class member variables
        private Weapon equippedWeapon;

        //default constructor
        public Character()
        {
            name = "Default";
            health = 100;
            baseAttack = 1;
            gender = "male";
            accuracy = 85.5F;
        }

        //constructor that sets all values
        public Character(string nameParam, int healthParam, int baseAttackParam, string genderParam, double accuracyParam)
        {
            name = nameParam;
            health = healthParam;
            baseAttack = baseAttackParam;
            gender = genderParam;
            accuracy = Convert.ToSingle(accuracyParam);
        }

        //property for setting all values
        public void SetValues(string nameParam, int healthParam, int baseAttackParam, string genderParam, double accuracyParam)
        {
            name = nameParam;
            health = healthParam;
            baseAttack = baseAttackParam;
            gender = genderParam;
            accuracy = Convert.ToSingle(accuracyParam);
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
            set { equippedWeapon = value; }
        }

        //access name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //access accuracy
        public float Accuracy
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

        //Display information about this character
        public void DisplayStatus()
        {
            Console.WriteLine("Name: " + Gender);
            Console.WriteLine("Gender: " + Name);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Base Attack: " + BaseAttack);
            Console.WriteLine("Accuracy: " + Accuracy);
            Console.WriteLine("Status Effect: " + StatusEffect);
            if(equippedWeapon != null)
            {
                EquippedWeapon.DisplayStatus();
            }
        }
    }
}
