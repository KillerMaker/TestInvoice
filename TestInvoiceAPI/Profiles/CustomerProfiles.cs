using AutoMapper;
using TestInvoiceAPI.DTOs.Customer;
using TestInvoiceAPI.Models;

namespace TestInvoiceAPI.Profiles
{
    public class CustomerProfiles : Profile
    {
        public CustomerProfiles()
        {
            CreateMap<Customer, CustomerGetDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
        }
    }
}
