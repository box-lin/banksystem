// <copyright file="AngleClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HelloWorld
{
    using System;

    public class AngleClass
    {
        private double angleRadian;

        public double angleDegree
        {
            get { return this.angleRadian * 180.0 / System.Math.PI; }
            set { this.angleRadian = value / 180.0 * System.Math.PI; }
        }

        public void showInfo(string ob)
        {
            Console.WriteLine("******** Class ***********  The Angle Radian for " + ob + " object is: " + angleRadian);
            Console.WriteLine("******** Class ***********  The Angle Degree for " + ob + " object is: " + angleDegree);
        }
    }
}
