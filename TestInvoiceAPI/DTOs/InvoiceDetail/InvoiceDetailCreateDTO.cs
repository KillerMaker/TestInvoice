namespace TestInvoiceAPI.DTOs.InvoiceDetail
{
    public class InvoiceDetailCreateDTO
    {
        public int quantity { get; init; }
        public decimal price { get; init; }

        public InvoiceDetailCreateDTO( int quantity, decimal price)
        {
            this.quantity = quantity;
            this.price = price;
        }
    }
}
