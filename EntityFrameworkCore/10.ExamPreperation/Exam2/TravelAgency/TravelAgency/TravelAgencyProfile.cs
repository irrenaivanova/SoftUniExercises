using AutoMapper;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency
{
    public class TravelAgencyProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TravelAgencyProfile()
        {
            this.CreateMap<CustomerImportDto, Customer>();
        }
    }
}
