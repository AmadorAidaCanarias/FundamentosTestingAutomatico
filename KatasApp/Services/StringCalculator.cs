using System.Linq;
using System.Text.RegularExpressions;

namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            string[] delimiter =new string[] { "," };
            if (numbers.Contains("//"))
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
                    delimiter = delimiter.Concat( new string[] { numbers[2].ToString() } ).ToArray();
                    numbers = numbers.Substring(4);
                }
                

                string numbersprocess = numbers;
                bool withNegatives = false;
                delimiter.ToList().ForEach(x => withNegatives = withNegatives == false ? numbersprocess.Contains($"{x}-") : withNegatives );
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

            delimiter.ToList().ForEach(x => numbers = numbers.Replace(x, ","));

            numbers = numbers.Replace("\n", ",");
            delimiter = new string[] { "," };

            int.TryParse(numbers, out int result);

            if (numbers.Contains(delimiter[0]))
            {
                int.TryParse(numbers.Split(delimiter[0]).First(), out int firstNumber);
                string lastNumbers = String.Join(",", numbers.Split(delimiter[0]).TakeLast(numbers.Split(delimiter[0]).Length - 1));
                result = (firstNumber > 1000 ? 0 : firstNumber) + Add(lastNumbers);
            }

            return result > 1000 ? 0 : result;
        }
    }
}
