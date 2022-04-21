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

        [Test]
        public void WhenSendYearDivisibleBy400IsLeapYear()
        {
            Assert.AreEqual(true, LeapYear.LeapYearProcess(2400), "When pass 2400 Is Leap Year");
        }
    }
}
