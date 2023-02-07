using AutoMapper;
using TestInvoiceAPI.DTOs.Invoice;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Profiles
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceCreateDTO, Invoice>();
        }
    }
}
