using System.Linq;
using System.Text.RegularExpressions;

namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            numbers = SanitizeNumbers(numbers);
            string delimiter = ",";

            int.TryParse(numbers, out int result);

            if (numbers.Contains(delimiter[0]))
            {
                int.TryParse(numbers.Split(delimiter).First(), out int firstNumber);
                string lastNumbers = String.Join(",", numbers.Split(delimiter).TakeLast(numbers.Split(delimiter).Length - 1));
                result = (firstNumber > 1000 ? 0 : firstNumber) + Add(lastNumbers);
            }

            return result > 1000 ? 0 : result;
        }

        private static string SanitizeNumbers(string numbers)
        {
            string[] arrayDelimiter = new string[] { "," };
            if (numbers.Contains("//"))
            {
                ExtractDelimiter(ref numbers, ref arrayDelimiter);
            }

            DetectNegatives(numbers, arrayDelimiter);

            numbers = ReplaceDelimiters(numbers, arrayDelimiter);
            return numbers;
        }

        private static string ReplaceDelimiters(string numbers, string[] delimiter)
        {
            delimiter.ToList().ForEach(x => numbers = numbers.Replace(x, ","));
            numbers = numbers.Replace("\n", ",");
            return numbers;
        }

        private static void DetectNegatives(string numbers, string[] delimiter)
        {
            string numbersprocess = numbers;
            bool withNegatives = false;
            delimiter.ToList().ForEach(x => withNegatives = withNegatives == false ? numbersprocess.Contains($"{x}-") : withNegatives);
            if (withNegatives)
            {
                delimiter.ToList().ForEach(x => numbersprocess = numbersprocess
                                                                    .Replace($"{x}-", "@")
                                                                    .Replace(x, ",")
                                                                    .Replace("@", ",-"));
                var matchNegatives = Regex.Matches(numbersprocess, @"\-\d*");
                if (matchNegatives.Count > 0)
                {
                    throw new InvalidOperationException($"Negatives not alowed: " +
                        $"{string.Join(",", matchNegatives.Select(row => row.Value).ToArray())}"
                       );
                }
            }
        }

        private static void ExtractDelimiter(ref string numbers, ref string[] delimiter)
        {
            if (numbers.Contains("[") && numbers.Contains("]"))
            {
                while (numbers.Contains("["))
                {
                    int indexBegin = numbers.IndexOf("[") + 1;
                    int indexEnd = numbers.IndexOf("]");
                    delimiter = delimiter.Concat(new string[] { numbers[indexBegin..indexEnd] }).ToArray();
                    numbers = numbers.Substring(indexEnd + 1);
                }
            }
            else
            {
                delimiter = delimiter.Concat(new string[] { numbers[2].ToString() }).ToArray();
                numbers = numbers.Substring(4);
            }
        }
    }
}
