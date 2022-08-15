namespace CustomerLibrary.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldHaveFirstName()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.Equal("first", customer.FirstName);
        }

        [Fact]
        public void ShouldHaveLastName()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.Equal("last", customer.LastName);
        }

        [Fact]
        public void ShouldHaveAddressList()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.NotNull(customer.AddressList);
            Assert.IsType<List<Address>>(customer.AddressList);
        }

        [Fact]
        public void ShouldHavePhoneNumber()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.Equal("phone", customer.PhoneNumber);
        }

        [Fact]
        public void ShouldHaveEmail()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.Equal("email", customer.Email);
        }

        [Fact]
        public void ShouldHaveNotes()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.NotNull(customer.Notes);
            Assert.IsType<List<string>>(customer.Notes);
        }

        [Fact]
        public void ShouldHaveTotalPurchasesAmount()
        {
            Customer customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 0.0m);

            Assert.Equal(0.0m, customer.TotalPurchasesAmount);
        }
    }
}
