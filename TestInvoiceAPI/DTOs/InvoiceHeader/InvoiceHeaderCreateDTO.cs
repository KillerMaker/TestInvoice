namespace TestInvoiceAPI.DTOs.InvoiceHeader
{
    public class InvoiceHeaderCreateDTO
    {
        public int? customerId { get; init; }

        public InvoiceHeaderCreateDTO(int? customerId)
        {
            this.customerId = customerId;
        }
    }
}
