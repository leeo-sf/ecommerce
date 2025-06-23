using Ecommerce.Sharable;
using Ecommerce.Sharable.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controller.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseApiController(IMediator mediator) => _mediator = mediator;

        protected async Task<ActionResult<T>> SendCommand<T>(IRequest<Result<T>> request, int statusCode = 200)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess
                ? StatusCode(statusCode, response.Value)
                : HandleError(response.Exception);
        }

        protected async Task<ActionResult> SendCommand(IRequest<Result> request, int statusCode = 200)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess
                ? StatusCode(statusCode)
                : HandleError(response.Exception);
        }

        protected ActionResult HandleError(Exception error) => error switch
        {
            KeycloakException => StatusCode(StatusCodes.Status401Unauthorized, new { error.Message }),
            ApplicationException => StatusCode(StatusCodes.Status422UnprocessableEntity, new { error.Message }),
            _ => StatusCode(500)
        };
    }
}