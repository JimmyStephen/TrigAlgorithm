using System;

namespace TrigAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuSystem.MethodController();
            //Console.WriteLine("Test 1: " + TrigIdentitys.LawsOfSin(15, 25, 20, -1));
            //Console.WriteLine("Test 2: " + TrigIdentitys.LawsOfSin(15, 25, -1, 34.29));
            //Console.WriteLine("Test 3: " + TrigIdentitys.LawsOfSin(15, 25, -1, 120.7));
            //Console.WriteLine("Test 4: " + TrigIdentitys.LawsOfSin(15, 25, -1, 9.3));

            //Console.WriteLine("Test 1: " + TrigIdentitys.LawsOfCos(-1, 4, 2, 37, -1, -1));

            //while (!Console.ReadLine().ToLower().Equals("N"))
            //{
            //    double[][] solved = TrigIdentitys.SidesAndAngles();
            //    TrigIdentitys.OutputTriangle(solved);
            //    Console.Write("Continue? Y/N: ");
            //}
                
                //Console.WriteLine(TrigIdentitys.SolveForDegrees());

            //Console.WriteLine(TrigHelperMethods.SolveForASohCahToa());
            //Console.WriteLine(TrigHelperMethods.FindSCTEverything());
            //TrigHelperMethods.TrigController();
            //Conversions.DegToRad(30);
            //Conversions.DegToRad(60);
            //Conversions.DegToRad(90);
            //Conversions.DegToRad(120);
            //Conversions.DegToRad(150);
            //Conversions.DegToRad(180);
            //Conversions.DegToRad(210);
            //Conversions.DegToRad(240);
            //Conversions.DegToRad(270);
            //Conversions.DegToRad(300);
            //Conversions.DegToRad(330);
            //Conversions.DegToRad(360);
            //Console.WriteLine(Conversions.DegToRad(18));
            //Console.WriteLine(Conversions.DegToRad(9));
            //Console.WriteLine(Conversions.DegToRad(130));
            //Console.WriteLine(Conversions.DegToRad(140));
            //Console.WriteLine(Conversions.DegToRad(25));
            //Console.WriteLine(Conversions.DegToRad(648));
            //Console.WriteLine(Conversions.DegToRad(-221));
            //Console.WriteLine(Conversions.DegToRad(164));
            //Console.WriteLine(Conversions.DegToRad(35));
            //Console.WriteLine(Conversions.DegToRad(437));
            //Console.WriteLine(Conversions.DegToRad(-175));
            //Console.WriteLine(Conversions.DegToRad(Conversions.FullConvertToDegree(187, 24, 5)));
        }

        public static void ConvertOneAtATime()
        {
            string[] arr = new string[] { "Deg - Min", "Deg - Sec", "Min - Sec", "Min - Deg", "Sec - Deg", "Sec - Min" };
            int input = int.MaxValue;
            while (input != 0)
            {
                float output = -1;
                input = IO.GetListInput(arr);
                float toConvert = 0.0f;
                if (input != 0)
                {
                    Console.Write("What is the value of the number to convert: ");
                    string temp = Console.ReadLine();
                    toConvert = float.Parse(temp);
                }
                switch (input)
                {
                    case 1:
                        output = CircleHelperMethods.DegreeToMinutes(toConvert);
                        break;
                    case 2:
                        output = CircleHelperMethods.DegreeToSeconds(toConvert);
                        break;
                    case 3:
                        output = CircleHelperMethods.MinutesToSeconds(toConvert);
                        break;
                    case 4:
                        output = CircleHelperMethods.MinutesToDegrees(toConvert);
                        break;
                    case 5:
                        output = CircleHelperMethods.SecondsToDegrees(toConvert);
                        break;
                    case 6:
                        output = CircleHelperMethods.SecondsToMinutes(toConvert);
                        break;
                    default: break;
                }

                Console.WriteLine($"Conversion: {output}");
            }
        }
        public static void ConvertFullToDegLoop()
        {
            bool cont = true;
            string temp;
            float degree;
            float min;
            float sec;

            while (cont)
            {
                Console.Write("Enter Degree: ");
                temp = Console.ReadLine();
                degree = float.Parse(temp);
                Console.Write("Enter Minutes: ");
                temp = Console.ReadLine();
                min = float.Parse(temp);
                Console.Write("Enter Seconds: ");
                temp = Console.ReadLine();
                sec = float.Parse(temp);
                Console.WriteLine("Converted: " + CircleHelperMethods.FullConvertToDegree(degree, min, sec));
                Console.WriteLine("Continue? (Y/N)");
                cont = Console.ReadLine().ToUpper().Equals("Y");
            }
        }
        public static void ConvertDegToFullLoop()
        {
            bool cont = true;
            string temp;
            float degrees;

            while (cont)
            {
                Console.Write("Enter Degrees: ");
                temp = Console.ReadLine();
                degrees = float.Parse(temp);
                Console.WriteLine("Converted: " + CircleHelperMethods.FullConvertToList(degrees));
                Console.WriteLine("Continue? (Y/N)");
                cont = Console.ReadLine().ToUpper().Equals("Y");
            }
        }
    }
}
