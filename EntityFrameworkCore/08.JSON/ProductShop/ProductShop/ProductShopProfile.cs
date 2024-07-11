using AutoMapper;
using Newtonsoft.Json.Serialization;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoriesProductDto, CategoryProduct>();


            this.CreateMap<Product, ExportProductPriceRangeDto>()
                .ForMember(d => d.FullName, s => s.MapFrom(x => $"{x.Seller.FirstName} {x.Seller.LastName}"));

            this.CreateMap<Product, SoldProductDto>();
            this.CreateMap<User, UsersWithAtEastOneSoldItemDto>();

        }
    }
}
