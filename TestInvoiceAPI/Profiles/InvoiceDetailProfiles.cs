using AutoMapper;
using TestInvoiceAPI.DTOs.InvoiceDetail;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Profiles
{
    public class InvoiceDetailProfiles:Profile
    {
        public InvoiceDetailProfiles()
        {
            CreateMap<InvoiceDetail, InvoiceDetailGetDTO>();
            CreateMap<InvoiceDetailCreateDTO, InvoiceDetail>();
            CreateMap<InvoiceDetailUpdateDTO, InvoiceDetail>();
        }
    }
}
