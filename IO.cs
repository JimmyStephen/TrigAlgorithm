using System;
using System.Collections.Generic;
using System.Text;

namespace TrigAlgorithm
{
    static class IO
    {
        //Takes in an array of names
        //Checks if you input the number of an index, or an equal string to the name (compared using .Replace(" ", "").ToUpper().Equals(input.Replace(" ", "").ToUpper()))
        //removes all spaces, then makes both uppercase, and then compares them
        //returns the selection index
        public static int GetListInput(string[] array)
        {
            int retVal = -1;
            bool invalid = true;

            while (invalid)
            {
                //get a selection
                Console.WriteLine("Select a input");
                OutputArray(array);
                string input = Console.ReadLine();

                //see if the input is EXIT
                if (input.ToUpper().Equals("EXIT")) return -1;

                //see if the value is equal to the string value
                int foundIndex = FindIndexByString(array, input);
                if (foundIndex != -1) return foundIndex;

                //check if the input is a int, and then see if its valid if it is
                if (int.TryParse(input, out int intInput))
                {
                    if (intInput >= 0 && intInput <= array.Length) return intInput;
                }
            }

            return retVal;
        }
        public static int GetIntInput(string outputMessage)
        {
            while (true)
            {
                Console.Write(outputMessage);
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int retVal))
                {
                    return retVal;
                }
            }
        }
        public static float GetFloatInput(string outputMessage)
        {
            while (true)
            {
                Console.Write(outputMessage + "\n(start number with \"|\" for sqrt)");
                string inputString = Console.ReadLine();
                bool sqrt = inputString.StartsWith("|");
                if (sqrt)
                {
                    string numString = inputString.Replace("|", "");
                    if (float.TryParse(numString, out float retVal))
                    {
                        return (float)Math.Sqrt(retVal);
                    }
                }
                else
                {
                    if (float.TryParse(inputString, out float retVal))
                    {
                        return retVal;
                    }
                }
            }
        }
        public static double GetDoubleInput(string outputMessage)
        {
            while (true)
            {
                Console.Write(outputMessage + "\n(start number with \"|\" for sqrt)");
                string inputString = Console.ReadLine();
                bool sqrt = inputString.StartsWith("|");
                if (sqrt)
                {
                    string numString = inputString.Replace("|", "");
                    if (double.TryParse(numString, out double retVal))
                    {
                        return Math.Sqrt(retVal);
                    }
                }
                else
                {
                    if (double.TryParse(inputString, out double retVal))
                    {
                        return retVal;
                    }
                }
            }
        }
        public static bool GetBoolInput(string message, string trueRes = "Y", string falseRes = "N")
        {
            Console.WriteLine("WIP");
            return false;
        }


        private static void OutputArray(string[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i+1}.) {array[i]}");
            }
            Console.WriteLine("0.) Exit");
        }
        private static int FindIndexByString(string[] array, string toFind)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (CompareString(array[i], toFind)) return i;
            }
            return -1;
        }
        private static bool CompareString(string a, string b)
        {
            return a.Replace(" ", "").ToUpper().Equals(b.Replace(" ", "").ToUpper());
        }
    }
}
