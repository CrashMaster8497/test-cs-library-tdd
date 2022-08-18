using FluentValidation.TestHelper;

namespace CustomerLibrary.Tests
{
    [Collection("CustomerLibraryTests")]
    public class AddressValidatorTest
    {
        private readonly AddressValidator validator = new AddressValidator();

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnAddressLineRequired(string addressLine)
        {
            var address = new Address { AddressLine = addressLine };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine).WithErrorMessage("Address Line required");
        }

        [Fact]
        public void ShouldReturnAddressLineTooLong()
        {
            var address = new Address { AddressLine = new string('a', 101) };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine).WithErrorMessage("Address Line too long");
        }

        [Fact]
        public void ShouldNotReturnWrongAddressLine()
        {
            var address = new Address { AddressLine = "address line" };

            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.AddressLine);
        }

        [Fact]
        public void ShouldReturnAddressLine2TooLong()
        {
            var address = new Address { AddressLine2 = new string('a', 101) };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.AddressLine2).WithErrorMessage("Address Line 2 too long");
        }

        [Theory]
        [InlineData("correct address line 2")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotReturnWrongAddressLine2(string addressLine2)
        {
            var address = new Address { AddressLine2 = addressLine2 };

            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.AddressLine2);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnCityRequired(string city)
        {
            var address = new Address { City = city };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.City).WithErrorMessage("City required");
        }

        [Fact]
        public void ShouldReturnCityTooLong()
        {
            var address = new Address { City = new string('a', 51) };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.City).WithErrorMessage("City too long");
        }

        [Fact]
        public void ShouldNotReturnWrongCity()
        {
            var address = new Address { City = "city" };

            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.City);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnPostalCodeRequired(string postalCode)
        {
            var address = new Address { PostalCode = postalCode };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.PostalCode).WithErrorMessage("Postal Code required");
        }

        [Fact]
        public void ShouldReturnPostalCodeTooLong()
        {
            var address = new Address { PostalCode = new string('1', 7) };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.PostalCode).WithErrorMessage("Postal Code too long");
        }

        [Fact]
        public void ShouldNotReturnWrongPostalCode()
        {
            var address = new Address { PostalCode = "123456" };

            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.PostalCode);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnStateRequired(string state)
        {
            var address = new Address { State = state };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.State).WithErrorMessage("State required");
        }

        [Fact]
        public void ShouldReturnStateTooLong()
        {
            var address = new Address { State = new string('a', 21) };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.State).WithErrorMessage("State too long");
        }

        [Fact]
        public void ShouldNotReturnWrongState()
        {
            var address = new Address { State = "state" };

            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.State);
        }

        [Fact]
        public void ShouldReturnWrongCountry()
        {
            var address = new Address { Country = "country" };

            var result = validator.TestValidate(address);

            result.ShouldHaveValidationErrorFor(address => address.Country).WithErrorMessage("Country wrong or unavailable");
        }

        [Theory]
        [InlineData("United States")]
        [InlineData("united states")]
        [InlineData("UNITED STATES")]
        [InlineData("Canada")]
        [InlineData("canada")]
        [InlineData("CANADA")]
        public void ShouldNotReturnWrongCountry(string country)
        {
            var address = new Address { Country = country };

            var result = validator.TestValidate(address);

            result.ShouldNotHaveValidationErrorFor(address => address.Country);
        }
    }
}
