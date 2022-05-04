using System.Text.RegularExpressions;

namespace KatasApp.Services
{
    public interface IDetectNegatives
    {
        void Detect(string numbers, string[] delimiters);
    }

    public class DetectNegatives: IDetectNegatives
    {

        public void Detect(string numbers, string[] delimiter)
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