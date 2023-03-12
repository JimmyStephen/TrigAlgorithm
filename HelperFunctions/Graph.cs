using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    class Graph
    {
        public static string FindExactValueFromAngle()
        {

            double value = IO.GetDoubleInput("Enter the known value: ");

            int quadrant = FindQuadrant(value, false);
            int quadrantMultiplier = quadrant - 1;
            double actualValue = value - (90 * quadrantMultiplier);

            Console.WriteLine($"Angle {value} is actually {actualValue} in Quadrant {quadrant}");
            Console.WriteLine("Quadrant Notes: 1 = All Positive, 2 = Sin Positive, 3 = Tan Positive, 4 = Cos Positive");
            //double Sin = Math.Sin(actualValue);
            //double Cos = Math.Cos(actualValue);
            //double Tan = Math.Tan(actualValue);
            //
            //int gcd = Conversions.GCD((int)actualValue, 180);
            //string SinString = $"{actualValue/gcd}pi/{180/gcd}";
            //string CosString = $"{actualValue/gcd}pi/{180/gcd}";
            //string TanString = $"{actualValue/gcd}pi/{180/gcd}";
            //
            //Console.WriteLine($"Degrees | Sin: {Sin} Cos: {Cos} Tan: {Tan}");
            //Console.WriteLine($"Radians | Sin: {SinString} Cos: {CosString} Tan: {TanString}");
            return null;
        }
        //Triangles in Quadrants
            // Find sin, cos, tan
            // Find csc, sec, cot
            // Find a, b, c //| c cannot be negative
            // Find A, B, C
        public static string TrianglesInQuadrants()
        {
            double x = IO.GetDoubleInput("Input X value (X,Y)");
            double y = IO.GetDoubleInput("Input Y value (X,Y)");
            //Also the hypotenuse
            double radius = Math.Sqrt((x * x) + (y * y));

            double sin = Math.Sin(Conversions.DegToRad(y / radius));
            double cos = Math.Cos(Conversions.DegToRad(x / radius));
            double tan = Math.Tan(Conversions.DegToRad(y / x));

            double csc = Math.Sin(Conversions.DegToRad(radius / y));
            double sec = Math.Cos(Conversions.DegToRad(radius / x));
            double cot = Math.Tan(Conversions.DegToRad(x / y));

            Console.WriteLine($"Sin({sin}) | Cos({cos}) | Tan({tan}) | Csc({csc}) | Sec({sec}) | Cot({cot})");
            Console.WriteLine($"Sin({ReducedFraction(x, radius)}) | Cos({ReducedFraction(y, radius)}) | Tan({ReducedFraction(y, x)}) | Csc({ReducedFraction(radius, x)}) | Sec({ReducedFraction(radius, y)}) | Cot({ReducedFraction(x, y)})");

            return null;
        }

        public static string TrianglesInQuadrantsFromAngle()
        {
            double angleFractionTop = IO.GetDoubleInput("Enter top of the fraction for the angle: ");
            double angleFractionBot = IO.GetDoubleInput("Enter bottom of the fraction for the angle (1 for whole number): ");

            double radians = Conversions.DegToRad(angleFractionTop / angleFractionBot);

            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);
            double tan = Math.Tan(radians);

            double csc = 1 / sin;
            double sec = 1 / cos;
            double cot = 1 / tan;

            Console.WriteLine($"Sin({sin}) | Cos({cos}) | Tan({tan}) | Csc({csc}) | Sec({sec}) | Cot({cot})");

            return null;
        }


        public static string FindPNAngleQuadrant()
        {
            double value = IO.GetDoubleInput("Enter the coterminal: ");
            bool isDegree = IO.GetBoolInput("Is the coterminal in Degrees or Radians? (D/R)", "D", "R");
            double positiveAngle;
            double negativeAngle;
            int quadrant;

            if (isDegree)
            {
                positiveAngle = FindPositiveAngle(value, false);
                negativeAngle = FindNegativeAngle(value, false);
                quadrant = FindQuadrant(value, false);
            }
            else
            {
                positiveAngle = FindPositiveAngle(value, true);
                negativeAngle = FindNegativeAngle(value, true);
                quadrant = FindQuadrant(value, true);
            }

            Console.WriteLine($"For input of {value}\n-Positive Angle: {positiveAngle}\n-Negative Angle: {negativeAngle}\n-Quadrant: {quadrant}");
            return $"{positiveAngle}|{negativeAngle}|{quadrant}";
        }

        public static double FindPositiveAngle(double coterminal, bool radians = true)
        {
            double retVal = coterminal;
            if (!radians)
            {
                while (retVal < 360)
                {
                    retVal += 360;
                }
            }
            else
            {
                while (retVal < (2 * Math.PI))
                {
                    retVal += 2 * Math.PI;
                }
            }

            return retVal;
        }
        public static double FindNegativeAngle(double coterminal, bool radians = true)
        {
            double retVal = coterminal;
            if (!radians)
            {
                while (retVal > 0)
                {
                    retVal -= 360;
                }
            }
            else
            {
                while (retVal > 0)
                {
                    retVal -= 2 * Math.PI;
                }
            }
            return retVal;
        }
        //Quadrant 1 : 0-90     || 0 - pi/2
        //Quadrant 2 : 90-180   || pi/2 - pi
        //Quadrant 3 : 180-270  || pi - 3pi/2
        //Quadrant 4 : 270-360  || 3pi/2 - 2pi
        public static int FindQuadrant(double value, bool radians = true)
        {
            int quadrant = 4;
            if (radians)
            {
                if (value >= 0 && value < (Math.PI/2))
                {
                    quadrant = 1;
                }
                else if (value >= (Math.PI/2) && value < Math.PI)
                {
                    quadrant = 2;
                }
                else if (value >= Math.PI && value < ((3 * Math.PI) / 2))
                {
                    quadrant = 3;
                }
            }
            else
            {
                if (value >= 0 && value < 90)
                {
                    quadrant = 1;
                }
                else if (value >= 90 && value < 180)
                {
                    quadrant = 2;
                }
                else if (value >= 180 && value < 270)
                {
                    quadrant = 3;
                }
            }
            return quadrant;
        }
        //Find the quadrant of a point on a graph
        public static int FindQuadrent(double x, double y)
        {
            return -1;
        }
        // A 1, S 2, T 3, C 4
        //finds the quadrant based on SohCahToa
        public static int FindQuadrent(double sin, double cos, double tan)
        {
            if(sin > 0 && cos > 0 && tan > 0)
            {
                return 1;
            }
            else if (sin > 0 && cos < 0 && tan < 0)
            {
                return 2;
            }
            else if (sin < 0 && cos < 0 && tan > 0)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }


        //Helper
        private static string ReducedFraction(double top, double bot)
        {
            int gfd = Conversions.GCD((int)top, (int)bot);
            double newTop = top / gfd;
            double newBot = bot / gfd;
            return $"{newTop}/{newBot}";
        }
    }
}
