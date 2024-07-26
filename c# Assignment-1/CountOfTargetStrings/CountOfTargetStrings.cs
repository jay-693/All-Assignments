
using Validation;
using System.Globalization;
using System.Text;
namespace Assign2
{
    class CountOfTargetString
    {
        public void Meth()
        {
            // List to store the starting indices of occurrences of targetString
            List<int> IndexesStoredArray = new List<int>();

            Console.Write("Enter The String=");
            string inputString = Console.ReadLine();
            Console.Write("Enter the targetString=");
            string targetString = Console.ReadLine();
           /* Validation.Count s = new Validation.Count();
            s.ValidMeth(inputString, targetString);*/
            int x = targetString.Length;
            int startIndex = 0;
            // Count of occurrences of targetString
            int Count = 0;

            while ((startIndex + x) <= inputString.Length)
            {
                // Extract substring of length x starting from startIndex
                string substring = inputString.Substring(startIndex, x);

                // Compare extracted substring with targetString
                if (substring == targetString)
                {
                    IndexesStoredArray.Add(startIndex);
                    startIndex += x;
                    Count++;
                }
                else
                {
                    // If not found, move startIndex to the next character
                    startIndex++;
                }
            }

            Console.WriteLine("No. of times occurred=" + Count);
            // Output index positions where targetString was found
            Console.Write("Index positions=");
            foreach (int index in IndexesStoredArray)
            {
                Console.Write(index + " ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            CountOfTargetString objFrequencyoftargetString = new CountOfTargetString();
            objFrequencyoftargetString.Meth();
        }
    }
}