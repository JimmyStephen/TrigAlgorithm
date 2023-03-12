using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    class Circle
    {
        //Methods | Unit One
        public static double FindCenterAngle()
        {
            double circumference = IO.GetDoubleInput("Circumference: ");
            double diameter = IO.GetDoubleInput("Diameter : ");
            double radius = IO.GetDoubleInput("Radius : ");
            double arc = IO.GetDoubleInput("Arc: ");
            double ret;

            if (diameter > 0)
                ret = (arc * 360) / (diameter * Math.PI);
            else if (radius > 0)
                ret = (arc * 360) / (radius * 2 * Math.PI);
            else if (circumference > 0)
                ret = (arc * 360) / (circumference);
            else ret = -1;

            return ret;
        }
        public static float FindArcFromCircumferenceTheta(float circumference, float theta)
        {
            // convert the angle to radians
            float radians = theta * (float)Math.PI / 180;
            // calculate the arc length
            float arcLength = radians * circumference / (2 * (float)Math.PI);
            return arcLength;
        }
        public static float FindCircumferenceFromArcTheta(float arcLength, float theta)
        {
            // convert the angle to radians
            float radians = theta * (float)Math.PI / 180;
            // calculate the circumference
            float circumference = (2 * (float)Math.PI * arcLength) / radians;
            return circumference;
        }
        public static float FindRadiusFromArcTheta(float arcLength, float theta)
        {
            // convert the angle to radians
            //degrees * conversion rate
            float radians = theta * (float)Math.PI / 180;
            // calculate the radius
            float radius = arcLength / radians;
            return radius;
        }
        
        public static double FractionToDegreesOfCircle()
        {
            double a = IO.GetDoubleInput("Top of Fraction (input number here for whole number)");
            double b = IO.GetDoubleInput("Top of Fraction (1 if whole number)");

            return 360 * (a / b);
        }
        public static string DegreesToFraction()
        {
            double a = IO.GetDoubleInput("Degrees: ");

            double retVal = a / 360;
            double top = -1;
            double bot = -1;
            return $"{top}/{bot} || {retVal}";
        }
        
        //Methods | Unit Two
        //
    }
}
