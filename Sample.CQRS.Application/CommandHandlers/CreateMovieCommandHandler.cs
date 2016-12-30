using System;
using Sample.CQRS.Contracts.Commands;
using Sample.CQRS.Domain;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace Sample.CQRS.Application.CommandHandlers
{
    public enum CreateMovieStatus
    {
        Successful
    }

    public class CreateMovieCommandHandler: CommandHandler<CreateMovieCommand>
    {
        private readonly IDomainRepository _repository;

        public CreateMovieCommandHandler(IDomainRepository repository)
        {
            _repository = repository;
        }

        protected CreateMovieStatus ValidateCommand(CreateMovieCommand command)
        {
            return CreateMovieStatus.Successful;
        }

        public override void Handle(CreateMovieCommand command)
        {
            Return(ValidateCommand(command));

            var movie = new Movie(Guid.NewGuid(), command.Title, command.ReleaseDate, command.RunningTimeMinutes);

            _repository.Save(movie);
        }
    }
}