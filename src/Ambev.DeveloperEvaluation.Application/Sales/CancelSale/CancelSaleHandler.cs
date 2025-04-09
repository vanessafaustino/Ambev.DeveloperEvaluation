using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Handler for processing CancelSaleCommand requests
/// </summary>
public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResponse>
{
    private readonly ISaleRepository _SaleRepository;

    /// <summary>
    /// Initializes a new instance of CancelSaleHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="validator">The validator for CancelSaleCommand</param>
    public CancelSaleHandler(
        ISaleRepository SaleRepository)
    {
        _SaleRepository = SaleRepository;
    }

    /// <summary>
    /// Handles the CancelSaleCommand request
    /// </summary>
    /// <param name="request">The CancelSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the Cancel operation</returns>
    public async Task<CancelSaleResponse> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SaleRepository.CancelAsync(request.SaleNumber, cancellationToken);
        if (!success)
            throw new InvalidOperationException($"Sale [{request.SaleNumber}] not cancelled.");

        return new CancelSaleResponse { Success = true };
    }
}
