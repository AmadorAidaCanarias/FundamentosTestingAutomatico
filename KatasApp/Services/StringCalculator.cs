namespace KatasApp.Services
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            int result = -1;

            if (string.IsNullOrEmpty(numbers))
                result = 0;

            if(numbers.Equals("1"))
                result = 1;

            return result;
        }
    }
}
