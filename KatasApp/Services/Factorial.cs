namespace KatasApp.Services
{
    public class FactorialService
    {
        public int Factorial(int numberToCalculateFactorial)
        {
            if (numberToCalculateFactorial < 0)
            {
                throw new Exception("No se permiten números negativos");
            }
            if (numberToCalculateFactorial == 0)
                return 1;
            return numberToCalculateFactorial * Factorial(numberToCalculateFactorial - 1);
        }
    }
}
