using System.Text.RegularExpressions;

namespace CustomerLibrary
{
    public class CustomerValidator
    {
        const int FirstNameMaxLength = 50;
        const int LastNameMaxLength = 50;
        const string PhoneNumberRegex = "^(\\+1|1)?([2-9]\\d\\d[2-9]\\d{6})$";
        const string EmailRegex = "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$";
        const string LongFirstName = "First Name too long";
        const string EmptyLastName = "Last Name required";
        const string LongLastName = "Last Name too long";
        const string EmptyAddressList = "At least one Address required";
        const string WrongPhoneNumber = "Incorrect Phone Number format";
        const string WrongEmail = "Incorrect Email format";
        const string EmptyNotes = "At least one Note required";

        public static List<string> Validate(Customer customer)
        {
            var errorList = new List<string>();

            if (!string.IsNullOrEmpty(customer.FirstName) && customer.FirstName.Length > FirstNameMaxLength)
            {
                errorList.Add(LongFirstName);
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                errorList.Add(EmptyLastName);
            }
            else if (customer.LastName.Length > LastNameMaxLength)
            {
                errorList.Add(LongLastName);
            }

            if (customer.AddressList == null || !customer.AddressList.Any())
            {
                errorList.Add(EmptyAddressList);
            }

            if (!string.IsNullOrEmpty(customer.PhoneNumber) && !Regex.IsMatch(customer.PhoneNumber, PhoneNumberRegex))
            {
                errorList.Add(WrongPhoneNumber);
            }

            if (!string.IsNullOrEmpty(customer.Email) && !Regex.IsMatch(customer.Email, EmailRegex))
            {
                errorList.Add(WrongEmail);
            }

            if (!customer.Notes.Any())
            {
                errorList.Add(EmptyNotes);
            }

            return errorList;
        }
    }
}
