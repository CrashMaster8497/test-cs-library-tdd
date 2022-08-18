namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTest
    {
        private static IEnumerable<object[]> GenerateEmptyAddressList()
        {
            yield return new object[] { new List<Address>() };
        }

        [Fact]
        public void ShouldReturnFirstNameTooLong()
        {
            var customer = new Customer { FirstName = new string('a', 51) };

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("First Name too long", actual);
        }

        [Theory]
        [InlineData("first")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotReturnWrongFirstName(string firstName)
        {
            var customer = new Customer { FirstName = firstName };

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("First Name too long", actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnLastNameRequired(string lastName)
        {
            var customer = new Customer { LastName = lastName };

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Last Name required", actual);
        }

        [Fact]
        public void ShouldReturnLastNameTooLong()
        {
            var customer = new Customer { LastName = new string('a', 51) };

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Last Name too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongLastName()
        {
            var customer = new Customer { LastName = "last" };

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Last Name required", actual);
            Assert.DoesNotContain("Last Name too long", actual);
        }

        [Theory]
        [InlineData(null)]
        [MemberData(nameof(GenerateEmptyAddressList))]
        public void ShouldReturnAddressRequired(List<Address> addressList)
        {
            var customer = new Customer { AddressList = addressList };

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("At least one Address required", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongAddress()
        {
            var customer = new Customer { AddressList = new List<Address> { new Address() } };

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("At least one Address required", actual);
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

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Incorrect Phone Number format", actual);
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

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Incorrect Phone Number format", actual);
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

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Incorrect Email format", actual);
        }

        [Theory]
        [InlineData("a@b.c")]
        [InlineData("a0_.+-@b0-.c0.-")]
        [InlineData(null)]
        public void ShouldNotReturnWrongEmail(string email)
        {
            var customer = new Customer { Email = email };

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Incorrect Email format", actual);
        }

        [Fact]
        public void ShouldReturnNoteRequired()
        {
            var customer = new Customer { Notes = new List<string>() };

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("At least one Note required", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongNote()
        {
            var customer = new Customer { Notes = new List<string> { string.Empty } };

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("At least one Note required", actual);
        }
    }
}
