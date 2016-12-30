using System;
using System.Data.SqlClient;
using Sample.CQRS.Contracts.Events;
using Sample.CQRS.Domain;
using Sample.CQRS.Infrastrure;
using SimpleCqrs.Eventing;

namespace Sample.CQRS.Application.EventHandlers
{
    public class MovieEventHandler : IHandleDomainEvents<MovieCreatedEvent>
    {
        public void Handle(MovieCreatedEvent createdEvent)
        {
            using (var connection = new SqlConnection(Constants.SampleCQRSReadModelConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Movie (Id, Title, ReleaseDate, RunningTimeMinutes)" +
                                      "VALUES (@Id, @Title, @ReleaseDate, @RunningTimeMinutes)";

                command.Parameters.Add(new SqlParameter("@Id", createdEvent.AggregateRootId));
                command.Parameters.Add(new SqlParameter("@Title", createdEvent.Title));
                command.Parameters.Add(new SqlParameter("@ReleaseDate", createdEvent.ReleaseDate));
                command.Parameters.Add(new SqlParameter("@RunningTimeMinutes", createdEvent.RunningTimeMinutes));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
