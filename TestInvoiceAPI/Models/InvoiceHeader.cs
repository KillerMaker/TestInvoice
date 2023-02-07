namespace TestInvoiceAPI.Models
{
    public class InvoiceHeader
    {
        public int? id { get; init; }
        public int? customerId { get; init; }
        public decimal totalItbis { get; set; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }

        public InvoiceHeader()
        {

        }
        public InvoiceHeader(int? id, int? customerId, decimal totalItbis,decimal subTotal, decimal total)
        {
            this.id = id;
            this.customerId = customerId;
            this.totalItbis = totalItbis;
            this.subTotal = subTotal;
            this.total = total;
        }
    }
}
