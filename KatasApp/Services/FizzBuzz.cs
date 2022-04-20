namespace KatasApp.Services
{
    public static class FizzBuzz
    {
        public static string ProcessFizzBuzz(int number)
        {
            string result = (number % 3 == 0 || number % 5 == 0) ? string.Empty : number.ToString();

            if (number % 3 == 0)
                result += "Fizz";
            if (number % 5 == 0)
                result += "Buzz";
            
            return result;
        }
    }
}
