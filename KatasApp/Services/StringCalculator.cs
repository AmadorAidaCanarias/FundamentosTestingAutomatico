﻿using System.Text.RegularExpressions;

namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            char delimiter = ',';
            if (numbers.Contains("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);

                string numbersprocess = numbers;
                if (numbersprocess.Contains($"{delimiter}-"))
                {
                    var matchNegatives = Regex.Matches(numbersprocess
                        .Replace($"{delimiter}-", "@")
                        .Replace(delimiter, ',')
                        .Replace("@", ",-")
                        , @"\-\d*");
                    if (matchNegatives.Count > 0)
                    {
                        throw new InvalidOperationException($"Negatives not alowed: " +
                            $"{string.Join(",", matchNegatives.Select(row => row.Value).ToArray())}"
                           );
                    }
                }
            }

            numbers = numbers.Replace("\n", delimiter.ToString());

            int.TryParse(numbers, out int result);

            if (numbers.Contains(delimiter))
            {
                int.TryParse(numbers.Split(delimiter).First(), out int firstNumber);

                result = (firstNumber > 1000 ? 0 : firstNumber) + Add("//" + delimiter.ToString() + "\n" + String.Join(delimiter, numbers.Split(delimiter).TakeLast(numbers.Split(delimiter).Length - 1)));
            }

            return result > 1000 ? 0 : result;
        }
    }
}
