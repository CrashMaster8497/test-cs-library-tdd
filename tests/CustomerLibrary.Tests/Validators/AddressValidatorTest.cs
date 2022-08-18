namespace CustomerLibrary.Tests
{
    public class AddressValidatorTest
    {
        [Fact]
        public void ShouldReturnAddressLineRequired()
        {
            var address = new Address("", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address Line required", actual);
        }

        [Fact]
        public void ShouldReturnAddressLineTooLong()
        {
            var address = new Address(new string('a', 101), "", AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address Line too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongAddressLine()
        {
            var address = new Address("correct address line", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Address Line required", actual);
            Assert.DoesNotContain("Address Line too long", actual);
        }

        [Fact]
        public void ShouldReturnAddressLine2TooLong()
        {
            var address = new Address("address", new string('a', 101), AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Address Line 2 too long", actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("correct address line 2")]
        public void ShouldNotReturnWrongAddressLine2(string addressLine2)
        {
            var address = new Address("address", addressLine2, AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Address Line 2 too long", actual);
        }

        [Fact]
        public void ShouldReturnCityRequired()
        {
            var address = new Address("address", "", AddressType.Shipping, "", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("City required", actual);
        }


        [Fact]
        public void ShouldReturnCityTooLong()
        {
            var address = new Address("address", "", AddressType.Shipping, new string('a', 51), "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("City too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongCity()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("City required", actual);
            Assert.DoesNotContain("City too long", actual);
        }

        [Fact]
        public void ShouldReturnPostalCodeRequired()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Postal Code required", actual);
        }

        [Fact]
        public void ShouldReturnPostalCodeTooLong()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", new string('a', 7), "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Postal Code too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongPostalCode()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postal", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Postal Code required", actual);
            Assert.DoesNotContain("Postal Code too long", actual);
        }

        [Fact]
        public void ShouldReturnStateRequired()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postalcode", "", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("State required", actual);
        }

        [Fact]
        public void ShouldReturnStateTooLong()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postalcode", new string('a', 21), "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("State too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongState()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("State required", actual);
            Assert.DoesNotContain("State too long", actual);
        }

        [Fact]
        public void ShouldReturnWrongCountry()
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            var actual = AddressValidator.Validate(address);

            Assert.Contains("Wrong Country", actual);
        }

        [Theory]
        [InlineData("United States")]
        [InlineData("Canada")]
        public void ShouldNotReturnWrongCountry(string country)
        {
            var address = new Address("address", "", AddressType.Shipping, "city", "postalcode", "state", country);

            var actual = AddressValidator.Validate(address);

            Assert.DoesNotContain("Wrong Country", actual);
        }
    }
}
