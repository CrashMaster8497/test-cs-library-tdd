namespace CustomerLibrary.Tests
{
    public class AddressTest
    {
        /*
        [Fact]
        public void ShouldHaveShipping()
        {
            var addressType = AddressType.Shipping;

            Assert.NotNull(addressType);
        }

        [Fact]
        public void ShouldHaveBilling()
        {
            var addressType = AddressType.Billing;

            Assert.NotNull(addressType);
        }
        */

        [Fact]
        public void ShouldHaveAddressLine()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.AddressLine.Equals("address1");
        }

        [Fact]
        public void ShouldHaveAddressLine2()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.AddressLine2.Equals(null);
        }

        [Fact]
        public void ShouldHaveAddressType()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.Type.Equals(AddressType.Shipping);
        }

        [Fact]
        public void ShouldHaveCity()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.City.Equals("city");
        }

        [Fact]
        public void ShouldHavePostalCode()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.PostalCode.Equals("postalcode");
        }

        [Fact]
        public void ShouldHaveState()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.State.Equals("state");
        }

        [Fact]
        public void ShouldHaveCountry()
        {
            var address = new Address("address1", "", AddressType.Shipping, "city", "postalcode", "state", "country");

            address.Country.Equals("country");
        }
    }
}
