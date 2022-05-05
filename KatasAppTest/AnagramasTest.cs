using NUnit.Framework;
using KatasApp.Services;

namespace KatasTest.AnagramasTest
{
    public class AnagramasTest
    {
        private Anagramas anagramas;
        [SetUp]
        public void Setup()
        {
            anagramas = new Anagramas();
        }
    }
}
