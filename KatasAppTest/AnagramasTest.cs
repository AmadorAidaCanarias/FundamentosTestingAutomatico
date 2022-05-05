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

        [Test]
        public void return_anagramas_from_casa_when_send_casa()
        {
            string[] result = anagramas.GetAnagramas("casa");
            Assert.GreaterOrEqual(1, result.Length);
        }
    }
}
