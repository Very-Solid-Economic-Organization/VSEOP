//using FSOP.Application.Interfaces;
//using MediatR;
//using VSOP.Domain.Primitives.Results;

//namespace VSOP.Application.Common.Behaviors;

//public class ValidationBehaviour<TRequest, TResponse>
//        : IPipelineBehavior<TRequest, TResponse>
//        where TRequest : IRequest<TResponse>
//        where TResponse : Result
//{
//    private readonly IValidationHandler<TRequest>? validationHandler;

//    public ValidationBehaviour() { }
//    public ValidationBehaviour(IValidationHandler<TRequest> validationHandler)
//    {
//        this.validationHandler = validationHandler;
//    }
//    public async Task<TResponse> Handle(TRequest request,
//        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
        
//        var requestName = request.GetType();

//        if (validationHandler == null)
//            return await next();

//        var result = await validationHandler.Validate(request);
//        if (!result.IsSuccess)
//        {
//            //Log.Warning("Validation failed for {Request}. Error: {Error}", requestName, result.Error);
//            return TResponse.Failure();
//        }
//        else
//        {
//            //Log.Information("Validation successful for {Request}.", requestName);
//            return await next();
//        }
//    }
//}