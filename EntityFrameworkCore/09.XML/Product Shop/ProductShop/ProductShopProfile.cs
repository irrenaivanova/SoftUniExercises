using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        this.CreateMap<UserDto, User>();
        this.CreateMap<User,User6>()
            .ForMember(d=>d.ProductsSold,opt=>opt.MapFrom(d=>d.ProductsSold));

        this.CreateMap<ProductDto, Product>();
        //.ForMember(x => x.SellerId, opt => opt.MapFrom(d => d.SellerId.Value));
        this.CreateMap<Product, Product6>();


        this.CreateMap<CategoryDto, Category>();
        this.CreateMap<Category, Category7>()
            .ForMember(d => d.Count, opt => opt.MapFrom(s => s.CategoryProducts.Count))
            .ForMember(d => d.AveragePrice, opt => opt.MapFrom(s => s.CategoryProducts.Average(x => x.Product.Price)))
            .ForMember(d => d.TotalRevenue, opt => opt.MapFrom(s => s.CategoryProducts.Sum(x => x.Product.Price)));

        this.CreateMap<CategoryProductDto, CategoryProduct>();

        this.CreateMap<Product,Product1>()
            .ForMember(d=>d.Buyer,opt=>opt.MapFrom(s=>$"{s.Buyer.FirstName} {s.Buyer.LastName}"));
    }
}
