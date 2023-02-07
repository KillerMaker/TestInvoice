namespace TestInvoiceAPI.DTOs.InvoiceDetail
{
    public class InvoiceDetailGetDTO
    {
        public int? id { get; init; }
        public int? invoiceId { get; init; }
        public int quantity { get; init; }
        public decimal price { get; init; }
        public decimal subTotal { get; init; }
        public decimal totalItbis { get; set; }
        public decimal total { get; init; }


        public InvoiceDetailGetDTO(int? id, int? invoiceId, int quantity, decimal price, decimal subTotal, decimal totalItbis, decimal total)
        {
            this.id = id;
            this.invoiceId = invoiceId;
            this.quantity = quantity;
            this.price = price;
            this.subTotal = subTotal;
            this.totalItbis = totalItbis;
            this.total = total;
        }
    }
}
