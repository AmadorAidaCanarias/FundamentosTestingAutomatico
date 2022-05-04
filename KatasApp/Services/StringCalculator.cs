namespace KatasApp.Services
{
    public class StringCalculator : DetectNegatives
    {
        private readonly IProcessDelimiters processDelimiters;
        private readonly IDetectNegatives detectNegatives;

        public StringCalculator(IProcessDelimiters processDelimiters, IDetectNegatives detectNegatives)
        {
            this.processDelimiters = processDelimiters;
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
                processDelimiters.ExtractDelimiter(ref numbers, ref arrayDelimiter);
            }

            detectNegatives.Detect(numbers, arrayDelimiter);

            numbers = processDelimiters.ReplaceDelimiters(numbers, arrayDelimiter);
            return numbers;
        }
    }
}
