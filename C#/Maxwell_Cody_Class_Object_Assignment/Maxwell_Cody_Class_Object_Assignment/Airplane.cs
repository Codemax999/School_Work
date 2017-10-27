using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_Cody_Class_Object_Assignment
{
    class Airplane
    {
        // define member variables: 
        // make, model, color and year
        string mMake;
        string mModel;
        string mColor;
        int mYear;
        double mMileage;

        // Airplane constructor 
        public Airplane(string _make, string _model, string _color, int _year)
        {
            // assign local variables to member variables
            mMake = _make;
            mModel = _model;
            mColor = _color;
            mYear = _year;
        }

        // car overload method
        public Airplane(string _make, string _model, string _color, int _year, double _mileage)
        {
            // assign local variable to member variable
            mMake = _make;
            mModel = _model;
            mColor = _color;
            mYear = _year;
            mMileage = _mileage;
        }

        // return airplane years old 
        public int getPlaneAge()
        {
            return DateTime.Now.Year - mYear;
        }

        // Make getter
        public string getMake()
        {
            return mMake;
        }
        // Model getter
        public string getModel()
        {
            return mModel;
        }
        // Color getter
        public string getColor()
        {
            return mColor;
        }
        // Year getter
        public int getYear()
        {
            return mYear;
        }
        // Mileage getter
        public double getMileage()
        {
            return mMileage;
        }

        // Make setter
        public void setMake(string _make)
        {
            mMake = _make;
        }
        // Model setter
        public void setModel(string _model)
        {
            mModel = _model;
        }
        // Color setter
        public void setColor(string _color)
        {
            mColor = _color;
        }
        // Year setter
        public void setYear(int _year)
        {
            mYear = _year;
        }
        // Mileage setter
        public void setMileage(double _mileage)
        {
            mMileage = _mileage;
        }
    }
}
