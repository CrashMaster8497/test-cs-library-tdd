namespace CustomerLibrary
{
    public class Customer : Person
    {
        public List<Address> AddressList { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Notes { get; set; }
        public decimal? TotalPurchasesAmount { get; set; }

        public Customer(string firstName, string lastName, List<Address> addressList, string phoneNumber, string email, List<string> notes, decimal? totalPurchasesAmount) : base(firstName, lastName)
        {
            AddressList = addressList;
            PhoneNumber = phoneNumber;
            Email = email;
            Notes = notes;
            TotalPurchasesAmount = totalPurchasesAmount;
        }
    }
}
