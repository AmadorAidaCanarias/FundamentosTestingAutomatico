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

        [Test]
        public void return_1_when_pass_1_string()
        {
            int resultStringCalculator = StringCalculator.Add("1");

            resultStringCalculator.Should().Be(1, "when Pass 1 Then Return 1.");
        }
    }
}
