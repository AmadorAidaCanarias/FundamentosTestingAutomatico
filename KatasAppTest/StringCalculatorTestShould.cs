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

        [TestCase(2, "1,1")]
        [TestCase(5, "2,3")]
        [TestCase(7, "4,3")]
        public void return_add_number_representation_from_two_numbers_string(int expected, string value)
        {
            int resultStringCalculator = StringCalculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [TestCase(3, "1,1,1")]
        public void return_add_number_representation_from_three_numbers_string(int expected, string value)
        {
            int resultStringCalculator = StringCalculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

    }
}
