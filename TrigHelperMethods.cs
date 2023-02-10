using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    static class TrigHelperMethods
    {
        private static string[] Helpers = new string[] { "General Methods", "Circle Methods", "Circle Helper Methods", "Triangle Methods" };
        private static string[] GeneralMethods = new string[]
        {
            "DegreeToMinutes",
            "DegreeToSeconds",
            "MinutesToSeconds",
            "MinutesToDegrees",
            "SecondsToDegrees",
            "SecondsToMinutes",
            "FullConvertToDegree",
            "FullConvertToList",
            "DegToRad",
            "RadToDeg"
        };

        public static void TrigController()
        {
            //find out what controller to call using the avalible controller
            int input = int.MaxValue;
            while (input != 0)
            {
                input = IO.GetListInput(Helpers);
                switch (input)
                {
                    case 1:
                        GeneralTrigMethods();
                        break;
                    case 2:
                        CircleHelperMethods.CircleController();
                        break;
                    case 3:
                        CircleHelperMethods.CircleHelperController();
                        break;
                    case 4:
                        TriangleHelperMethods.TriangleController();
                        break;
                    default:
                        Console.WriteLine("Now Exiting Trig Controller");
                        break;
                }
            }
        }

        public static void GeneralTrigMethods()
        {
            //find out what controller to call using the avalible controller
            double a;
            double b;
            double c;

            int input = int.MaxValue;
            while (input != 0)
            {
                input = IO.GetListInput(GeneralMethods);
                switch (input)
                {
                    case 1:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + DegreeToMinutes(a));
                        break;
                    case 2:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + DegreeToSeconds(a));
                        break;
                    case 3:
                        a = IO.GetDoubleInput("Minutes: ");
                        Console.WriteLine("Solution: " + MinutesToSeconds(a));
                        break;
                    case 4:
                        a = IO.GetDoubleInput("Minutes: ");
                        Console.WriteLine("Solution: " + MinutesToDegrees(a));
                        break;
                    case 5:
                        a = IO.GetDoubleInput("Seconds: ");
                        Console.WriteLine("Solution: " + SecondsToDegrees(a));
                        break;
                    case 6:
                        a = IO.GetDoubleInput("Seconds: ");
                        Console.WriteLine("Solution: " + SecondsToMinutes(a));
                        break;
                    case 7:
                        a = IO.GetDoubleInput("Degrees: ");
                        b = IO.GetDoubleInput("Minutes: ");
                        c = IO.GetDoubleInput("Seconds: ");
                        Console.WriteLine("Solution: " + FullConvertToDegree(a, b, c));
                        break;
                    case 8:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + FullConvertToList(a));
                        break;
                    case 9:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + DegToRad(a));
                        break;
                    case 10:
                        a = IO.GetDoubleInput("Radians: ");
                        Console.WriteLine("Solution: " + RadToDeg(a));
                        break;
                    default:
                        Console.WriteLine("Now Exiting Trig Helper Controller");
                        break;
                }
            }
        }

        //Conversions
        public static double DegreeToMinutes (double degrees)
        {

            return degrees * 60.0f;
        }
        public static double DegreeToSeconds (double degrees)
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

        public static string FindSCTEverything()
        {
            double value = IO.GetDoubleInput("Value to find: ");
            value = DegToRad(value);

            double sin = Math.Sin(value);
            double cos = Math.Cos(value);
            double tan = Math.Tan(value);
            double csc = 1 / sin;
            double sec = 1 / cos;
            double cot = 1 / tan;

            string ret = $"Sin={sin} | Cos={cos} | Tan={tan} | Csc={csc} | Sec={sec} | Cot={cot}";

            return ret;
        }
        public static string SolveForASohCahToa(double y)
        {
            double sin = RadToDeg(Math.Asin(y));
            double cos = RadToDeg(Math.Acos(y));
            double tan = RadToDeg(Math.Atan(y));
            return $"ASin({sin}) | ACos({cos}) | ATan({tan})";
        }
        public static string SolveForASohCahToa()
        {
            double y = IO.GetDoubleInput("Known Value: ");
            double sin = RadToDeg(Math.Asin(y));
            double cos = RadToDeg(Math.Acos(y));
            double tan = RadToDeg(Math.Atan(y));
            return $"ASin({sin}) | ACos({cos}) | ATan({tan})";
        }

        public static double DegToRad(double degree)
        {
            return degree * Math.PI / 180;
        }
        public static double RadToDeg(double radian)
        {
            return radian * (180 / Math.PI);
        }
    }

    static class TriangleHelperMethods
    {
        private static string[] TriangleMethods = new string[] { "Helper Methods", "Find Area", "Pythagrean Theorem", "SohCahToa & ChoChaCao (1 Input)", "SohCahToa (Calculate From 3 Num)", "ChoShaCao (Calculate From 3 Num)", "Inverse SohCahToa", "Angle Finder", "Sides And Angles (Right Triangle)", "Find Similar Triangles", "Difference Between Triangles" };
        private static string[] TriangleHelpers = new string[] {  };
        
        public static void TriangleController()
        {
            Console.WriteLine("Triangle Controller\n");
            //values for methods
            double a = -1;
            double b = -1;
            double c = -1;

            int input = int.MaxValue;
            while (input != 0)
            {
                //choose what to do
                input = IO.GetListInput(TriangleMethods);
                switch (input)
                {
                    case 1:
                        TriangleHelperController();
                        break;
                    case 2:
                        a = IO.GetDoubleInput("Base: ");
                        b = IO.GetDoubleInput("Height: ");
                        Console.WriteLine("Area: " + TriangleFindArea(a, b));
                        break;
                    case 3:
                        a = IO.GetDoubleInput("A (enter -1 for unknown): ");
                        b = IO.GetDoubleInput("B (enter -1 for unknown): ");
                        c = IO.GetDoubleInput("C (enter -1 for unknown): ");
                        double answer = PythagoreanTheorem(a, b, c);
                        Console.WriteLine("Answer: " + answer + " or Sqrt(" + answer * answer + ")");
                        break;
                    case 4:
                        a = IO.GetDoubleInput("Enter Number");
                        Console.WriteLine("Using A: " + a);
                        Console.WriteLine("Answer: " + SohCahToaChoChaCaoAll(a));
                        break;
                    case 5:
                        a = IO.GetDoubleInput("Opposite (enter -1 for unknown): ");
                        b = IO.GetDoubleInput("Adjacent (enter -1 for unknown): ");
                        c = IO.GetDoubleInput("Hypotenuse (enter -1 for unknown): ");
                        Console.WriteLine("Answer: " + SohCahToa(a, b, c));
                        break;
                    case 6:
                        a = IO.GetDoubleInput("Opposite (enter -1 for unknown): ");
                        b = IO.GetDoubleInput("Adjacent (enter -1 for unknown): ");
                        c = IO.GetDoubleInput("Hypotenuse (enter -1 for unknown): ");
                        Console.WriteLine("Answer: " + ChoShaCao(a, b, c));
                        break;
                    case 7:
                        a = IO.GetDoubleInput("Value (enter -1 for unknown): ");
                        Console.WriteLine("Answer: " + InverseSohCahToa(a));
                        //inverse
                        break;
                    case 8:
                        Console.WriteLine("Answer: " + AngleFinder());
                        break;
                    case 9:
                        Console.WriteLine("Answer: " + SidesAndAnglesRight());
                        //solve
                        break;
                    case 10:
                        Console.WriteLine("Answer: " + SimilarTriangleSolution());
                        break;
                    case 11:
                        Console.WriteLine(FindDifferenceBetweenTriangles());
                        break;
                    default:
                        Console.WriteLine("Now Exiting Triangle");
                        break;
                }
            }
        }
        public static void TriangleHelperController()
        {
            //
        }

        public static string FindDifferenceBetweenTriangles()
        {
            string retVal = null;

            double TriOnea = IO.GetDoubleInput("Input Triangle 1 a: ");
            double TriOneb = IO.GetDoubleInput("Input Triangle 1 b: ");
            double TriOnec = IO.GetDoubleInput("Input Triangle 1 c: ");
            double TriOneA = IO.GetDoubleInput("Input Triangle 1 A: ");
            double TriOneB = IO.GetDoubleInput("Input Triangle 1 B: ");
            double TriOneC = IO.GetDoubleInput("Input Triangle 1 C: ");

            double TriTwoa = IO.GetDoubleInput("Input Triangle 2 a: ");
            double TriTwob = IO.GetDoubleInput("Input Triangle 2 b: ");
            double TriTwoc = IO.GetDoubleInput("Input Triangle 2 c: ");
            double TriTwoA = IO.GetDoubleInput("Input Triangle 2 A: ");
            double TriTwoB = IO.GetDoubleInput("Input Triangle 2 B: ");
            double TriTwoC = IO.GetDoubleInput("Input Triangle 2 C: ");

            string[] temp1 = SidesAndAnglesRight(TriOnea, TriOneb, TriOnec, TriOneA, TriOneB, TriOneC).Split("|");
            string[] temp2 = SidesAndAnglesRight(TriTwoa, TriTwob, TriTwoc, TriTwoA, TriTwoB, TriTwoC).Split("|");
            double[] triOne = new double[6];
            double[] triTwo = new double[6];

            for(int i = 0; i < 6; i++)
            {
                triOne[i] = double.Parse(temp1[i]);
                triTwo[i] = double.Parse(temp2[i]);
            }

            double differencea = triOne[0] - triTwo[0];
            double differenceb = triOne[1] - triTwo[1];
            double differencec = triOne[2] - triTwo[2];
            double differenceA = triOne[3] - triTwo[3];
            double differenceB = triOne[4] - triTwo[4];
            double differenceC = triOne[5] - triTwo[5];

            retVal =  $"Triangle One | a: {triOne[0]:F4} | b: {triOne[1]:F4} | c: {triOne[2]:F4} | A: {triOne[3]:F4} | B: {triOne[4]:F4} | C: {triOne[5]:F4}\n";
            retVal += $"Triangle Two | a: {triTwo[0]:F4} | b: {triTwo[1]:F4} | c: {triTwo[2]:F4} | A: {triTwo[3]:F4} | B: {triTwo[4]:F4} | C: {triTwo[5]:F4}\n";
            retVal += $"Differences  | a: {differencea:F4} | b: {differenceb:F4} | c: {differencec:F4} | A: {differenceA:F4} | B: {differenceB:F4} | C: {differenceC:F4} ";
            return retVal;
        }

        public static string SimilarTriangleSolution()
        {
            double triangleOneA = IO.GetDoubleInput("Triangle One A: ");
            double triangleOneB = IO.GetDoubleInput("Triangle One B: ");
            double triangleOneC = IO.GetDoubleInput("Triangle One C: ");

            double triangleTwoA = IO.GetDoubleInput("Triangle Two A: ");
            double triangleTwoB = IO.GetDoubleInput("Triangle Two B: ");
            double triangleTwoC = IO.GetDoubleInput("Triangle Two C: ");

            return $"Triangle One: A: {triangleOneA} B: {triangleOneB} C: {triangleOneC}\nTriangle Two: A: {triangleTwoA} B: {triangleTwoB} C: {triangleTwoC}";
        }

        //Very simple method, just so it can be called by other methods
        public static double TriangleFindArea(double _base, double _hight)
        {
            return .5f * (_base * _hight);
        }
        /// <summary>
        /// Enter the sides that are known, enter -1 for what you are trying to find
        /// </summary>
        /// <param name="a">Side A</param>
        /// <param name="b">Side B</param>
        /// <param name="c">Hypotenuse</param>
        /// <returns>The missing value, or -1 if the formula is wrong</returns>
        public static double PythagoreanTheorem(double a, double b, double c)
        {
            //check if you are missing C
            if(c < 0 && a > 0 && b > 0)
            {
                Console.WriteLine($"{a}^2 + {b}^2");
                return Math.Sqrt((a * a) + (b * b));
            }
            //check if you are missing A
            else if (a < 0 && b > 0 && c > 0)
            {
                Console.WriteLine($"{c}^2 - {b}^2");
                return Math.Sqrt((c * c) - (b * b));
            }
            //check if you are missing B
            else if (b < 0 && c > 0 && c > 0)
            {
                Console.WriteLine($"{c}^2 - {a}^2");
                return Math.Sqrt((c * c) - (a * a));
            }
            return -1;
        }
        
        public static string SidesAndAnglesRight()
        {
            double a = IO.GetDoubleInput("Input a: ");
            double b = IO.GetDoubleInput("Input b: ");
            double c = IO.GetDoubleInput("Input c: ");
            double A = IO.GetDoubleInput("Input A: ");
            double B = IO.GetDoubleInput("Input B: ");
            double C = IO.GetDoubleInput("Input C: ");
            
            int loops = 0;
                //redo calculations until either solved or deemed impossible
            while ((a < 0 || b < 0 || c < 0 || A < 0 || B < 0 || C < 0) && loops < 5)
            {
                //find a if a isnt found and its possible to find
                if (a <= 0)
                {
                    //try using c & b
                    //try using sin, cin, and tan
                    
                    //try using c & b
                    if (c > 0 && b > 0)
                    {
                        a = Math.Sqrt((c * c) - (b * b));
                    }
                    //tan
                    else if (A > 0 && b > 0)
                    {
                        a = b * Math.Tan(TrigHelperMethods.DegToRad(A));
                    }
                    //sin
                    else if (A > 0 && c > 0)
                    {
                        a = c * Math.Sin(TrigHelperMethods.DegToRad(A));
                    }
                    //cos
                    else if(B > 0 && c > 0){
                        a = c * Math.Cos(TrigHelperMethods.DegToRad(B));
                    }
                    //tan(A)  = opposite (a) / adjacent (b)
                    //sin(A)  = opposite (a) / hypo (c)
                    //cos(B)  = adjacent (a) / hypo (c)
                    //aTan(B) = adjacent (b) / opposite (a)

                }
                //find b if b isnt found and its possible to find
                if (b <= 0)
                {

                    //try using c & a
                    //try using sin, cin, and tan

                    //try using c & a
                    if (a > 0 && c > 0) { 
                        b = Math.Sqrt((c * c) - (a * a)); 
                    }
                    //tan
                    else if (B > 0 && a > 0)
                    {
                        b = a * Math.Tan(TrigHelperMethods.DegToRad(B));
                    }
                    //sin
                    else if (B > 0 && c > 0)
                    {
                        b = c * Math.Sin(TrigHelperMethods.DegToRad(B));
                    }
                    //cos
                    else if (A > 0 && c > 0)
                    {
                        b = c * Math.Cos(TrigHelperMethods.DegToRad(A));
                    }
                    //using sin
                    //using cin
                }
                //find c if c isnt found and its possible to find
                if (c <= 0)
                {
                    //try using b & a
                    //try using sin, cin, and tan

                    //try using b & a
                    if (a > 0 && b > 0)
                    {
                        c = Math.Sqrt((a * a) + (b * b));
                    }
                }

                //find A
                if (A <= 0)
                {
                    //try using C and B
                    if (C > 0 && B > 0)
                    {
                        A = (180 - C) - B;
                    }
                    if (a > 0 && b > 0)
                    {
                        A = TrigHelperMethods.RadToDeg(Math.Atan(a / b));
                    }
                }
                //find B
                if (B <= 0)
                {
                    //try using C and A
                    if (C > 0 && A > 0)
                    {
                        B = (180 - C) - A;
                    }
                    if (a > 0 && b > 0)
                    {
                        B = TrigHelperMethods.RadToDeg(Math.Atan(b / a));
                    }
                }
                //find C
                if(C <= 0)
                {
                    //try using A and B
                    if (B > 0 && A > 0)
                    {
                        C = (180 - B) - A;
                    }
                }

                loops++;
                Console.WriteLine($"Loop: {loops} | a: {a} | b: {b} | c: {c} | A: {A} | B: {B} | C: {C}");
            }

            return $"\na: {a} | b: {b} | c: {c}\nA: {A} | B: {B} | C: {C}";
        }
        public static string SidesAndAnglesRight(double a, double b, double c, double A, double B, double C)
        {
            int loops = 0;
            //redo calculations until either solved or deemed impossible
            while ((a < 0 || b < 0 || c < 0 || A < 0 || B < 0 || C < 0) && loops < 5)
            {
                //find a if a isnt found and its possible to find
                if (a <= 0)
                {
                    //try using c & b
                    //try using sin, cin, and tan

                    //try using c & b
                    if (c > 0 && b > 0)
                    {
                        a = Math.Sqrt((c * c) - (b * b));
                    }
                    //tan
                    else if (A > 0 && b > 0)
                    {
                        a = b * Math.Tan(TrigHelperMethods.DegToRad(A));
                    }
                    //sin
                    else if (A > 0 && c > 0)
                    {
                        a = c * Math.Sin(TrigHelperMethods.DegToRad(A));
                    }
                    //cos
                    else if (B > 0 && c > 0)
                    {
                        a = c * Math.Cos(TrigHelperMethods.DegToRad(B));
                    }
                    //tan(A)  = opposite (a) / adjacent (b)
                    //sin(A)  = opposite (a) / hypo (c)
                    //cos(B)  = adjacent (a) / hypo (c)
                    //aTan(B) = adjacent (b) / opposite (a)

                }
                //find b if b isnt found and its possible to find
                if (b <= 0)
                {

                    //try using c & a
                    //try using sin, cin, and tan

                    //try using c & a
                    if (a > 0 && c > 0)
                    {
                        b = Math.Sqrt((c * c) - (a * a));
                    }
                    //tan
                    else if (B > 0 && a > 0)
                    {
                        b = a * Math.Tan(TrigHelperMethods.DegToRad(B));
                    }
                    //sin
                    else if (B > 0 && c > 0)
                    {
                        b = c * Math.Sin(TrigHelperMethods.DegToRad(B));
                    }
                    //cos
                    else if (A > 0 && c > 0)
                    {
                        b = c * Math.Cos(TrigHelperMethods.DegToRad(A));
                    }
                    //using sin
                    //using cin
                }
                //find c if c isnt found and its possible to find
                if (c <= 0)
                {
                    //try using b & a
                    //try using sin, cin, and tan

                    //try using b & a
                    if (a > 0 && b > 0)
                    {
                        c = Math.Sqrt((a * a) + (b * b));
                    }
                }

                //find A
                if (A <= 0)
                {
                    //try using C and B
                    if (C > 0 && B > 0)
                    {
                        A = (180 - C) - B;
                    }
                    if (a > 0 && b > 0)
                    {
                        A = TrigHelperMethods.RadToDeg(Math.Atan(a / b));
                    }
                }
                //find B
                if (B <= 0)
                {
                    //try using C and A
                    if (C > 0 && A > 0)
                    {
                        B = (180 - C) - A;
                    }
                    if (a > 0 && b > 0)
                    {
                        B = TrigHelperMethods.RadToDeg(Math.Atan(b / a));
                    }
                }
                //find C
                if (C <= 0)
                {
                    //try using A and B
                    if (B > 0 && A > 0)
                    {
                        C = (180 - B) - A;
                    }
                }

                loops++;
            }

            return $"{a}|{b}|{c}|{A}|{B}|{C}";
        }

        public static double AngleFinder()
        {
            double a = IO.GetDoubleInput("Value of a: ");
            double b = IO.GetDoubleInput("Value of b: ");
            double c = IO.GetDoubleInput("Value of c: ");

            //find A
            if (a > 0 && c > 0)
            {
                return Math.Asin(a / c);
            }
            //find B
            else if(b > 0 & c > 0)
            {
                return Math.Asin(b / c);
            }
            //find C
            else if(b > 0 & a > 0)
            {
                //I think
                return Math.Atan(b / a);
            }

            return -1;
        }
        public static double AngleFinder(double a, double b, double c)
        {
            //find A
            if (a > 0 && c > 0)
            {
                return Math.Asin(a / c);
            }
            //find B
            else if (b > 0 & c > 0)
            {
                return Math.Asin(b / c);
            }
            //find C
            else if (b > 0 & a > 0)
            {
                //I think
                return Math.Atan(b / a);
            }

            return -1;
        }

        public static string InverseSohCahToa(double value, bool degrees = true)
        {
            double sin;
            double cos;
            double tan;

            if (degrees)
            {
                value = TrigHelperMethods.DegToRad(value);
                sin = Math.Asin(value);
                cos = Math.Acos(value);
                tan = Math.Atan(value);
            }
            else
            {
                sin = Math.Asin(value);
                cos = Math.Acos(value);
                tan = Math.Atan(value);
            }

            return $"ASin({sin}) | ACos({cos}) | ATan({tan})";
        }

        public static string SohCahToaChoChaCaoAll(double value, bool degrees = true)
        {
            double sin;
            double cos;
            double tan;
            double asin;
            double acos;
            double atan;

            if (degrees)
            {
                value = TrigHelperMethods.DegToRad(value);
                sin = Math.Sin(value);
                cos = Math.Cos(value);
                tan = Math.Tan(value);
                asin = 1 / sin;
                acos = 1 / cos;
                atan = 1 / tan;
            }
            else
            {
                sin = Math.Sin(value);
                cos = Math.Cos(value);
                tan = Math.Tan(value);
                asin = 1 / sin;
                acos = 1 / cos;
                atan = 1 / tan;
            }

            return $"Sin({sin}) | Cos({cos}) | Tan({tan}) \nCsc({asin}) | Sec({acos}) | Cot({atan})";
        }
        public static string SohCahToa(double opposite, double adjacent, double hypotenuse)
        {
            //if multiple are invalid, return null
            if ((opposite > 0 && (adjacent > 0 || hypotenuse > 0)) || (adjacent > 0 && hypotenuse > 0)) { return null; }

            float result = 0;
            string ret = "";
            //Soh / Sine / Sin
                //Opposite / Hypotenuse
            if(adjacent < 0)
            {
                result = (float)Math.Sin((double)(opposite / hypotenuse));
                ret = ($"Sin: {result} | Fractional {opposite}/{hypotenuse}");
            }
            //Cah / Cosine / Cos
                //Adjacent / Hypotenuse
            else if(opposite < 0)
            {
                result = (float)Math.Cos((double)(adjacent / hypotenuse));
                ret = ($"Cos: {result} | Fractional {adjacent}/{hypotenuse}");
            }
            //Toa / Tangent / Tan
                //Opposite / Adjacent
            else
            {
                result = (float)Math.Tan((double)(opposite / adjacent));
                ret = ($"Tan: {result} | Fractional {opposite}/{adjacent}");
            }
            return ret;
        }
        public static string ChoShaCao(double opposite, double adjacent, double hypotenuse)
        {
            //if multiple are invalid, return null
            if ((opposite > 0 && (adjacent > 0 || hypotenuse > 0)) || (adjacent > 0 && hypotenuse > 0)) { return null; }

            float result = 0;
            //Soh / Sine / Sin
            //Opposite / Hypotenuse
            if (adjacent < 0)
            {
                result = (float)Math.Asin((double)(hypotenuse / opposite));
                Console.WriteLine($"ASin: {result} | Fractional {hypotenuse}/{opposite}");
            }
            //Cah / Cosine / Cos
            //Adjacent / Hypotenuse
            else if (opposite < 0)
            {
                result = (float)Math.Acos((double)(hypotenuse / adjacent));
                Console.WriteLine($"ACos: {result} | Fractional {hypotenuse}/{adjacent}");
            }
            //Toa / Tangent / Tan
            //Opposite / Adjacent
            else
            {
                result = (float)Math.Atan((double)(adjacent / opposite));
                Console.WriteLine($"ATan: {result} | Fractional {adjacent}/{opposite}");
            }

            return null;
        }
    }

    static class CircleHelperMethods
    {
        private static string[] CircleMethods = new string[] { "Helper Methods", "FindArcFromCircumferenceTheta", "FindCircumferenceFromArcTheta", "FindRadiusFromArcTheta", "Find Center Angle", "FullConvertToDegree", "FullConvertToList", "Fraction to Degrees" };
        private static string[] CircleHelpers = new string[] { "Deg - Min", "Deg - Sec", "Min - Sec", "Min - Deg", "Sec - Deg", "Sec - Min" };
        public static void CircleController()
        {
            Console.WriteLine("Circle Controller\n");
            float a = -1;
            float b = -1;
            float c = -1;
            int input = int.MaxValue;
            //find out what method to call using the avalible methods
            while (input != 0)
            {
                input = IO.GetListInput(CircleMethods);
                switch (input)
                {
                    case 1:
                        CircleHelperController();
                        break;
                    case 2:
                        a = IO.GetFloatInput("Enter Circumference: ");
                        b = IO.GetFloatInput("Enter Theta: ");
                        Console.WriteLine("Solution: " + FindArcFromCircumferenceTheta(a, b));
                        break;
                    case 3:
                        a = IO.GetFloatInput("Enter Arc Length: ");
                        b = IO.GetFloatInput("Enter Theta: ");
                        Console.WriteLine("Solution: " + FindCircumferenceFromArcTheta(a, b));
                        break;
                    case 4:
                        a = IO.GetFloatInput("Enter Arc Length: ");
                        b = IO.GetFloatInput("Enter Theta: ");
                        Console.WriteLine("Solution: " + FindRadiusFromArcTheta(a, b));
                        break;
                    case 5:
                        Console.WriteLine("Solution: " + FindCenterAngle());
                        break;
                    case 6:
                        a = IO.GetFloatInput("Enter Degrees: ");
                        b = IO.GetFloatInput("Enter Minutes: ");
                        c = IO.GetFloatInput("Enter Seconds: ");
                        Console.WriteLine("Solution: " + FullConvertToDegree(a, b, c));
                        break;
                    case 7:
                        a = IO.GetFloatInput("Enter Degrees: ");
                        Console.WriteLine("Solution: " + FullConvertToList(a));
                        break;
                    case 8:
                        Console.WriteLine(FractionToDegreesOfCircle());
                        break;
                    default:
                        Console.WriteLine("Now Exiting Circle Controller");
                        break;
                }
            }
        }
        public static void CircleHelperController()
        {
            Console.WriteLine("Circle Helper Controller");
        }

        //Methods
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

        public static float FullConvertToDegree(float degree, float min, float sec)
        {
            float retVal = degree;
            retVal += MinutesToDegrees(min);
            retVal += SecondsToDegrees(sec);
            return retVal;
        }
        public static string FullConvertToList(float degrees)
        {
            float degree = (float)Math.Floor(degrees);
            float min = DegreeToMinutes(degrees - degree);
            float minReturn = (float)Math.Floor(min);
            float sec = MinutesToSeconds(min - minReturn);
            return $"{degree} {minReturn}' {sec}\"";
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

        //Conversions
        public static float DegreeToMinutes(float degrees)
        {

            return degrees * 60.0f;
        }
        public static float DegreeToSeconds(float degrees)
        {
            return degrees * 3600.0f;
        }
        public static float MinutesToSeconds(float minutes)
        {
            return minutes * 60.0f;
        }
        public static float MinutesToDegrees(float minutes)
        {
            return minutes / 60.0f;
        }
        public static float SecondsToDegrees(float seconds)
        {
            return seconds / 3600.0f;
        }
        public static float SecondsToMinutes(float seconds)
        {
            return seconds / 60.0f;
        }
    }
}
