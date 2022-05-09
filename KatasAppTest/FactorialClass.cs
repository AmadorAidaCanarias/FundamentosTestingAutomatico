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
    }
}
