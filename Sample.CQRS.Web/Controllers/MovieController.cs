using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sample.CQRS.Application.CommandHandlers;
using Sample.CQRS.Contracts.Commands;
using SimpleCqrs;
using SimpleCqrs.Commanding;

namespace Sample.CQRS.Web.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        public ICommandBus CommandBus;

        public MovieController() : this(ServiceLocator.Current.Resolve<ICommandBus>())
        {

        }

        public MovieController(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }

        [HttpPost]
        [Route("add")]
        public CreateMovieStatus Create(CreateMovieCommand command)
        {
            return (CreateMovieStatus) CommandBus.Execute(command);
        }
    }
}
