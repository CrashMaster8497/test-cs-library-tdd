using FluentValidation;

namespace CustomerLibrary
{
    public class AddressValidator : AbstractValidator<Address>
    {
        const int AddressLineMaxLength = 100;
        const int AddressLine2MaxLength = 100;
        const int CityMaxLength = 50;
        const int PostalCodeMaxLength = 6;
        const int StateMaxLength = 20;
        const string EmptyAddressLine = "Address Line required";
        const string LongAddressLine = "Address Line too long";
        const string LongAddressLine2 = "Address Line 2 too long";
        const string WrongType = "Address Type required";
        const string EmptyCity = "City required";
        const string LongCity = "City too long";
        const string EmptyPostalCode = "Postal Code required";
        const string LongPostalCode = "Postal Code too long";
        const string EmptyState = "State required";
        const string LongState = "State too long";
        const string WrongCountry = "Country wrong or unavailable";
        static readonly string[] AvailableCountries =
        {
            "United States",
            "Canada"
        };

        public AddressValidator()
        {
            RuleFor(address => address.AddressLine)
                .NotEmpty().WithMessage(EmptyAddressLine)
                .MaximumLength(AddressLineMaxLength).WithMessage(LongAddressLine);
            RuleFor(address => address.AddressLine2)
                .MaximumLength(AddressLine2MaxLength).WithMessage(LongAddressLine2);
            RuleFor(address => address.Type)
                .IsInEnum().Must(type => type != AddressType.Unknown).WithMessage(WrongType);
            RuleFor(address => address.City)
                .NotEmpty().WithMessage(EmptyCity)
                .MaximumLength(CityMaxLength).WithMessage(LongCity);
            RuleFor(address => address.PostalCode)
                .NotEmpty().WithMessage(EmptyPostalCode)
                .MaximumLength(PostalCodeMaxLength).WithMessage(LongPostalCode);
            RuleFor(address => address.State)
                .NotEmpty().WithMessage(EmptyState)
                .MaximumLength(StateMaxLength).WithMessage(LongState);
            RuleFor(address => address.Country)
                .Must(country => AvailableCountries.Contains(country, StringComparer.OrdinalIgnoreCase)).WithMessage(WrongCountry);
        }
    }
}
