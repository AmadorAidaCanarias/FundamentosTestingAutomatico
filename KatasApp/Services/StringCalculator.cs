namespace KatasApp.Services
{
    public class StringCalculator : DetectNegatives
    {
        private ICleanInputString cleanInputString;

        public StringCalculator(ICleanInputString cleanInputString)
        {
            this.cleanInputString = cleanInputString;
        }

        public int Add(string numbers)
        {
            int number, result = 0;
            numbers = cleanInputString.SanitizeString(numbers);
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
    }
}
