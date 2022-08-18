namespace CustomerLibrary
{
    public class Customer : Person
    {
        public List<Address> AddressList { get; set; } = new List<Address>();
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Notes { get; set; } = new List<string>();
        public decimal? TotalPurchasesAmount { get; set; }

        public Customer() { }
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
