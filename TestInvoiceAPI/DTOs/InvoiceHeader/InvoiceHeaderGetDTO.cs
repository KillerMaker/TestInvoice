namespace TestInvoiceAPI.DTOs.InvoiceHeader
{
    public class InvoiceHeaderGetDTO
    {
        public int? id { get; init; }
        public int? customerId { get; init; }
        public decimal totalItbis { get; init; }
        public decimal subTotal { get; set; }
        public decimal total { get; set; }

        public InvoiceHeaderGetDTO(int? id, int? customerId, decimal totalItbis, decimal subTotal, decimal total)
        {
            this.id = id;
            this.customerId = customerId;
            this.totalItbis = totalItbis;
            this.subTotal = subTotal;
            this.total = total;
        }
    }
}
