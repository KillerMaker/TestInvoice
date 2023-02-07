using TestInvoiceAPI.DTOs.InvoiceDetail;
using TestInvoiceAPI.DTOs.InvoiceHeader;

namespace TestInvoiceAPI.DTOs.Invoice
{
    public class InvoiceCreateDTO
    {
        public InvoiceHeaderCreateDTO header { get; init; }
        public List<InvoiceDetailCreateDTO> details  { get; set; }

        public InvoiceCreateDTO(InvoiceHeaderCreateDTO header)
        {
            this.header = header;
            details = new List<InvoiceDetailCreateDTO>();
        }
    }
}
