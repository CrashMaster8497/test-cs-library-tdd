using FluentValidation;

namespace CustomerLibrary
{
    public class CustomerValidator : AbstractValidator<Customer>
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

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName)
                .MaximumLength(FirstNameMaxLength).WithMessage(LongFirstName);
            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage(EmptyLastName)
                .MaximumLength(LastNameMaxLength).WithMessage(LongLastName);
            RuleFor(customer => customer.AddressList)
                .NotEmpty().WithMessage(EmptyAddressList);
            RuleFor(customer => customer.PhoneNumber)
                .Matches(PhoneNumberRegex).WithMessage(WrongPhoneNumber);
            RuleFor(customer => customer.Email)
                .Matches(EmailRegex).WithMessage(WrongEmail);
            RuleFor(customer => customer.Notes)
                .NotEmpty().WithMessage(EmptyNotes);
        }
    }
}
