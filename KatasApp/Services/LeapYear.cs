namespace KatasApp.Services
{
    public class LeapYear
    {
        public static bool LeapYearProcess(int yearToProcess)
        {
            bool isLeapYear = false;
            if (yearToProcess % 4 != 0)
                return false;
            if (yearToProcess % 4 == 0)
                isLeapYear = true;
            if ((yearToProcess % 100 == 0) && (yearToProcess % 400 != 0))
                isLeapYear = false;
            if (yearToProcess % 400 == 0)
                isLeapYear = true;
            return isLeapYear;
        }
    }
}
