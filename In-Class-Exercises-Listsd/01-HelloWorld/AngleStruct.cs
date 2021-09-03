using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HelloWorld
{
    public struct AngleStruc
    {
        private double angleRadian;

        public double angleDegree
        {
            set { this.angleRadian = value / 180.0 * System.Math.PI; }
            get { return this.angleRadian * 180.0 / System.Math.PI; }
        }

        public void showInfo(string structure)
        {
            Console.WriteLine("The Angle Radian for " + structure + " structure is: " + angleRadian);
            Console.WriteLine("The Angle Degree for " + structure + " structure is: " + angleDegree);
        }
    }
}
