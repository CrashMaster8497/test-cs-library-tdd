namespace CustomerLibrary
{
    public class AddressValidator
    {
        const int AddressLineMaxLength = 100;
        const int AddressLine2MaxLength = 100;
        const int CityMaxLength = 50;
        const int PostalCodeMaxLength = 6;
        const int StateMaxLength = 20;
        const string EmptyAddressLine = "Address Line required";
        const string LongAddressLine = "Address Line too long";
        const string LongAddressLine2 = "Address Line 2 too long";
        const string EmptyCity = "City required";
        const string LongCity = "City too long";
        const string EmptyPostalCode = "Postal Code required";
        const string LongPostalCode = "Postal Code too long";
        const string EmptyState = "State required";
        const string LongState= "State too long";
        const string WrongCountry = "Country wrong or unavailable";
        static readonly string[] AvailableCountries =
        {
            "United States",
            "Canada"
        };

        public static List<string> Validate(Address address)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(address.AddressLine))
            {
                errorList.Add(EmptyAddressLine);
            }
            else if (address.AddressLine.Length > AddressLineMaxLength)
            {
                errorList.Add(LongAddressLine);
            }

            if (!string.IsNullOrEmpty(address.AddressLine2) && address.AddressLine2.Length > AddressLine2MaxLength)
            {
                errorList.Add(LongAddressLine2);
            }

            if (string.IsNullOrWhiteSpace(address.City))
            {
                errorList.Add(EmptyCity);
            }
            else if (address.City.Length > CityMaxLength)
            {
                errorList.Add(LongCity);
            }

            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {
                errorList.Add(EmptyPostalCode);
            }
            else if (address.PostalCode.Length > PostalCodeMaxLength)
            {
                errorList.Add(LongPostalCode);
            }

            if (string.IsNullOrWhiteSpace(address.State))
            {
                errorList.Add(EmptyState);
            }
            else if (address.State.Length > StateMaxLength)
            {
                errorList.Add(LongState);
            }

            if (!AvailableCountries.Contains(address.Country, StringComparer.OrdinalIgnoreCase))
            {
                errorList.Add(WrongCountry);
            }

            return errorList;
        }
    }
}
