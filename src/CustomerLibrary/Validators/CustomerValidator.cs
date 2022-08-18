using System.Text.RegularExpressions;

namespace CustomerLibrary
{
    public class CustomerValidator
    {
        const string LONG_FIRST_NAME = "First Name too long";
        const string EMPTY_LAST_NAME = "Last Name required";
        const string LONG_LAST_NAME = "Last Name too long";
        const string EMPTY_ADDRESS_LIST = "At least one Address required";
        const string WRONG_PHONE_NUMBER = "Incorrect Phone Number format";
        const string WRONG_EMAIL = "Incorrect Email format";
        const string EMPTY_NOTES = "At least one Note required";

        public static List<string> Validate(Customer customer)
        {
            var errorList = new List<string>();

            if (customer.FirstName.Length > 50)
            {
                errorList.Add(LONG_FIRST_NAME);
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                errorList.Add(EMPTY_LAST_NAME);
            }
            if (customer.LastName.Length > 50)
            {
                errorList.Add(LONG_LAST_NAME);
            }
            if (customer.AddressList.Count == 0)
            {
                errorList.Add(EMPTY_ADDRESS_LIST);
            }
            if (!Regex.IsMatch(customer.PhoneNumber, "^(\\+1|1)?([2-9]\\d\\d[2-9]\\d{6})$"))
            {
                errorList.Add(WRONG_PHONE_NUMBER);
            }
            if (!Regex.IsMatch(customer.Email, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$"))
            {
                errorList.Add(WRONG_EMAIL);
            }
            if (customer.Notes.Count == 0)
            {
                errorList.Add(EMPTY_NOTES);
            }

            return errorList;
        }
    }
}
