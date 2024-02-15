using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry
{
    internal sealed class CreateCountryCommandHandler : ICommandHandler<CreateCountryCommand, Country>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IWorldRepository _worldRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryCommandHandler(ICountryRepository countryRepository, IWorldRepository worldRepository, IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _worldRepository = worldRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            if (!await _worldRepository.AnyAsync(x => x.Id == request.WorldId, cancellationToken))
                return Result.Failure<Country>(new Error($"{nameof(World)} was not found by Id - {request.WorldId}"), HttpStatusCode.UnprocessableContent);

            var entity = Country.Create(request.name, request.WorldId);

            await _countryRepository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(entity);
        }
    }
}
