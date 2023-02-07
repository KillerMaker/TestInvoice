namespace TestInvoiceAPI.Models
{
    public class Invoice
    {
        public InvoiceHeader header { get; init; }
        public List<InvoiceDetail> details { get; set; }

        public Invoice(InvoiceHeader header)
        {
            this.header = header;
           details= new List<InvoiceDetail>();
        }

        public void AddDetail(InvoiceDetail detail)=>
            details.Add(detail);

    }
}
