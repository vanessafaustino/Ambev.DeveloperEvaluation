using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Profile for mapping CancelSaleItem feature requests to commands
/// </summary>
public class CancelSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CancelSaleItem feature
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<CancelSaleItemRequest, Application.Sales.CancelSaleItem.CancelSaleItemCommand>();
    }
}
