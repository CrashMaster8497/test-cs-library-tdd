namespace CustomerLibrary.Tests
{
    [Collection("CustomerLibraryTests")]
    public class CustomerTest
    {
        [Fact]
        public void ShouldBeAbleToCreateDefaultCustomer()
        {
            var customer = new Customer();

            Assert.NotNull(customer);
            Assert.Equal(string.Empty, customer.FirstName);
            Assert.Equal(string.Empty, customer.LastName);
            Assert.Equal(new List<Address>(), customer.AddressList);
            Assert.Equal(string.Empty, customer.PhoneNumber);
            Assert.Equal(string.Empty, customer.Email);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Null(customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customer = new Customer
            {
                FirstName = "first",
                LastName = "last",
                AddressList = new List<Address>(),
                PhoneNumber = "phone",
                Email = "email",
                Notes = new List<string>(),
                TotalPurchasesAmount = 1m
            };

            Assert.NotNull(customer);
            Assert.Equal("first", customer.FirstName);
            Assert.Equal("last", customer.LastName);
            Assert.Equal(new List<Address>(), customer.AddressList);
            Assert.Equal("phone", customer.PhoneNumber);
            Assert.Equal("email", customer.Email);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Equal(1m, customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomerWithConstructor()
        {
            var customer = new Customer("first", "last", new List<Address>(), "phone", "email", new List<string>(), 1m);

            Assert.NotNull(customer);
            Assert.Equal("first", customer.FirstName);
            Assert.Equal("last", customer.LastName);
            Assert.Equal(new List<Address>(), customer.AddressList);
            Assert.Equal("phone", customer.PhoneNumber);
            Assert.Equal("email", customer.Email);
            Assert.Equal(new List<string>(), customer.Notes);
            Assert.Equal(1m, customer.TotalPurchasesAmount);
        }
    }
}
