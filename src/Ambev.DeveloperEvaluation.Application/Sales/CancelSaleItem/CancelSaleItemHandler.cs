using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Handler for processing CancelSaleItemCommand requests.
/// </summary>
public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResponse>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleItemHandler"/> class.
    /// </summary>
    /// <param name="SaleRepository">The Sale repository.</param>
    public CancelSaleItemHandler(
        ISaleRepository SaleRepository)
    {
        _saleRepository = SaleRepository;
    }

    /// <summary>
    /// Handles the CancelSaleItemCommand request.
    /// </summary>
    /// <param name="request">The command containing the details of the sale item to cancel.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response indicating success or failure.</returns>
    /// <exception cref="ValidationException">Thrown when the request validation fails.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the sale item cannot be canceled.</exception>
    public async Task<CancelSaleItemResponse> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepository.CancelItemAsync(request.SaleNumber, request.ProductId, cancellationToken);
        if (!success)
            throw new InvalidOperationException($"Item not cancelled");

        return new CancelSaleItemResponse { Success = true };
    }
}
