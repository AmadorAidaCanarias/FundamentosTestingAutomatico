using System.Linq;
using System.Text.RegularExpressions;

namespace KatasApp.Services
{
    public class StringCalculator
    {
        private readonly IExtractDelimiters extractDelimiters;

        public StringCalculator(IExtractDelimiters extractDelimiters)
        {
            this.extractDelimiters = extractDelimiters;
        }

        public int Add(string numbers)
        {
            int number, result = 0;
            numbers = SanitizeNumbers(numbers);
            string delimiter = ",";

            int.TryParse(numbers, out result);
            if (numbers.Contains(delimiter))
            {
                numbers.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(
                        x => 
                            {
                                int.TryParse(x, out number);
                                result += (number > 1000 ? 0 : number);
                            }
                    );
            }

            return result;
        }

        private string SanitizeNumbers(string numbers)
        {
            string[] arrayDelimiter = new string[] { "," };
            if (numbers.Contains("//"))
            {
                extractDelimiters.ExtractDelimiter(ref numbers, ref arrayDelimiter);
            }

            DetectNegatives(numbers, arrayDelimiter);

            numbers = ReplaceDelimiters(numbers, arrayDelimiter);
            return numbers;
        }

        private string ReplaceDelimiters(string numbers, string[] delimiter)
        {
            delimiter.ToList().ForEach(x => numbers = numbers.Replace(x, ","));
            numbers = numbers.Replace("\n", ",");
            return numbers;
        }

        private void DetectNegatives(string numbers, string[] delimiter)
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
    }
}
