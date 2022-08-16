namespace CustomerLibrary
{
    public class AddressValidator
    {
        const string EMPTY_ADDRESS_LINE = "Address Line required";
        const string LONG_ADDRESS_LINE = "Address Line too long";
        const string LONG_ADDRESS_LINE_2 = "Address Line 2 too long";
        const string EMPTY_CITY = "City required";
        const string LONG_CITY = "City too long";
        const string EMPTY_POSTAL_CODE = "Postal Code required";
        const string LONG_POSTAL_CODE = "Postal Code too long";
        const string EMPTY_STATE = "State required";
        const string LONG_STATE= "State too long";
        const string WRONG_COUNTRY = "Wrong Country";
        static readonly string[] CORRECT_COUNTRIES =
        {
            "United States",
            "Canada"
        };

        public static List<string> Validate(Address address)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(address.AddressLine))
            {
                errorList.Add(EMPTY_ADDRESS_LINE);
            }
            if (address.AddressLine.Length > 100)
            {
                errorList.Add(LONG_ADDRESS_LINE);
            }
            if (address.AddressLine2.Length > 100)
            {
                errorList.Add(LONG_ADDRESS_LINE_2);
            }
            if (string.IsNullOrWhiteSpace(address.City))
            {
                errorList.Add(EMPTY_CITY);
            }
            if (address.City.Length > 50)
            {
                errorList.Add(LONG_CITY);
            }
            if (string.IsNullOrWhiteSpace(address.PostalCode))
            {
                errorList.Add(EMPTY_POSTAL_CODE);
            }
            if (address.PostalCode.Length > 6)
            {
                errorList.Add(LONG_POSTAL_CODE);
            }
            if (string.IsNullOrWhiteSpace(address.State))
            {
                errorList.Add(EMPTY_STATE);
            }
            if (address.State.Length > 20)
            {
                errorList.Add(LONG_STATE);
            }
            if (!CORRECT_COUNTRIES.Contains(address.Country))
            {
                errorList.Add(WRONG_COUNTRY);
            }

            return errorList;
        }
    }
}
