namespace KatasApp.Services
{
    public class LeapYear
    {
        public static bool LeapYearProcess(int yearToProcess)
        {
            return yearToProcess % 4 == 0;
        }
    }
}
