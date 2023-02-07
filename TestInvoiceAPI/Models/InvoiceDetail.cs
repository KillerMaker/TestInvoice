namespace TestInvoiceAPI.Models
{
    public class InvoiceDetail
    {
        public int? id { get; init; }
        public int? invoiceId { get; set; }
        public int quantity { get; init; }
        public decimal price { get; init; }
        public decimal subTotal { get; set; }
        public decimal totalItbis { get; set; }
        public decimal total { get; set; }


        public InvoiceDetail(int? id, int? invoiceId, int quantity, decimal price, decimal subTotal, decimal totalItbis, decimal total)
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
