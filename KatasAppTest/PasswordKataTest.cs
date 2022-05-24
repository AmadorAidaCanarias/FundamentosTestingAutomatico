using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using KatasApp.Services;
using NUnit.Framework;

namespace KatasTest.PasswordKataTest {
    public class PasswordKataTest {

        private PasswordValidator passwordValidator;

        [SetUp]
        public void Setup()
        {
            passwordValidator = new PasswordValidator();
        }


        [Test]
        [TestCase( "1234567", false, "La contraseña debe tener al menos 8 caracteres.")]
        [TestCase("234567", false, "La contraseña debe tener al menos 8 caracteres.")]
        [TestCase("abcedef", false, "La contraseña debe tener al menos 8 caracteres.")]
        public void when_pass_password_with_length_minor_8_should_return_false_validation_and_message(string password, bool expectedValid, string expectedMessage)
        {
            PasswordResultValidator resultValidator = passwordValidator.Validate(password);

            resultValidator.IsValid.Should().Be(expectedValid);
            resultValidator.Messages.Count.Should().BeGreaterThanOrEqualTo(1);
            resultValidator.Messages
                .Any(x => x.Equals(expectedMessage))
                .Should()
                .BeTrue();
        }

    }
}
