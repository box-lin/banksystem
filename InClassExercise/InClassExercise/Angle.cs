using System;
using System.Collections.Generic;
using System.Text;

namespace InClassExercise
{
    public class Angle
    {
        private double angleRadians;
        
        public Angle()
        {
            this.angleRadians = 0.0;
        }

        public Angle(double angleRadians)
        {
            this.angleRadians = angleRadians;
        }
        
        public double AngleDegrees
        {
            get { return angleRadians * 180.0 / Math.PI; }
            set { angleRadians = value / 180.0 * Math.PI; }
        }



        
    }
}
