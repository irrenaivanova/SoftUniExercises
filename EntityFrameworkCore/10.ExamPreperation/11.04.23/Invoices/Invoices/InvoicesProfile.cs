using AutoMapper;
using Invoices.Data.Models;
using Invoices.DataProcessor.ImportDto;

namespace Invoices
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            this.CreateMap<AddressImportDto, Address>();
            this.CreateMap<ClientImportDto, Client>();
            this.CreateMap<InvoiceImportDto, Invoice>();    
        }
    }
}
