using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDto, Supplier>();
            this.CreateMap<PartsDto, Part>();   
            this.CreateMap<ImportCarDto,Car>();
            this.CreateMap<CustomerDto, Customer>();

            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Supplier, ExportSupplierDto>();

            this.CreateMap<Part, PartDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.ToString("F2"))); ;
            
            this.CreateMap<Car, CarDto>();

            this.CreateMap<Car, CarWithParts>()
                .ForMember(d => d.Car, s => s.MapFrom(s => s))
                .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars.Select(x => x.Part)));


            this.CreateMap<Customer, ExportCostumerDtoByMoneySPend>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count()))
                .ForMember(d => d.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(x => x.Car.PartsCars.Sum(x => x.Part.Price))));

            this.CreateMap<Sale, SalesDto>()
                .ForMember(d => d.car, opt => opt.MapFrom(src => src.Car))
                .ForMember(d => d.customerName, opt => opt.MapFrom(c => c.Customer.Name))
                .ForMember(d => d.discount, opt => opt.MapFrom(c => c.Discount.ToString("f2")))
                .ForMember(d => d.price, opt => opt.MapFrom(c => c.Car.PartsCars.Sum(x => x.Part.Price).ToString("f2")))
                .ForMember(d => d.priceWithDiscount, opt => opt.MapFrom(c => (c.Car.PartsCars.Sum(x => x.Part.Price) *(100-c.Discount)/100).ToString("f2")));
             

        }
    }
}
