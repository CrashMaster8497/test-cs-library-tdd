namespace CustomerLibrary.Tests
{
    public class CustomerValidatorTest
    {
        [Fact]
        public void ShouldReturnFirstNameTooLong()
        {
            var customer = new Customer(new string('a', 51), "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("First Name too long", actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("first")]
        public void ShouldNotReturnWrongFirstName(string firstName)
        {
            var customer = new Customer(firstName, "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("First Name too long", actual);
        }

        [Fact]
        public void ShouldReturnLastNameRequired()
        {
            var customer = new Customer("first", "", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Last Name required", actual);
        }

        [Fact]
        public void ShouldReturnLastNameTooLong()
        {
            var customer = new Customer("first", new string('a', 51), new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Last Name too long", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongLastName()
        {
            var customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Last Name required", actual);
            Assert.DoesNotContain("Last Name too long", actual);
        }

        [Fact]
        public void ShouldReturnAddressRequired()
        {
            var customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("At least one Address required", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongAddress()
        {
            var address = new Address("line", "line2", AddressType.Shipping, "city", "postal", "state", "United States");
            var customer = new Customer("first", "last", new List<Address> { address }, "phone", "email", new List<string>(), 0.0m);

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
            var customer = new Customer("first", "last", new List<Address>(), phoneNumber, "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Incorrect Phone Number format", actual);
        }

        [Theory]
        [InlineData("+12112111111")]
        [InlineData("12112111111")]
        [InlineData("2112111111")]
        [InlineData("+12342567890")]
        public void ShouldNotReturnWrongPhoneNumber(string phoneNumber)
        {
            var customer = new Customer("first", "last", new List<Address>(), phoneNumber, "email", new List<string>(), 0.0m);

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
            var customer = new Customer("first", "last", new List<Address>(), "phone", email, new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("Incorrect Email format", actual);
        }

        [Theory]
        [InlineData("a0_.+-@b0-.c0.-")]
        public void ShouldNotReturnWrongEmail(string email)
        {
            var customer = new Customer("first", "last", new List<Address>(), "phone", email, new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("Incorrect Email format", actual);
        }

        [Fact]
        public void ShouldReturnNoteRequired()
        {
            var customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.Contains("At least one Note required", actual);
        }

        [Fact]
        public void ShouldNotReturnWrongNote()
        {
            var customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string> { "note" }, 0.0m);

            var actual = CustomerValidator.Validate(customer);

            Assert.DoesNotContain("At least one Note required", actual);
        }
    }
}
