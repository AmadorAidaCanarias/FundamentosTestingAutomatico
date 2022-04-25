using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatasApp.Services;
using FluentAssertions;

namespace KatasTest.StringCalculatorTest
{
    public class StringCalculatorTestShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void return_0_when_pass_empty_string()
        {
            int resultStringCalculator = StringCalculator.Add("");

            resultStringCalculator.Should().Be(0, "When Pass Empty String Then Return 0.");
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        public void return_number_representation_from_string(int expected, string value)
        {
            int resultStringCalculator = StringCalculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [Test]
        public void return_1_when_pass_1_string()
        {
            int resultStringCalculator = StringCalculator.Add("1");

            resultStringCalculator.Should().Be(1, "when Pass 1 Then Return 1.");
        }

        [Test]
        public void return_2_when_pass_2_string()
        {
            int resultStringCalculator = StringCalculator.Add("2");

            resultStringCalculator.Should().Be(2, "when Pass 2 Then Return 2.");
        }

        [Test]
        public void return_3_when_pass_3_string()
        {
            int resultStringCalculator = StringCalculator.Add("3");

            resultStringCalculator.Should().Be(3, "when Pass 3 Then Return 3.");
        }
    }
}
