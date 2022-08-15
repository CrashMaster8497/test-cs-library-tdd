namespace CustomerLibrary
{
    public enum AddressType
    {
        Shipping,
        Billing
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public AddressType Type { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(string addressLine, string addressLine2, AddressType type, string city, string postalCode, string state, string country)
        {
            AddressLine = addressLine;
            AddressLine2 = addressLine2;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }
    }
}
