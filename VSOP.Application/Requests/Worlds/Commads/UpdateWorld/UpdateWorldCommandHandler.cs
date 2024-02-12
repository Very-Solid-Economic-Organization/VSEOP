//using FluentValidation;
//using System.Net;
//using VSOP.Application.Abstractions.Messaging;
//using VSOP.Application.Data;
//using VSOP.Domain.DbModels.Worlds;
//using VSOP.Domain.Primitives;
//using VSOP.Domain.Primitives.Results;

//namespace VSOP.Application.Requests.Worlds.Commads.UpdateWorld
//{


//    internal sealed class UpdateWorldCommandHandler : ICommandHandler<UpdateWorldCommand, World>
//    {
//        private readonly IWorldRepository _worldRepository;
//        private readonly IUnitOfWork _unitOfWork;

//        public UpdateWorldCommandHandler(IWorldRepository worldRepository, IUnitOfWork unitOfWork)
//        {
//            _worldRepository = worldRepository;
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<Result<World>> Handle(UpdateWorldCommand request, CancellationToken cancellationToken)
//        {
//            var entity = await _worldRepository.GetByIdAsync(request.WorldGuid, cancellationToken);
//            if (entity == null)
//                return Result.Failure<World>(new Error(
//                HttpStatusCode.NoContent, //TODO: Подумать над HTMLStatusCode подходящим для ситуации
//                $"No worlds were found for Id {request.WorldGuid}"));

//            if (entity.Name == request.Name)
//                return Result.Success<World>(entity); //Todo: Это не совсем правильно. Придумать лучше

//            entity.Name = request.Name; //ЧЕТ ЕБЛЯ КАКАЯ ТО.
//            _worldRepository.UpdateAsync(request.toUpdate, cancellationToken); //

//            await _unitOfWork.SaveChangesAsync(cancellationToken);

//            return Result.Success();
//        }
//    }
//}
