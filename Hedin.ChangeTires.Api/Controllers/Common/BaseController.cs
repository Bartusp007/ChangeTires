using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hedin.ChangeTires.Api.Controllers.Common
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected Task Handle(IRequest request)
        {
            return Mediator.Send(request);
        }

        protected Task<TResponse> Handle<TResponse>(IRequest<TResponse> request)
        {
            return Mediator.Send(request);
        }
    }
}
