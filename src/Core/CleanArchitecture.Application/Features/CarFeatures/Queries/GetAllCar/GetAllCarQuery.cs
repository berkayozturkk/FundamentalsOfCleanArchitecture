using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed record GetAllCarQuery(
    int pageNumber = 1,
    int pageSize = 10,
    string Search = ""): IRequest<PaginationResult<Car>>
{
}
