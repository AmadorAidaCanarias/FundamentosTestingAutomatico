using System.Text.RegularExpressions;

namespace KatasApp.Services {
    public class PasswordValidator {
        private readonly List<Validation> validations;
        public PasswordValidator(List<Validation> validations) {
            this.validations = validations;
        }
        public PasswordResultValidator Validate(string password) {
            List<string> messages = new();
            validations.ForEach(validation => validation.Validate(password, ref messages));
            return new PasswordResultValidator() { IsValid = (messages.Count == 0), Messages = messages };
        }
    }
}
