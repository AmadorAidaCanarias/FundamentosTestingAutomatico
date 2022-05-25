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
        public void when_send_password_with_length_minor_8_should_return_false_validation_and_message(string password, bool expectedValid, string expectedMessage)
        {
            PasswordResultValidator resultValidator = passwordValidator.Validate(password);

            resultValidator.IsValid.Should().Be(expectedValid);
            resultValidator.Messages.Count.Should().BeGreaterThanOrEqualTo(1);
            resultValidator.Messages
                .Any(x => x.Equals(expectedMessage))
                .Should()
                .BeTrue();
        }

        [Test]
        [TestCase("abca1efgh", false, "La contraseña debe tener al menos dos números.")]
        [TestCase("abcdefg1", false, "La contraseña debe tener al menos dos números.")]
        [TestCase("1abcdefg", false, "La contraseña debe tener al menos dos números.")]
        public void when_send_password_without_two_numbers_should_return_false_validation_and_message(string password, bool expectedValid, string expectedMessage) {
            PasswordResultValidator resultValidator = passwordValidator.Validate(password);

            resultValidator.IsValid.Should().Be(expectedValid);
            resultValidator.Messages.Count.Should().BeGreaterThanOrEqualTo(1);
            resultValidator.Messages
                .Any(x => x.Equals(expectedMessage))
                .Should()
                .BeTrue();
        }

        [Test]
        public void when_send_password_with_length_minor_8_and_without_two_numbers_return_false_with_two_messages() {
            PasswordResultValidator resultValidator = passwordValidator.Validate("asdf2");

            resultValidator.IsValid.Should().Be(false);
            resultValidator.Messages.Count.Should().Be(2);
            resultValidator.Messages
                .Any(x => x.Equals("La contraseña debe tener al menos dos números."))
                .Should()
                .BeTrue();
            resultValidator.Messages
                .Any(x => x.Equals("La contraseña debe tener al menos 8 caracteres."))
                .Should()
                .BeTrue();
        }
    }
}
