

namespace Validation
{
    public class MaximumProductValidation
    {
        public void ValidNumeric(string inputNumber)
        {
            try
            {
                if (!IsValidNumericInput(inputNumber))
                {
                    throw new Exception("Please Enter only numeric values");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public bool IsValidNumericInput(string input)
        {   
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {

        }
    }
}