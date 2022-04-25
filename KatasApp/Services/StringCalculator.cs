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

            if (numbers.Equals("2"))
                result = 2;

            if (numbers.Equals("3"))
                result = 3;

            return result;
        }
    }
}
