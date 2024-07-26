

using System.Globalization;

namespace Validation
{
    public class FloatSumValidation
    {
        public void FloatValid(string input)
        {
            try
            {
                if (!IsValidFloatInput(input))
                {
                    throw new Exception("Invalid input. Please enter a valid floating-point number.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public bool IsValidFloatInput(string input)
        {
           
                if (float.TryParse(input, out float result))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        public static void Main(string[] args)
        {
            
        }
    }
}

