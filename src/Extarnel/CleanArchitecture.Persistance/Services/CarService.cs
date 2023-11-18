using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Command.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using EntityFrameworkCorePagination.Nuget.Pagination;
using GenericRepository;

namespace CleanArchitecture.Persistance.Services;

public sealed class CarService : ICarService
{
    //private readonly AppDbContext _context;
    private readonly ICarRepository _carRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);

        await _carRepository.AddAsync(car, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        return await _carRepository
            .GetWhere(p => p.Name.ToLower().Contains(request.Search.ToLower()))
            .ToPagedListAsync(request.pageNumber,request.pageSize,cancellationToken);
    }
}
