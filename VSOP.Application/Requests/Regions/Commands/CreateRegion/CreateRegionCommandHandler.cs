using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Regions.Commands.CreateRegionCommands;

internal sealed class CreateRegionCommandHandler : ICommandHandler<CreateRegionCommand, Region>
{
    private readonly IRegionRepository _regionRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRegionCommandHandler(IRegionRepository regionRepository, ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    {
        _regionRepository = regionRepository;
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Region>> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        if(! await _countryRepository.AnyAsync(x=>x.Id==request.countryId, cancellationToken))
            return Result.Failure<Region>(new Error($"{nameof(Country)} was not found by Id - {request.countryId}"), HttpStatusCode.UnprocessableContent);

        var entity = Region.Create(request.name, request.countryId);

        await _regionRepository.AddAsync(entity, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(entity);
    }
}
