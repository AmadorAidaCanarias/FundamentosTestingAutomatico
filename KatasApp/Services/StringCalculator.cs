namespace KatasApp.Services
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = -1;

            if (string.IsNullOrEmpty(numbers))
                result = 0;

            return result;
        }
    }
}
