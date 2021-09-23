/// <summary>
/// 
/// Name: Boxiang Lin 
/// ID: 011601661
/// In-Class Exercise 1
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
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
            Console.WriteLine("******** Struct ***********  The Angle Radian for " + structure + " structure is: " + angleRadian);
            Console.WriteLine("******** Struct ***********  The Angle Degree for " + structure + " structure is: " + angleDegree);
        }
    }
}
