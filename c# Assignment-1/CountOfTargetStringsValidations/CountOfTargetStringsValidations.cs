
using System.Globalization;

namespace Validation
{

    public class Count
    {
        public void ValidMeth(string inputString, string targetString)
        {
            try
            {
                if (string.IsNullOrEmpty(inputString) || string.IsNullOrEmpty(targetString))
                {
                    throw new Exception("Enter the valid inputs");
                }

                if (IsValidStringInput(inputString) || IsValidStringInput(targetString))
                {
                    throw new Exception("Enter only characters");
                }
                if (inputString.Length < targetString.Length)
                {
                    throw new Exception("Enter the input string having the length Less than target string");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public bool IsValidStringInput(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }
        public static void Main(string[] args)
        { }
    }
}