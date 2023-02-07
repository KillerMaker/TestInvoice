namespace TestInvoiceAPI.DTOs.InvoiceDetail
{
    public class InvoiceDetailUpdateDTO
    {
        public int? id { get; init; }
        public int? invoiceId { get; init; }
        public int quantity { get; init; }
        public decimal price { get; init; }

        public InvoiceDetailUpdateDTO(int? id, int? invoiceId, int quantity, decimal price)
        {
            this.id = id;
            this.invoiceId = invoiceId;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
