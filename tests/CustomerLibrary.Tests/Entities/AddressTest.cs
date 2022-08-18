namespace CustomerLibrary.Tests
{
    [Collection("CustomerLibraryTests")]
    public class AddressTest
    {
        [Fact]
        public void ShouldBeAbleToCreateDefaultAddress()
        {
            var address = new Address();

            Assert.NotNull(address);
            Assert.Equal(string.Empty, address.AddressLine);
            Assert.Equal(string.Empty, address.AddressLine2);
            Assert.Equal(AddressType.Unknown, address.Type);
            Assert.Equal(string.Empty, address.City);
            Assert.Equal(string.Empty, address.PostalCode);
            Assert.Equal(string.Empty, address.State);
            Assert.Equal(string.Empty, address.Country);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var address = new Address
            {
                AddressLine = "line",
                AddressLine2 = "line2",
                Type = AddressType.Shipping,
                City = "city",
                PostalCode = "postal",
                State = "state",
                Country = "country"
            };

            Assert.NotNull(address);
            Assert.Equal("line", address.AddressLine);
            Assert.Equal("line2", address.AddressLine2);
            Assert.Equal(AddressType.Shipping, address.Type);
            Assert.Equal("city", address.City);
            Assert.Equal("postal", address.PostalCode);
            Assert.Equal("state", address.State);
            Assert.Equal("country", address.Country);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddressWithConstructor()
        {
            var address = new Address("line", "line2", AddressType.Shipping, "city", "postal", "state", "country");

            Assert.NotNull(address);
            Assert.Equal("line", address.AddressLine);
            Assert.Equal("line2", address.AddressLine2);
            Assert.Equal(AddressType.Shipping, address.Type);
            Assert.Equal("city", address.City);
            Assert.Equal("postal", address.PostalCode);
            Assert.Equal("state", address.State);
            Assert.Equal("country", address.Country);
        }
    }
}
