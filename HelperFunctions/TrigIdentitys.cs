using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    static class TrigIdentitys
    {
        //probably can be changed alot
        enum TriangleType
        {
            AAS,
            //ASA,
            SAS,
            SSA,
            SSS,
            UNKNOWN
        }

        public static string[] sohcantoaList = new string[] { "Sin", "Cos", "Tan", "Csc", "Sec", "Cot" };

        public static string SolveForDegrees()
        {
            int identityInput = IO.GetListInput(sohcantoaList);
            int solveFor = IO.GetIntInput("Enter what you are trying to solve for: ");
            double answer = double.MaxValue;
            List<int> solutions = new List<int>();

            for(int i = 0; i <= 360; i++)
            {
                switch (identityInput)
                {
                    case 1:
                        answer = Math.Sin(TrigHelperMethods.DegToRad(i));
                        break;
                    case 2:
                        answer = Math.Cos(TrigHelperMethods.DegToRad(i));
                        break;
                    case 3:
                        answer = Math.Tan(TrigHelperMethods.DegToRad(i));
                        break;
                    case 4:
                        answer = 1 / Math.Sin(TrigHelperMethods.DegToRad(i));
                        break;
                    case 5:
                        answer = 1 / Math.Cos(TrigHelperMethods.DegToRad(i));
                        break;
                    case 6:
                        answer = Math.Cos(TrigHelperMethods.DegToRad(i)) / Math.Sin(TrigHelperMethods.DegToRad(i));
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"Answer: {answer} : Looking For: {solveFor} : i: {i}");

                if(answer == solveFor)
                {
                    solutions.Add(i);
                }
            }

            string retVal = "Answers: ";
            solutions.ForEach(s => retVal += $"{s} +- 360");

            return retVal;
        }

        public static double[][] SidesAndAngles()
        {
            double[][] retVal = new double[2][];

            double a = IO.GetDoubleInput("Input a: ");
            double b = IO.GetDoubleInput("Input b: ");
            double c = IO.GetDoubleInput("Input c: ");
            double A = IO.GetDoubleInput("Input A: ");
            double B = IO.GetDoubleInput("Input B: ");
            double C = IO.GetDoubleInput("Input C: ");

            TriangleType type = GetTriangleType(a, b, c, A, B, C);
            Console.WriteLine("Triangle Type: " + type.ToString());
            switch (type)
            {
                case TriangleType.AAS:
                    retVal[0] = SolveOneSideTwoAngle(a, b, c, A, B, C);
                    break;
                case TriangleType.SAS:
                    retVal[0] = SolveSAS(a, b, c, A, B, C);
                    break;
                case TriangleType.SSA:
                    retVal = SolveSSA(a, b, c, A, B, C);
                    break;
                case TriangleType.SSS:
                    retVal[0] = SolveSSS(a, b, c, A, B, C);
                    break;
                case TriangleType.UNKNOWN:
                    Console.WriteLine("No Solution: Triangle Type Unknown");
                    break;
                default:
                    Console.WriteLine("No Solution: This should never be output, something is wrong");
                    break;
            }

            return retVal;
        }
        private static TriangleType GetTriangleType(double a, double b, double c, double A, double B, double C)
        {
            //find and return the type
            //Two angle 1 Side
            if(A > 0 && B > 0 && C < 0 || A > 0 && B < 0 && C > 0 || A < 0 && B > 0 && C > 0)
            {
                return TriangleType.AAS;
            }

            //SSS
            if (a > 0 && b > 0 && c > 0) return TriangleType.SSS;

            //Starts with SSA
            if (a > 0 && A > 0 && (c > 0 || b > 0)) return TriangleType.SSA;
            if (b > 0 && B > 0 && (a > 0 || c > 0)) return TriangleType.SSA;
            if (c > 0 && C > 0 && (a > 0 || b > 0)) return TriangleType.SSA;

            //SAS
            if (a > 0 && b > 0 && C > 0) return TriangleType.SAS;
            if (a > 0 && c > 0 && B > 0) return TriangleType.SAS;
            if (b > 0 && c > 0 && A > 0) return TriangleType.SAS;
            
            //ASA
//            if (b > 0 && A > 0 && C > 0) return TriangleType.ASA;
//            if (a > 0 && B > 0 && C > 0) return TriangleType.ASA;
//            if (c > 0 && A > 0 && B > 0) return TriangleType.ASA;

            return TriangleType.UNKNOWN;
        }

        private static double[] SolveOneSideTwoAngle(double a, double b, double c, double A, double B, double C)
        {
            GetMissingAngle(A, B, C, out A, out B, out C);
            if (a > 0)
            {
                b = LawsOfSin(a, A, b, B);
                c = LawsOfSin(a, A, c, C);
            }
            else if (b > 0)
            {
                a = LawsOfSin(a, A, b, B);
                c = LawsOfSin(b, B, c, C);
            }
            else
            {
                a = LawsOfSin(a, A, c, C);
                b = LawsOfSin(c, C, b, B);
            }
            double[] retVal = new double[] { a, b, c, A, B, C };
            return retVal;
        }


        private static double[] SolveSSS(double a, double b, double c, double A, double B, double C)
        {
            //laws of cosine
            A = Conversions.RadToDeg(Math.Acos((b * b + c * c - a * a) / (2 * b * c)));
            B = Conversions.RadToDeg(Math.Acos((a * a + c * c - b * b) / (2 * a * c)));
            C = Conversions.RadToDeg(Math.Acos((a * a + b * b - c * c) / (2 * a * b)));

            double[] retVal = new double[] { a, b, c, A, B, C };
            return retVal;
        }
        private static double[] SolveSAS(double a, double b, double c, double A, double B, double C)
        {

            //find what angle we have

            if(A > 0)
            {
                Console.WriteLine("Solving with angle A");
                a = LawsOfCos(a, b, c, A, B, C, 'a');
                B = LawsOfSin(a, A, b, B);
                C = LawsOfSin(a, A, c, C);

                //Larger side gets larger angle
                if (b > c)
                {
                    double B1 = 180 - A - C;
                    if(B1 > B)
                    {
                        B = B1;
                    }
                    else
                    {
                        C = 180 - A - B;
                    }
                }
                else
                {
                    double C1 = 180 - A - B;
                    if(C1 > C)
                    {
                        C = C1;
                    }
                    else
                    {
                        B = 180 - A - C;
                    }
                }

            }
            else if(B > 0)
            {
                Console.WriteLine("Solving with angle B");
                b = LawsOfCos(a, b, c, A, B, C, 'b');
                A = LawsOfSin(a, A, b, B);
                C = LawsOfSin(c, C, b, B);

                //Larger side gets larger angle
                if (a > c)
                {
                    double A1 = 180 - B - C;
                    if (A1 > A)
                    {
                        A = A1;
                    }
                    else
                    {
                        C = 180 - A - B;
                    }
                }
                else
                {
                    double C1 = 180 - A - B;
                    if (C1 > C)
                    {
                        C = C1;
                    }
                    else
                    {
                        A = 180 - B - C;
                    }
                }
            }
            else if(C > 0)
            {
                Console.WriteLine("Solving with angle C");
                c = LawsOfCos(a, b, c, A, B, C, 'c');
                A = LawsOfSin(a, A, b, B);
                B = LawsOfSin(c, C, b, B);

                //Larger side gets larger angle
                if (b > a)
                {
                    double B1 = 180 - A - C;
                    if (B1 > B)
                    {
                        B = B1;
                    }
                    else
                    {
                        A = 180 - C - B;
                    }
                }
                else
                {
                    double A1 = 180 - C - B;
                    if (A1 > A)
                    {
                        A = A1;
                    }
                    else
                    {
                        B = 180 - A - C;
                    }
                }
            }

            double[] retVal = new double[] { a, b, c, A, B, C };
            return retVal;
        }
        private static double[][] SolveSSA(double a, double b, double c, double A, double B, double C)
        {
            double[][] retVal = new double[][]
            {
                new double[] {-1,-1,-1,-1,-1,-1 },
                new double[] {-1,-1,-1,-1,-1,-1 }
            };

            //find the angle we have to solve with
            //find out num solutions
            //find the solutions
            double height;
            if(A > 0)
            {
                height = Math.Sin(Conversions.DegToRad(A)) * b;
                Console.WriteLine("(Angle A) Height: " + height);
                if(a >= b || a == height)
                {
                    //1 solution
                    retVal[0] = SolveSSAOneSolution(a, b, c, A, B, C);
                }
                else if(a < height)
                {
                    //no solutions
                    Console.WriteLine("No Solution");
                }
                if(a < b && a > height)
                {
                    //two solutions
                    retVal = SolveSSATwoSolutions(a, b, c, A, B, C);
                }
            }
            else if (B > 0)
            {
                height = Math.Sin(Conversions.DegToRad(B)) * c;
                Console.WriteLine("(Angle B) Height: " + height);
                if (b > c)
                {
                    // 1 solution
                    retVal[0] = SolveSSAOneSolution(a, b, c, A, B, C);
                }
                else if(b < height)
                {
                    //No Solutions
                    Console.WriteLine("No Solution");
                }
                if(b < c && a > height)
                {
                    //2 solutions
                    retVal = SolveSSATwoSolutions(a, b, c, A, B, C);
                }
            }
            else if (C > 0)
            {
                height = Math.Sin(Conversions.DegToRad(C)) * a;
                Console.WriteLine("(Angle C) Height: " + height);
                if (c > a)
                {
                    //1 solution
                    retVal[0] = SolveSSAOneSolution(a, b, c, A, B, C);
                }
                else if (c < height)
                {
                    //no solutions
                    Console.WriteLine("No Solution");
                }
                if (c < a && c > height)
                {
                    //two solutions
                    retVal = SolveSSATwoSolutions(a, b, c, A, B, C);
                }
            }

            return retVal;
        }

        public static double[][] SolveSSATwoSolutions(double a, double b, double c, double A, double B, double C)
        {
            double[][] retVal = new double[][]
            {
                new double[] {-1,-1,-1,-1,-1,-1 },
                new double[] {-1,-1,-1,-1,-1,-1 }
            };
            retVal[0] = SolveSSAOneSolution(a, b, c, A, B, C);

            double a1 = retVal[0][0];
            double b1 = retVal[0][1];
            double c1 = retVal[0][2];
            double A1 = retVal[0][3];
            double B1 = retVal[0][4];
            double C1 = retVal[0][5];

            double a2 = a;
            double b2 = b;
            double c2 = c;
            double A2 = A;
            double B2 = B;
            double C2 = C;

            if (A > 0)
            {
                if (b > 0)
                {
                    B2 = 180 - B1;
                    C2 = 180 - B2 - A;
                    c2 = LawsOfSin(a, A, c2, C2);
                }
                else
                {
                    C2 = 180 - C1;
                    B2 = 180 - C2 - A;
                    b2 = LawsOfSin(a, A, b2, B2);
                }
            }
            else if (B > 0)
            {
                if (a > 0)
                {
                    Console.WriteLine("Not Finished");
                    //B2 = 180 - B1;
                    //C2 = 180 - B2 - A;
                    //c2 = LawsOfSin(a, A, c2, C2);
                }
                else
                {
                    Console.WriteLine("Not Finished");
                    //B2 = 180 - B1;
                    //C2 = 180 - B2 - A;
                    //c2 = LawsOfSin(a, A, c2, C2);
                }
            }
            else if (C > 0)
            {
                if (a > 0)
                {
                    A2 = 180 - A1;
                    B2 = 180 - A2 - C;
                    b2 = LawsOfSin(b2, B2, c, C);
                }
                else
                {
                    B2 = 180 - B1;
                    A2 = 180 - B2 - C;
                    a2 = LawsOfSin(a2, A2, c, C);
                }
            }

            retVal[1] = new double[] { a2, b2, c2, A2, B2, C2 };

            return retVal;
        }
        public static double[] SolveSSAOneSolution(double a, double b, double c, double A, double B, double C)
        {

            if(A > 0)
            {
                if (b > 0) 
                { 
                    B = LawsOfSin(a, A, b, B);
                    C = 180 - A - B;
                    c = LawsOfSin(a, A, c, C);
                }
                else 
                { 
                    C = LawsOfSin(a, A, c, C);
                    B = 180 - A - C;
                    b = LawsOfSin(a, A, b, B);
                }                
            }
            else if (B > 0)
            {
                if (a > 0)
                {
                    A = LawsOfSin(a, A, b, B);
                    C = 180 - A - B;
                    c = LawsOfSin(a, A, c, C);
                }
                else
                {
                    C = LawsOfSin(b, B, c, C);
                    B = 180 - A - C;
                    b = LawsOfSin(a, A, b, B);
                }
            }
            else if (C > 0)
            {
                if (b > 0)
                {
                    B = LawsOfSin(c, C, b, B);
                    A = 180 - C - B;
                    a = LawsOfSin(a, A, c, C);
                }
                else
                {
                    A = LawsOfSin(a, A, c, C);
                    B = 180 - A - C;
                    b = LawsOfSin(c, C, b, B);
                }
            }

            double[] retVal = new double[] { a, b, c, A, B, C };
            return retVal;
        }


        public static double LawsOfSin(double a, double A, double b, double B) {
            if((a < 0 && A < 0) || (b < 0 && B < 0) || (a < 0 && b < 0) || (A < 0 && B < 0) || (b < 0 && A < 0) || (a < 0 && B < 0))
            {
                //Multiple are invalid, return no response
                Console.WriteLine("Impossible To Solve");
                return -1;
            }

            double res;

            if(a < 0)
            {
                res = Math.Sin(Conversions.DegToRad(A)) / (Math.Sin(Conversions.DegToRad(B)) / b);
            }else if(b < 0)
            {
                res = Math.Sin(Conversions.DegToRad(B)) / (Math.Sin(Conversions.DegToRad(A)) / a);
            }
            else if (A < 0)
            {
                res = Conversions.RadToDeg(Math.Asin((Math.Sin(Conversions.DegToRad(B)) / b) * a));
            }
            else
            {
                res = Conversions.RadToDeg(Math.Asin((Math.Sin(Conversions.DegToRad(A)) / a) * b));
            }

            return res;
        }
        public static double LawsOfCos(double a, double b, double c, double A, double B, double C, char ToSolve) 
        {
            if (ToSolve.Equals('a'))
            {
                if (b < 0 || c < 0 || A < 0)
                {
                    Console.WriteLine("Cannot find a");
                }
                else
                {
                    Console.WriteLine("Found a");
                    return Math.Sqrt(b * b + c * c - 2 * b * c * Math.Cos(Conversions.DegToRad(A)));
                }
            }

            if (ToSolve.Equals('b'))
            {
                if (a < 0 || c < 0 || B < 0)
                {
                    Console.WriteLine("Cannot find b");
                }
                else
                {
                    Console.WriteLine("Found b");
                    return Math.Sqrt(a * a + c * c - 2 * a * c * Math.Cos(Conversions.DegToRad(B)));
                }
            }

            if (ToSolve.Equals('c'))
            {
                if (b < 0 || a < 0 || C < 0)
                {
                    Console.WriteLine("Cannot find c");
                }
                else
                {
                    Console.WriteLine("Found c");
                    return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(Conversions.DegToRad(C)));
                }
            }

            if (ToSolve.Equals('A'))
            {
                if (b < 0 || c < 0 || a < 0)
                {
                    Console.WriteLine("Cannot find A");
                }
                else
                {
                    Console.WriteLine("Found A");
                    return Conversions.RadToDeg(Math.Acos(Conversions.DegToRad(b * b + c * c - a * a) / (2 * b * c)));
                }
            }

            if (ToSolve.Equals('B'))
            {
                if (b < 0 || c < 0 || a < 0)
                {
                    Console.WriteLine("Cannot find B");
                }
                else
                {
                    Console.WriteLine("Found B");
                    return Conversions.RadToDeg(Math.Acos(Conversions.DegToRad(a * a + c * c - b * b) / (2 * a * c)));
                }
            }

            if(ToSolve.Equals('C'))
            {
                if (b < 0 || c < 0 || a < 0)
                {
                    Console.WriteLine("Cannot find C");
                }
                else
                {
                    Console.WriteLine("Found C");
                    return Conversions.RadToDeg(Math.Acos(Conversions.DegToRad(a * a + b * b - c * c) / (2 * a * b)));
                }
            }

            return -1;
        }


        public static void OutputTriangle(double[][] input)
        {
            if (input[0] == null)
            {
                Console.WriteLine("NO TRIANGLES!!!");
                return;
            }
            Console.WriteLine($"\na1: {input[0][0]} | b1: {input[0][1]} | c1: {input[0][2]}\nA1: {input[0][3]} | B1: {input[0][4]} | C1: {input[0][5]}");
            if(input[1] == null)
            {
                return;
            }
            Console.WriteLine($"\na2: {input[1][0]} | b2: {input[1][1]} | c2: {input[1][2]}\nA2: {input[1][3]} | B2: {input[1][4]} | C2: {input[1][5]}");
        }

        private static void GetMissingAngle(double a, double b, double c, out double A, out double B, out double C)
        {
            A = a;
            B = b;
            C = c;
            if(a > 0 && b > 0 && c < 0)
            {
                C = 180 - a - b;
            }
            if (a > 0 && b < 0 && c > 0)
            {
                B = 180 - a - c;
            }
            if (a < 0 && b > 0 && c > 0)
            {
                A = 180 - c - b;
            }
        }
    }
}
