using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed class GetAllCarQueryHandler 
    : IRequestHandler<GetAllCarQuery, PaginationResult<Car>>
{
    private readonly ICarService _carSerService;

    public GetAllCarQueryHandler(ICarService carSerService)
    {
        _carSerService = carSerService;
    }

    public async Task<PaginationResult<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> cars = await _carSerService.GetAllAsync(request, cancellationToken);
        return cars;
    }
}
