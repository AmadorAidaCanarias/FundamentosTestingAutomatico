using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatasApp.Services;
using NUnit.Framework;

namespace KatasTest
{
    public class FactorialClass
    {
        private FactorialService factorialService;

        [SetUp]
        public void Setup()
        {
            this.factorialService = new FactorialService();
        }

        [Test]
        public void should_return_1_when_factorial_is_0()
        {
            var result = this.factorialService.Factorial(0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void should_return_1_when_factorial_is_1()
        {
            var result = this.factorialService.Factorial(1);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void should_return_2_when_factorial_is_2()
        {
            var result = this.factorialService.Factorial(2);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void should_return_negative_exception_when_factorial_is_negative()
        {
            try
            {
                var result = this.factorialService.Factorial(-1);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<Exception>(ex);
            }
        }

        [Test]
        public void should_return_6_when_factorial_is_3()
        {
            var result = this.factorialService.Factorial(3);
            Assert.AreEqual(6, result);
        }
    }
}
