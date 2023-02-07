namespace TestInvoiceAPI.DTOs.Customer
{
    public class CustomerCreateDTO
    {
        public string name { get; init; }
        public string address { get; init; }
        public bool status { get; init; }
        public int customerType { get; init; }

        public CustomerCreateDTO(string name, string address, bool status, int customerType)
        {
            this.name = name;
            this.address = address;
            this.status = status;
            this.customerType = customerType;
        }
    }
}
