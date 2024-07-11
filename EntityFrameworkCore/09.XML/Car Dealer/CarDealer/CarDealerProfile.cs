using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupllyDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCarDto, Car>();
            this.CreateMap<ImportPartDto2, PartCar>();
          this.CreateMap<ImportCostumerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();



            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, CarBmwDto>();

            this.CreateMap<Supplier, NotImporter>()
                .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.Parts.Count));

            this.CreateMap<PartCar, Part1>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Part.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Part.Price));

            this.CreateMap<Car, Car1>()
                .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars));

        }
    }
}
