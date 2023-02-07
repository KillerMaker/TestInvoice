namespace TestInvoiceAPI.Models
{
    public class Customer
    {
        public int? id { get; init; }
        public string name { get; init; }
        public string address { get; init; }
        public bool status { get; init; }
        public int customerType { get; init; }

        public Customer(int? id, string name, string address, bool status, int customerType)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.status = status;
            this.customerType = customerType;
        }
    }
}
