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
        [TestCase(true, 1600)]
        [TestCase(false, 2300)]
        public void WhenSendYearDivisibleBy400IsLeapYear(bool expected, int yearToProcess)
        {
            Assert.AreEqual(expected, LeapYear.LeapYearProcess(yearToProcess), $"When pass { yearToProcess } Expected { expected }");
        }
    }
}
