using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales;

/// <summary>
/// AutoMapper profile for authentication-related mappings
/// </summary>
public sealed class SaleProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SaleProfile"/> class
    /// </summary>
    public SaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => new Customer { Id = src.CustomerId }))
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => new Branch { Id = src.BranchId }))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => SaleStatus.Created));

        CreateMap<CreateSaleProductItemCommand, ProductItem>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new Product { Id = src.ProductId }))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}
