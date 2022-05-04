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
        private IExtractDelimiters extractDelimiters;
        private StringCalculator _calculator;
        [SetUp]
        public void Setup()
        {
            extractDelimiters = new ExtractDelimiters();
            _calculator = new StringCalculator(extractDelimiters);
        }

        [Test]
        public void return_0_when_pass_empty_string()
        {
            int resultStringCalculator = _calculator.Add("");

            resultStringCalculator.Should().Be(0, "When Pass Empty String Then Return 0.");
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        public void return_number_representation_from_string(int expected, string value)
        {
            int resultStringCalculator = _calculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [TestCase(2, "1,1")]
        [TestCase(5, "2,3")]
        [TestCase(7, "4,3")]
        public void return_add_number_representation_from_two_numbers_string(int expected, string value)
        {
            int resultStringCalculator = _calculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [TestCase(3, "1,1,1")]
        [TestCase(5, "1,1,1,2")]
        [TestCase(9, "1,1,1,2,4")]
        public void return_add_number_representation_from_n_numbers_string(int expected, string value)
        {
            int resultStringCalculator = _calculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [TestCase(3, "1\n1,1")]
        [TestCase(5, "1\n1\n1,2")]
        [TestCase(9, "1\n1\n1\n2,4")]
        public void return_add_number_representation_from_n_numbers_string_with_returnorcommaseparator(int expected, string value)
        {
            int resultStringCalculator = _calculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [TestCase(3, "//;\n1;1;1")]
        [TestCase(5, "//@\n1@1@1@2")]
        [TestCase(9, "//-\n1-1-1-2-4")]
        public void return_add_number_representation_from_n_numbers_string_with_newseparator(int expected, string value)
        {
            int resultStringCalculator = _calculator.Add(value);

            resultStringCalculator.Should().Be(expected, $"When Pass { expected } String Then Return { value }.");
        }

        [Test]
        public void return_exception_if_string_contains_negative_numbers()
        {
            try
            {
                var resultStringCalculator = _calculator.Add("//-\n1-2--3-4-5");
            }
            catch(InvalidOperationException ex)
            {
                ex.Should().BeOfType(typeof(InvalidOperationException), $" { ex } should be a Exception.");
                ex.Message.Should().Contain("-3", $"{ ex } should contain -3");
            }
        }

        [Test]
        public void numbers_greater_than_1000_not_count()
        {
            var resultStringCalculator = _calculator.Add("//-\n1-2-1001-4-5");
            resultStringCalculator.Should().Be(12, "Greater than 1000 not count.");
        }

        [Test]
        public void delimiter_with_any_character_return_add_number()
        {
            var resultStringCalculator = _calculator.Add("//[***]\n1***2***3");
            resultStringCalculator.Should().Be(6, "Any delimiter length.");
        }

        [Test]
        public void delimiter_with_any_character_return_add_number_two()
        {
            var resultStringCalculator = _calculator.Add("//[---]\n2---3---4");
            resultStringCalculator.Should().Be(9, "Any delimiter length 2.");
        }

        [Test]
        public void delimiter_with_any_character_return_add_number_with_negative()
        {
            try
            {
                var resultStringCalculator = _calculator.Add("//[---]\n2----3---4");
            }
            catch (InvalidOperationException ex)
            {
                ex.Should().BeOfType(typeof(InvalidOperationException), $" { ex } should be a Exception.");
                ex.Message.Should().Contain("-3", $"{ ex } should contain -3");
            }
        }

        [Test]
        public void valid_any_delimiter_number_and_length()
        {
            var resultStringCalculator = _calculator.Add("//[@][%][***]\n1@2%3***5");
            resultStringCalculator.Should().Be(11, "Any delimiter and any length's delimiter 2.");
        }
    }
}
