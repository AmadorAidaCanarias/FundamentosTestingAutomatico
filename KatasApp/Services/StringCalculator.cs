namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            int result = -1;

            if (string.IsNullOrEmpty(numbers))
                result = 0;

            if (!numbers.Contains(","))
            {
                int.TryParse(numbers, out result);
            }

            if (numbers.Contains(","))
            {
                string firstNumber = numbers.Split(",")[0];
                string secondNumber = numbers.Split(",")[1];
                int convertFirstNumber;
                int convertSecondNumber;
                int.TryParse(firstNumber, out convertFirstNumber);
                int.TryParse(secondNumber, out convertSecondNumber);
                result = convertFirstNumber + convertSecondNumber;
            }

            return result;
        }
    }
}
