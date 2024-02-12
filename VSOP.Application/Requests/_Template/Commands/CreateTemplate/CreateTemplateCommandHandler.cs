﻿//using VSOP.Application.Abstractions.Messaging;
//using VSOP.Application.Data;
//using VSOP.Domain.Primitives;
//using VSOP.Domain.Primitives.Results;

//namespace VSOP.Application.Requests.Template.Commands.CreateTemplate
//{
//    internal sealed class CreateTemplateCommandHandler : ICommandHandler<CreateTemplateCommand, Template>
//    {
//        private readonly ITemplateRepository _Repository;
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateTemplateCommandHandler(ITemplateRepository repository, IUnitOfWork unitOfWork)
//        {
//            _Repository = repository;
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<Result<Template>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
//        {
//            var newWorld = Template.Create(request.name);

//            await _Repository.AddAsync(newWorld, cancellationToken);

//            await _unitOfWork.SaveChangesAsync(cancellationToken);

//            return Result.Success<Template>(Template);
//        }
//    }
//}