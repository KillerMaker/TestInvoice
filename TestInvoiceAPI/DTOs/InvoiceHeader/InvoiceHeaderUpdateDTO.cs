namespace TestInvoiceAPI.DTOs.InvoiceHeader
{
    public class InvoiceHeaderUpdateDTO
    {
        public int? id { get; init; }
        public int? customerId { get; init; }
        public InvoiceHeaderUpdateDTO(int? id, int? customerId)
        {
            this.id = id;
            this.customerId = customerId;
        }
    }
}
