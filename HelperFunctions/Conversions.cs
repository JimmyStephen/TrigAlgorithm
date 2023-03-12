using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    class Conversions
    {
        //Conversions
        public static double FullConvertToDegree(double degree, double min, double sec)
        {
            double retVal = degree;
            retVal += MinutesToDegrees(min);
            retVal += SecondsToDegrees(sec);
            return retVal;
        }
        public static string FullConvertToList(double degrees)
        {
            double degree = Math.Floor(degrees);
            double min = DegreeToMinutes(degrees - degree);
            double minReturn = Math.Floor(min);
            double sec = MinutesToSeconds(min - minReturn);
            return $"{degree} {minReturn}' {sec}\"";
        }
        public static double DegreeToMinutes(double degrees)
        {
            return degrees * 60.0f;
        }
        public static double DegreeToSeconds(double degrees)
        {
            return degrees * 3600.0f;
        }
        public static double MinutesToSeconds(double minutes)
        {
            return minutes * 60.0f;
        }
        public static double MinutesToDegrees(double minutes)
        {
            return minutes / 60.0f;
        }
        public static double SecondsToDegrees(double seconds)
        {
            return seconds / 3600.0f;
        }
        public static double SecondsToMinutes(double seconds)
        {
            return seconds / 60.0f;
        }

        public static double DegToRad(double degree)
        {
            //int gcd = GCD((int)degree, 180);
            //Console.WriteLine($"DegToRad({degree}): " + (degree/ gcd) + "pi/" + (180/ gcd));
            return degree * Math.PI / 180;
        }
        public static double RadToDeg(double radian)
        {
            return radian * (180 / Math.PI);
        }



        //For testing/Output
        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
