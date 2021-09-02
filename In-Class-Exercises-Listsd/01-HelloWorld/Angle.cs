using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HelloWorld
{
    public class Angle
    {
        private double angleRadian;

        public double angleDegree
        {
            set { this.angleRadian = value / 180.0 * System.Math.PI; }
            get { return this.angleRadian * 180.0 / System.Math.PI; }
        }

        public void showInfo(string ob)
        {
            Console.WriteLine("The angleRadian for " + ob + " object is: " + angleRadian);
            Console.WriteLine("The angleDegree for " + ob + " object is: " + angleDegree);
        }
    }

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
            Console.WriteLine("The angleRadian for " + structure + " structure is: " + angleRadian);
            Console.WriteLine("The angleDegree for " + structure + " structure is: " + angleDegree);
        }
    }
}
