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
            Console.WriteLine("******** Class ***********  The Angle Radian for " + ob + " object is: " + angleRadian);
            Console.WriteLine("******** Class ***********  The Angle Degree for " + ob + " object is: " + angleDegree);
        }
    }
}
