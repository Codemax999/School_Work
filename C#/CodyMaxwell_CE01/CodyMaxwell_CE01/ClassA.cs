using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodyMaxwell_CE01
{
    class ClassA
    {

        //3 member variables
        string mItem1;
        int mItem2;
        double mItem3;

        //2 class member variables
        ClassB mClass1;
        ClassC mClass2;

        //default constructor
        public ClassA()
        {
            //print out class name
            Console.WriteLine("ClassA default constructor");
        }

        //parameter constructor 
        public ClassA(string _item1, int _item2, double _item3)
        {
            //assign parameters to member variables
            mItem1 = _item1;
            mItem2 = _item2;
            mItem3 = _item3;
            
            //print out class name
            Console.WriteLine("ClassA 3 parameter constructor");
        }

        //parameter class constructor 1
        public ClassA(ClassB _class1)
        {
            //assign parameters to member variables
            mClass1 = _class1;

            //print out class name with parameter
            Console.WriteLine("ClassA with parameter: ClassB");
        }

        //parameter class constructor 2
        public ClassA(ClassC _class2)
        {
            //assign parameters to member variables
            mClass2 = _class2;

            //print out class name with parameter
            Console.WriteLine("ClassA with parameter: ClassC");
        }

        //additional method 1
        public void makeClass(ClassB _class1)
        {
            //instantiate the other class
           mClass2 = new ClassC(_class1);

            //print out class name and parameter
            Console.WriteLine("ClassA method with parameter: ClassB");
        }

        //additional method 2
        public void makeClass2(ClassC _class2)
        {
            //instantiate the other class
            mClass1 = new ClassB(_class2);

            //print out class name and parameter
            Console.WriteLine("ClassA method with parameter: ClassC");
        }

        //final method
        public void finalMethod(ClassB _class1, ClassC _class2)
        {
            //call method 1 and 2
            makeClass(_class1);
            makeClass2(_class2);

            //print out to console
            Console.WriteLine("ClassA calling both methods");
        }
    }
}
