namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            int.TryParse(numbers, out int result);

            if (numbers.Contains(","))
            {
                int.TryParse(numbers.Split(",").First(), out int firstNumber);

                result = firstNumber + Add(String.Join(",", numbers.Split(",").TakeLast(numbers.Split(",").Length - 1)));
            }

            return result;
        }
    }
}
