using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HelloWorld
{
    public class AngleClass
    {
        private double angleRadian;

        public double angleDegree
        {
            set { this.angleRadian = value / 180.0 * System.Math.PI; }
            get { return this.angleRadian * 180.0 / System.Math.PI; }
        }

        public void showInfo(string ob)
        {
            Console.WriteLine("The Angle Radian for " + ob + " object is: " + angleRadian);
            Console.WriteLine("The Angle Degree for " + ob + " object is: " + angleDegree);
        }
    }
}
