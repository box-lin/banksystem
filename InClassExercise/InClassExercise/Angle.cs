using System;
using System.Collections.Generic;
using System.Text;

namespace InClassExercise
{
    class Angle
    {
        private double angleRadians;
        public double AngleDegrees
        {
            get { return angleRadians * 180.0 / Math.PI; }
            set { angleRadians = value / 180.0 * Math.PI; }
        }
    }
}
