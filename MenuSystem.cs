using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    class MenuSystem
    {
        //General
        private static string[] MethodOptions = new string[] { "Conversion", "Circle", "Triangle", "Graph" };
        public static void MethodController()
        {

            int input = int.MaxValue;
            while (input != 0)
            {
                input = IO.GetListInput(MethodOptions);
                switch (input)
                {
                    case 1:
                        ConversionController();
                        break;
                    case 2:
                        CircleController();
                        break;
                    case 3:
                        TriangleController();
                        break;
                    case 4:
                        GraphController();
                        break;
                    default:
                        Console.WriteLine("Exiting App");
                        break;
                }
            }
        }

        //Triangle
        private static string[] TriangleMethods = new string[] { "Find Area", "Pythagrean Theorem", "SohCahToa & ChoChaCao (1 Input)", "SohCahToa (Calculate From 3 Num)", "ChoShaCao (Calculate From 3 Num)", "Inverse SohCahToa", "Angle Finder", "Sides And Angles (Right Triangle)", "Find Similar Triangles", "Difference Between Triangles" };
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
                        a = IO.GetDoubleInput("Base: ");
                        b = IO.GetDoubleInput("Height: ");
                        Console.WriteLine("Area: " + Triangle.TriangleFindArea(a, b));
                        break;
                    case 2:
                        a = IO.GetDoubleInput("A (enter -1 for unknown): ");
                        b = IO.GetDoubleInput("B (enter -1 for unknown): ");
                        c = IO.GetDoubleInput("C (enter -1 for unknown): ");
                        double answer = Triangle.PythagoreanTheorem(a, b, c);
                        Console.WriteLine("Answer: " + answer + " or Sqrt(" + answer * answer + ")");
                        break;
                    case 3:
                        a = IO.GetDoubleInput("Enter Number");
                        Console.WriteLine("Using A: " + a);
                        Console.WriteLine("Answer: " + Triangle.SohCahToaChoChaCaoAll(a));
                        break;
                    case 4:
                        a = IO.GetDoubleInput("Opposite (enter -1 for unknown): ");
                        b = IO.GetDoubleInput("Adjacent (enter -1 for unknown): ");
                        c = IO.GetDoubleInput("Hypotenuse (enter -1 for unknown): ");
                        Console.WriteLine("Answer: " + Triangle.SohCahToa(a, b, c));
                        break;
                    case 5:
                        a = IO.GetDoubleInput("Opposite (enter -1 for unknown): ");
                        b = IO.GetDoubleInput("Adjacent (enter -1 for unknown): ");
                        c = IO.GetDoubleInput("Hypotenuse (enter -1 for unknown): ");
                        Console.WriteLine("Answer: " + Triangle.ChoShaCao(a, b, c));
                        break;
                    case 6:
                        a = IO.GetDoubleInput("Value (enter -1 for unknown): ");
                        Console.WriteLine("Answer: " + Triangle.InverseSohCahToa(a));
                        //inverse
                        break;
                    case 7:
                        Console.WriteLine("Answer: " + Triangle.AngleFinder());
                        break;
                    case 8:
                        Console.WriteLine("Answer: " + Triangle.SidesAndAnglesRight());
                        //solve
                        break;
                    case 9:
                        Console.WriteLine("Answer: " + Triangle.SimilarTriangleSolution());
                        break;
                    case 10:
                        Console.WriteLine(Triangle.FindDifferenceBetweenTriangles());
                        break;
                    default:
                        Console.WriteLine("Now Exiting Triangle");
                        break;
                }
            }
        }
        //Circle
        private static string[] CircleMethods = new string[] { "FindArcFromCircumferenceTheta", "FindCircumferenceFromArcTheta", "FindRadiusFromArcTheta", "Find Center Angle", "Fraction to Degrees" };
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
                        a = IO.GetFloatInput("Enter Circumference: ");
                        b = IO.GetFloatInput("Enter Theta: ");
                        Console.WriteLine("Solution: " + Circle.FindArcFromCircumferenceTheta(a, b));
                        break;
                    case 2:
                        a = IO.GetFloatInput("Enter Arc Length: ");
                        b = IO.GetFloatInput("Enter Theta: ");
                        Console.WriteLine("Solution: " + Circle.FindCircumferenceFromArcTheta(a, b));
                        break;
                    case 3:
                        a = IO.GetFloatInput("Enter Arc Length: ");
                        b = IO.GetFloatInput("Enter Theta: ");
                        Console.WriteLine("Solution: " + Circle.FindRadiusFromArcTheta(a, b));
                        break;
                    case 4:
                        Console.WriteLine("Solution: " + Circle.FindCenterAngle());
                        break;
                    case 5:
                        Console.WriteLine(Circle.FractionToDegreesOfCircle());
                        break;
                    default:
                        Console.WriteLine("Now Exiting Circle Controller");
                        break;
                }
            }
        }
        //Converstions
        private static string[] ConversionMethods = new string[] { "DegreeToMinutes", "DegreeToSeconds", "MinutesToSeconds", "MinutesToDegrees", "SecondsToDegrees", "SecondsToMinutes", "FullConvertToDegree", "FullConvertToList", "DegToRad", "RadToDeg" };
        public static void ConversionController()
        {
            Console.WriteLine("Conversion Controller\n");
            double a, b, c = -1;
            int input = int.MaxValue;
            //find out what method to call using the avalible methods
            while (input != 0)
            {
                input = IO.GetListInput(ConversionMethods);
                switch (input)
                {
                    case 1:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + Conversions.DegreeToMinutes(a));
                        break;
                    case 2:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + Conversions.DegreeToSeconds(a));
                        break;
                    case 3:
                        a = IO.GetDoubleInput("Minutes: ");
                        Console.WriteLine("Solution: " + Conversions.MinutesToSeconds(a));
                        break;
                    case 4:
                        a = IO.GetDoubleInput("Minutes: ");
                        Console.WriteLine("Solution: " + Conversions.MinutesToDegrees(a));
                        break;
                    case 5:
                        a = IO.GetDoubleInput("Seconds: ");
                        Console.WriteLine("Solution: " + Conversions.SecondsToDegrees(a));
                        break;
                    case 6:
                        a = IO.GetDoubleInput("Seconds: ");
                        Console.WriteLine("Solution: " + Conversions.SecondsToMinutes(a));
                        break;
                    case 7:
                        a = IO.GetDoubleInput("Degrees: ");
                        b = IO.GetDoubleInput("Minutes: ");
                        c = IO.GetDoubleInput("Seconds: ");
                        Console.WriteLine("Solution: " + Conversions.FullConvertToDegree(a, b, c));
                        break;
                    case 8:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + Conversions.FullConvertToList(a));
                        break;
                    case 9:
                        a = IO.GetDoubleInput("Degrees: ");
                        Console.WriteLine("Solution: " + Conversions.DegToRad(a));
                        break;
                    case 10:
                        a = IO.GetDoubleInput("Radians: ");
                        Console.WriteLine("Solution: " + Conversions.RadToDeg(a));
                        break;
                    default:
                        Console.WriteLine("Exiting Conversion Controller");
                        break;
                }
            }
        }
        //Graph
        private static string[] GraphMethods = new string[] { "Find Angles and Quadrent", "Triangles in Quadrants (Point)", "Triangles in Quadrants (Angle)", "Find Quadrant (Sin,Cos,Tan)", "Find Exact Value From Angle" };
        public static void GraphController()
        {
            Console.WriteLine("Graph Controller\n");
            double a, b, c = -1;
            int input = int.MaxValue;
            //find out what method to call using the avalible methods
            while (input != 0)
            {
                input = IO.GetListInput(GraphMethods);
                switch (input)
                {
                    case 1:
                        Graph.FindPNAngleQuadrant();
                        break;
                    case 2:
                        Graph.TrianglesInQuadrants();
                        break;
                    case 3:
                        Graph.TrianglesInQuadrantsFromAngle();
                        break;
                    case 4:
                        a = IO.GetDoubleInput("Sin: ");
                        b = IO.GetDoubleInput("Cos: ");
                        c = IO.GetDoubleInput("Tan: ");
                        Graph.FindQuadrent(a, b, c);
                        break;
                    case 5:
                        Graph.FindExactValueFromAngle();
                        break;
                    default:
                        Console.WriteLine("Exiting Graph");
                        break;
                }
            }
        }
        //Trig
        //
    }
}
