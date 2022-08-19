using FluentValidation.TestHelper;

namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTest
    {
        private readonly CustomerValidator validator = new CustomerValidator();

        [Fact]
        public void ShouldReturnFirstNameTooLong()
        {
            var customer = new Customer { FirstName = new string('a', 51) };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.FirstName).WithErrorMessage("First Name too long");
        }

        [Theory]
        [InlineData("first")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotReturnWrongFirstName(string firstName)
        {
            var customer = new Customer { FirstName = firstName };

            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(customer => customer.FirstName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnLastNameRequired(string lastName)
        {
            var customer = new Customer { LastName = lastName };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.LastName).WithErrorMessage("Last Name required");
        }

        [Fact]
        public void ShouldReturnLastNameTooLong()
        {
            var customer = new Customer { LastName = new string('a', 51) };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.LastName).WithErrorMessage("Last Name too long");
        }

        [Fact]
        public void ShouldNotReturnWrongLastName()
        {
            var customer = new Customer { LastName = "last" };

            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(customer => customer.LastName);
        }

        [Theory]
        [InlineData(null)]
        [MemberData(nameof(GenerateEmptyAddressList))]
        public void ShouldReturnAddressRequired(List<Address> addressList)
        {
            var customer = new Customer { AddressList = addressList };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.AddressList).WithErrorMessage("At least one Address required");
        }

        [Fact]
        public void ShouldNotReturnWrongAddress()
        {
            var customer = new Customer { AddressList = new List<Address> { new Address() } };

            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(customer => customer.AddressList);
        }

        [Theory]
        [InlineData("+11112111111")]
        [InlineData("+12111111111")]
        [InlineData("+1211211111")]
        [InlineData("+121121111111")]
        [InlineData("+1211211111a")]
        public void ShouldReturnWrongPhoneNumber(string phoneNumber)
        {
            var customer = new Customer { PhoneNumber = phoneNumber };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.PhoneNumber).WithErrorMessage("Incorrect Phone Number format");
        }

        [Theory]
        [InlineData("+12112111111")]
        [InlineData("12112111111")]
        [InlineData("2112111111")]
        [InlineData("+12342567890")]
        [InlineData(null)]
        public void ShouldNotReturnWrongPhoneNumber(string phoneNumber)
        {
            var customer = new Customer { PhoneNumber = phoneNumber };

            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(customer => customer.PhoneNumber);
        }

        [Theory]
        [InlineData("@b.c")]
        [InlineData("ab.c")]
        [InlineData("a@.c")]
        [InlineData("a@bc")]
        [InlineData("a@b.")]
        public void ShouldReturnWrongEmail(string email)
        {
            var customer = new Customer { Email = email };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.Email).WithErrorMessage("Incorrect Email format");
        }

        [Theory]
        [InlineData("a@b.c")]
        [InlineData("a0_.+-@b0-.c0.-")]
        [InlineData(null)]
        public void ShouldNotReturnWrongEmail(string email)
        {
            var customer = new Customer { Email = email };

            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(customer => customer.Email);
        }

        [Theory]
        [InlineData(null)]
        [MemberData(nameof(GenerateEmptyNotes))]
        public void ShouldReturnNoteRequired(List<string> notes)
        {
            var customer = new Customer { Notes = notes };

            var result = validator.TestValidate(customer);

            result.ShouldHaveValidationErrorFor(customer => customer.Notes).WithErrorMessage("At least one Note required");
        }

        [Fact]
        public void ShouldNotReturnWrongNote()
        {
            var customer = new Customer { Notes = new List<string> { string.Empty } };

            var result = validator.TestValidate(customer);

            result.ShouldNotHaveValidationErrorFor(customer => customer.Notes);
        }

        private static IEnumerable<object[]> GenerateEmptyAddressList()
        {
            yield return new object[] { new List<Address>() };
        }

        private static IEnumerable<object[]> GenerateEmptyNotes()
        {
            yield return new object[] { new List<string>() };
        }
    }
}
