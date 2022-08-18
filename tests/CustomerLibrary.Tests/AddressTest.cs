namespace CustomerLibrary.Tests
{
    [Collection("CustomerLibraryTests")]
    public class AddressTest
    {
        [Fact]
        public void ShouldHaveAddressLine()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal("address1", address.AddressLine);
        }

        [Fact]
        public void ShouldHaveAddressLine2()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal("", address.AddressLine2);
        }

        [Fact]
        public void ShouldHaveAddressType()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal(AddressType.Unknown, address.Type);
        }

        [Fact]
        public void ShouldHaveCity()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal("city", address.City);
        }

        [Fact]
        public void ShouldHavePostalCode()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal("postalcode", address.PostalCode);
        }

        [Fact]
        public void ShouldHaveState()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal("state", address.State);
        }

        [Fact]
        public void ShouldHaveCountry()
        {
            var address = new Address("address1", "", AddressType.Unknown, "city", "postalcode", "state", "country");

            Assert.Equal("country", address.Country);
        }
    }
}
