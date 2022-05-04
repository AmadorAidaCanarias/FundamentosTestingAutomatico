using System.Linq;
using System.Text.RegularExpressions;

namespace KatasApp.Services
{
    public class StringCalculator : DetectNegatives
    {
        private readonly IExtractDelimiters extractDelimiters;
        private readonly IDetectNegatives detectNegatives;

        public StringCalculator(IExtractDelimiters extractDelimiters, IDetectNegatives detectNegatives)
        {
            this.extractDelimiters = extractDelimiters;
            this.detectNegatives = detectNegatives;
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

            detectNegatives.Detect(numbers, arrayDelimiter);

            numbers = ReplaceDelimiters(numbers, arrayDelimiter);
            return numbers;
        }

        private string ReplaceDelimiters(string numbers, string[] delimiter)
        {
            delimiter.ToList().ForEach(x => numbers = numbers.Replace(x, ","));
            numbers = numbers.Replace("\n", ",");
            return numbers;
        }
    }
}
