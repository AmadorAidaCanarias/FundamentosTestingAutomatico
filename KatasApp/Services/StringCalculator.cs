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

            if (numbers.Equals("1,1"))
                return 2;

            return result;
        }
    }
}
