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
        public void WhenSendYearDivisibleBy400IsLeapYear(bool expected, int yearToProcess)
        {
            Assert.AreEqual(expected, LeapYear.LeapYearProcess(yearToProcess), $"When pass { yearToProcess } Expected { expected }");
        }

        [TestCase(false, 2300)]
        [TestCase(false, 2100)]
        [TestCase(false, 1900)]
        public void WhenSendYearDivisibleBy100ButNotBy400NotIsLeapYear(bool expected, int yearToProcess)
        {
            Assert.AreEqual(expected, LeapYear.LeapYearProcess(yearToProcess), $"When pass { yearToProcess } Expected { expected }");
        }

        [TestCase(true, 2004)]
        [TestCase(true, 2024)]
        [TestCase(true, 2012)]
        public void WhenSendYearDivisibleBy4ButNotBy100IsLeapYear(bool expected, int yearToProcess)
        {
            Assert.AreEqual(expected, LeapYear.LeapYearProcess(yearToProcess), $"When pass { yearToProcess } Expected { expected }");
        }


    }
}
