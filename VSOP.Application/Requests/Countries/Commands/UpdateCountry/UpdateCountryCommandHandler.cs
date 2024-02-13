﻿using System.Net;
using VSOP.Application.Abstractions.Messaging;
using VSOP.Application.Data;
using VSOP.Application.Requests.Worlds.Commads.UpdateWorld;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Domain.Primitives;
using VSOP.Domain.Primitives.Results;

namespace VSOP.Application.Requests.Countries.Commands.CreateCountry
{
    internal sealed class UpdateCountryCommandHandler : ICommandHandler<UpdateCountryCommand, Country>
    {
        private readonly ICountryRepository _Repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryCommandHandler(ICountryRepository repository, IUnitOfWork unitOfWork)
        {
            _Repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Country>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _Repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return Result.Failure<Country>(new Error($"No {typeof(World)} were found for Id {request.Id}"), HttpStatusCode.UnprocessableContent);

            entity.Update(request.Name);

            _Repository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Country>(entity);
        }
    }
}
