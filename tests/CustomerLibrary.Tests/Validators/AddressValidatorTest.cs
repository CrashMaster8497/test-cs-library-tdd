namespace CustomerLibrary.Tests
{
    [Collection("CustomerLibraryTests")]
    public class AddressValidatorTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnAddressLineRequired(string addressLine)
        {
            var address = new Address { AddressLine = addressLine };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address Line required", actual);
        }

        [Fact]
        public void ShouldReturnAddressLineTooLong()
        {
            var address = new Address { AddressLine = new string('a', 101) };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address Line too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongAddressLine()
        {
            var address = new Address { AddressLine = "address line" };

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Address Line required", actual);
            Assert.DoesNotContain("Address Line too long", actual);
        }

        [Fact]
        public void ShouldReturnAddressLine2TooLong()
        {
            var address = new Address { AddressLine2 = new string('a', 101) };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address Line 2 too long", actual);
        }

        [Theory]
        [InlineData("correct address line 2")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotReturnWrongAddressLine2(string addressLine2)
        {
            var address = new Address { AddressLine2 = addressLine2 };

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Address Line 2 too long", actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnCityRequired(string city)
        {
            var address = new Address { City = city };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("City required", actual);
        }

        [Fact]
        public void ShouldReturnCityTooLong()
        {
            var address = new Address { City = new string('a', 51) };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("City too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongCity()
        {
            var address = new Address { City = "city" };

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("City required", actual);
            Assert.DoesNotContain("City too long", actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnPostalCodeRequired(string postalCode)
        {
            var address = new Address { PostalCode = postalCode };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Postal Code required", actual);
        }

        [Fact]
        public void ShouldReturnPostalCodeTooLong()
        {
            var address = new Address { PostalCode = new string('1', 7) };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Postal Code too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongPostalCode()
        {
            var address = new Address { PostalCode = "123456" };

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Postal Code required", actual);
            Assert.DoesNotContain("Postal Code too long", actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnStateRequired(string state)
        {
            var address = new Address { State = state };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("State required", actual);
        }

        [Fact]
        public void ShouldReturnStateTooLong()
        {
            var address = new Address { State = new string('a', 21) };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("State too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongState()
        {
            var address = new Address { State = "state" };

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("State required", actual);
            Assert.DoesNotContain("State too long", actual);
        }

        [Fact]
        public void ShouldReturnWrongCountry()
        {
            var address = new Address { Country = "country" };

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Country wrong or unavailable", actual);
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

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Country wrong or unavailable", actual);
        }
    }
}
