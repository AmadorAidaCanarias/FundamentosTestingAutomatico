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
        public void when_pass_password_with_length_minor_8_should_return_false_validation_and_message()
        {
            PasswordResultValidator resultValidator = passwordValidator.Validate("1234567");

            resultValidator.IsValid.Should().BeFalse();
            resultValidator.Messages.Count.Should().BeGreaterThanOrEqualTo(1);
            resultValidator.Messages
                .Any(x => x.Equals("La contraseña debe tener al menos 8 caracteres."))
                .Should()
                .BeTrue();
        }

    }
}
