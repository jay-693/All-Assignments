using Validation;

namespace assign1
{
    public class MaxProduct
    {
        public void GetMaxProduct()
        {
            Console.Write("Enter the Number:");
            string inputNumber = Console.ReadLine();

            // Validate input to ensure it contains only digits
            Validation.MaximumProductValidation mx = new Validation.MaximumProductValidation();
            mx.ValidNumeric(inputNumber);
            int startIndex = 0;
            int previousMaxValue = 0;

            while (startIndex + 4 <= inputNumber.Length)
            {
                string substr = inputNumber.Substring(startIndex, 4);

                int fourDigitNumber = int.Parse(substr);

                // Calculate the product of digits in the current four-digit number
                int currentMaxValue = 1;
                while (fourDigitNumber != 0)
                {
                    int lastDigitnumber = fourDigitNumber % 10;
                    currentMaxValue *= lastDigitnumber;
                    fourDigitNumber /= 10;
                }

                if (currentMaxValue > previousMaxValue)
                {
                    previousMaxValue = currentMaxValue;
                }

                startIndex++;
            }

            // Output the maximum product of digits found in any four-digit substring
            Console.Write("MaxFourDigitProduct:");
            Console.Write(previousMaxValue);
        }



        public static void Main(string[] args)
        {
            MaxProduct objProduct = new MaxProduct();

            // Call GetMaxProduct method to find and output the maximum product
            objProduct.GetMaxProduct();
        }
    }

}