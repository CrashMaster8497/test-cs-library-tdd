namespace CustomerLibrary
{
    public enum AddressType
    {
        Unknown,
        Shipping,
        Billing
    }

    public class Address
    {
        public string AddressLine { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public AddressType Type { get; set; } = AddressType.Unknown;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public Address() { }
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
