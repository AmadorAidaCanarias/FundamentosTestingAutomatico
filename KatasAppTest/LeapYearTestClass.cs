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
        [TestCase(true, 2300)]
        [TestCase(true, 2100)]
        [TestCase(true, 1900)]
        [TestCase(true, 2004)]
        [TestCase(true, 2024)]
        [TestCase(true, 2012)]
        [TestCase(false, 2001)]
        [TestCase(false, 2021)]
        [TestCase(false, 2011)]
        public void WhenSendYearDivisibleBy4IsLeapYear(bool expected, int yearToProcess)
        {
            Assert.AreEqual(expected, LeapYear.LeapYearProcess(yearToProcess), $"When pass { yearToProcess } Expected { expected }");
        }

    }
}
