using AutoMapper;
using TestInvoiceAPI.DTOs.InvoiceDetail;
using TestInvoiceAPI.DTOs.InvoiceHeader;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Profiles
{
    public class InvoiceHeaderProfiles:Profile
    {
        public InvoiceHeaderProfiles()
        {
            CreateMap<InvoiceHeader, InvoiceDetailGetDTO>();
            CreateMap<InvoiceHeaderCreateDTO, InvoiceHeader>();
            CreateMap<InvoiceHeaderUpdateDTO, InvoiceHeader>();
        }
    }
}
