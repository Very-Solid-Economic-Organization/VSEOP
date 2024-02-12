using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry
{
    internal sealed class CreateCountryCommandHandler : ICommandHandler<CreateCountryCommand, Country>
    {
        private readonly ICountryRepository _Repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryCommandHandler(ICountryRepository repository, IUnitOfWork unitOfWork)
        {
            _Repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = Country.Create(request.Name,request.WorldId);

            await _Repository.AddAsync(entity, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Country>(entity);
        }
    }
}
