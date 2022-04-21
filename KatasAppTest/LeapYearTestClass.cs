using KatasApp.Services;
using NUnit.Framework;


namespace KatasTest.LeapYearTest
{
    public class LeapYearTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(true, 2400)]
        [TestCase(true, 2000)]
        public void WhenSendYearDivisibleBy400IsLeapYear(bool expected, int yearToProcess)
        {
            Assert.AreEqual(true, LeapYear.LeapYearProcess(yearToProcess), $"When pass { yearToProcess } Expected { expected }");
        }
    }
}
