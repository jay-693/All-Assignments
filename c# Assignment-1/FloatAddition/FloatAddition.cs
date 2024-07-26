

using Validation;
using System.Globalization;
using System.Text;

class FloatSum
{
    // List to store binary representations of floating-point numbers
    private List<string> binaryStrings = new List<string>();

    public void ConvertFloatToBinaryString(string inputString)
    {
        string input = inputString;
        Validation.FloatSumValidation fv = new Validation.FloatSumValidation();
        fv.FloatValid(inputString);
        if (!float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float floatValue))
        {
            Console.WriteLine("Invalid input. Please enter a valid floating-point number.");
            return;
        }
        bool isNegative = floatValue < 0;
        if (isNegative)
        {
            // Convert negative float to positive for easier binary conversion
            floatValue = -floatValue;
        }
        // Extract integer part
        int integerPart = (int)floatValue;
        string binaryInteger = "";
        // Convert integer part to binary
        do
        {
            binaryInteger = (integerPart % 2) + binaryInteger;
            integerPart /= 2;
        } while (integerPart > 0);
        // Extract fractional part
        float fractionalPart = floatValue - (int)floatValue;
        string binaryFractional = "";
        const int maxFractionalBits = 10;
        int count = 0;

        while (fractionalPart > 0 && count < maxFractionalBits)
        {
            fractionalPart *= 2;
            binaryFractional += (int)fractionalPart;
            fractionalPart -= (int)fractionalPart;
            count++;
        }

        string binaryRepresentation = binaryInteger;
        // Combine integer and fractional parts
        if (!string.IsNullOrEmpty(binaryFractional))
        {
            binaryRepresentation += "." + binaryFractional;
        }

        if (isNegative)
        {
            binaryRepresentation = "-" + binaryRepresentation;
        }

        binaryStrings.Add(binaryRepresentation);
        /*        Console.WriteLine(binaryRepresentation); 
        */
    }

    public void ConvertBinaryStringsAndSum()
    {
        List<string> temp = new List<string>(2);
        foreach (string binaryString in binaryStrings)
        {
            temp.Add(binaryString);
        }

        string sumBinary = AddBinaryStrings(temp[0], temp[1]);
        /* Console.WriteLine(sumBinary); */
        // Convert sum back to float
        float floatValue = ConvertBinaryStringToFloat(sumBinary);
        Console.WriteLine("{0:F16}", floatValue);
    }

    private string AddBinaryStrings(string binaryString1, string binaryString2)
    {
        string[] parts1 = binaryString1.Split('.');
        string[] parts2 = binaryString2.Split('.');
        string intPart1 = parts1[0];
        string fracPart1 = parts1.Length > 1 ? parts1[1] : "";
        string intPart2 = parts2[0];
        string fracPart2 = parts2.Length > 1 ? parts2[1] : "";

        // Determine maximum length of integer parts
        int maxIntLength = Math.Max(intPart1.Length, intPart2.Length);
        // Determine maximum length of fractional parts
        int maxFracLength = Math.Max(fracPart1.Length, fracPart2.Length);

        // Pad integer parts with leading zeros
        intPart1 = intPart1.PadLeft(maxIntLength, '0');
        intPart2 = intPart2.PadLeft(maxIntLength, '0');

        // Pad fractional parts with trailing zeros
        fracPart1 = fracPart1.PadRight(maxFracLength, '0');
        fracPart2 = fracPart2.PadRight(maxFracLength, '0');

        StringBuilder intResult = new StringBuilder();
        StringBuilder fracResult = new StringBuilder();
        int carry = 0;

        for (int i = maxFracLength - 1; i >= 0; i--)
        {
            int bit1 = fracPart1[i] - '0';
            int bit2 = fracPart2[i] - '0';

            int sum = bit1 + bit2 + carry;

            fracResult.Insert(0, sum % 2);
            carry = sum / 2;
        }

        for (int i = maxIntLength - 1; i >= 0; i--)
        {
            int bit1 = intPart1[i] - '0';
            int bit2 = intPart2[i] - '0';

            int sum = bit1 + bit2 + carry;

            intResult.Insert(0, sum % 2);
            carry = sum / 2;
        }

        if (carry > 0)
        {
            intResult.Insert(0, carry);
        }

        string result = intResult.ToString();
        // Combine integer and fractional results
        if (fracResult.Length > 0)
        {
            result += "." + fracResult.ToString();
        }

        return result;
    }

    private float ConvertBinaryStringToFloat(string binaryString)
    {
        string[] parts = binaryString.Split('.');
        string intPart = parts[0];
        string fracPart = parts.Length > 1 ? parts[1] : "";
        // Convert binary integer part to decimal
        int intDecimal = Convert.ToInt32(intPart, 2);

        // Convert binary fractional part to decimal
        float fracDecimal = 0.0f;
        if (!string.IsNullOrEmpty(fracPart))
        {
            float fracValue = 0.0f;
            float fracFactor = 1.0f / 2.0f;
            for (int i = 0; i < fracPart.Length; i++)
            {
                if (fracPart[i] == '1')
                {
                    fracValue += fracFactor;
                }
                fracFactor /= 2.0f;
            }
            fracDecimal = fracValue;
        }

        float floatValue = intDecimal + fracDecimal;

        return floatValue;
    }

    public static void Main(string[] args)
    {
        FloatSum binaryConverterobjSum = new FloatSum();
        Console.Write("Enter The Float Value1:");
        binaryConverterobjSum.ConvertFloatToBinaryString(Console.ReadLine());
        Console.Write("Enter The Float Value2:");
        binaryConverterobjSum.ConvertFloatToBinaryString(Console.ReadLine());
        Console.Write("The float sum:");
        binaryConverterobjSum.ConvertBinaryStringsAndSum();
    }
}
