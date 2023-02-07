namespace TestInvoiceAPI.Models
{
    public class CustomerType
    {
        public int id { get; init; }
        public string description { get; init; }

        public CustomerType(int id, string description)
        {
            this.id = id;
            this.description = description;
        }
    }
}
