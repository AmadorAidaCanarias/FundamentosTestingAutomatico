namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            int.TryParse(numbers, out int result);

            if (numbers.Contains(","))
            {
                string [] valuesFromNumbers = numbers.Split(",");

                int.TryParse(valuesFromNumbers[0], out int firstNumber);

                result = firstNumber + Add(String.Join(",", valuesFromNumbers.TakeLast(valuesFromNumbers.Length - 1)));
            }

            return result;
        }
    }
}
