﻿//using System.Net;
//using VSOP.Application.Abstractions.Messaging;
//using VSOP.Domain.DbModels.Worlds;
//using VSOP.Domain.Primitives;
//using VSOP.Domain.Primitives.Results;

//namespace VSOP.Application.Requests.Template.Queries.GetTemplate;

//internal sealed class GetTemplateByIdQueryHandler : IQueryHandler<GetTemplateByIdQuery, Template>
//{
//    private readonly ITemplateRepository _Repository;

//    public GetTemplateByIdQueryHandler(ITemplateRepository Repository)
//    {
//        _Repository = Repository;
//    }

//    public async Task<Result<Template>> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
//    {
//        var result = await _Repository.GetByIdAsync(request.Id, cancellationToken);
//        if (result is null)
//            return Result.Failure<Template>(new Error(
//                HttpStatusCode.NoContent,
//                $"No worlds were found by {request.Id}"));

//        return Result.Success(result);
//    }
//}