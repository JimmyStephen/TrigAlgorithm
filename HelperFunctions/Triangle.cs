using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    class Triangle
    {
        //Methods | Unit One
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

            for (int i = 0; i < 6; i++)
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

            //get scale factor
            double scaleFactor = -1;
            if (triangleOneA > 0 && triangleTwoA > 0)
            {
                scaleFactor = triangleOneA / triangleTwoA;
            }
            else if (triangleOneB > 0 && triangleTwoB > 0)
            {
                scaleFactor = triangleOneB / triangleTwoB;
            }
            else if (triangleOneC > 0 && triangleTwoC > 0)
            {
                scaleFactor = triangleOneC / triangleTwoC;
            }

            if (triangleOneA > 0 && triangleOneB > 0 && triangleOneC < 0)
                triangleOneC = PythagoreanTheorem(triangleTwoA, triangleOneB, triangleOneC);
            if (triangleOneA > 0 && triangleOneB < 0 && triangleOneC > 0)
                triangleOneB = PythagoreanTheorem(triangleTwoA, triangleOneB, triangleOneC);
            if (triangleOneA < 0 && triangleOneB > 0 && triangleOneC > 0)
                triangleOneA = PythagoreanTheorem(triangleTwoA, triangleOneB, triangleOneC);

            if (triangleTwoA > 0 && triangleTwoB > 0 && triangleTwoC < 0)
                triangleTwoC = PythagoreanTheorem(triangleTwoA, triangleTwoB, triangleTwoC);
            if (triangleTwoA > 0 && triangleTwoB < 0 && triangleTwoC > 0)
                triangleTwoB = PythagoreanTheorem(triangleTwoA, triangleTwoB, triangleTwoC);
            if (triangleTwoA < 0 && triangleTwoB > 0 && triangleTwoC > 0)
                triangleTwoA = PythagoreanTheorem(triangleTwoA, triangleTwoB, triangleTwoC);

            //find the side lengths where available
            if (triangleOneA <= 0)
                triangleOneA = triangleTwoA * scaleFactor;
            if (triangleOneB <= 0)
                triangleOneB = triangleTwoB * scaleFactor;
            if (triangleOneC <= 0)
                triangleOneC = triangleTwoC * scaleFactor;
            if (triangleTwoA <= 0)
                triangleTwoA = triangleOneA * scaleFactor;
            if (triangleTwoB <= 0)
                triangleTwoB = triangleOneB * scaleFactor;
            if (triangleTwoC <= 0)
                triangleTwoC = triangleOneC * scaleFactor;

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
            if (c < 0 && a > 0 && b > 0)
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
                    else if (a > 0 && b > 0)
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
                    else if (a > 0 && b > 0)
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
            else if (b > 0 & c > 0)
            {
                return Math.Acos(b / c);
            }
            //find C
            else if (b > 0 & a > 0)
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
            if (degrees)
                value = TrigHelperMethods.DegToRad(value);

            double sin = Math.Asin(value);
            double cos = Math.Acos(value);
            double tan = Math.Atan(value);

            return $"ASin({sin}) | ACos({cos}) | ATan({tan})";
        }
        public static string SohCahToaChoChaCaoAll(double value, bool degrees = true)
        {
            if (degrees)
                value = TrigHelperMethods.DegToRad(value);

            double sin = Math.Sin(value);
            double cos = Math.Cos(value);
            double tan = Math.Tan(value);
            double asin = 1 / sin;
            double acos = 1 / cos;
            double atan = 1 / tan;

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
            if (adjacent < 0)
            {
                result = (float)Math.Sin((double)(opposite / hypotenuse));
                ret = ($"Sin: {result} | Fractional {opposite}/{hypotenuse}");
            }
            //Cah / Cosine / Cos
            //Adjacent / Hypotenuse
            else if (opposite < 0)
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

        public static string SolveForASohCahToa(double y)
        {
            double sin = Conversions.RadToDeg(Math.Asin(y));
            double cos = Conversions.RadToDeg(Math.Acos(y));
            double tan = Conversions.RadToDeg(Math.Atan(y));
            return $"ASin({sin}) | ACos({cos}) | ATan({tan})";
        }
    }
}
