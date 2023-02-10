using System;

namespace TrigAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(TrigHelperMethods.SolveForASohCahToa());
            //Console.WriteLine(TrigHelperMethods.FindSCTEverything());
            TrigHelperMethods.TrigController();
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
