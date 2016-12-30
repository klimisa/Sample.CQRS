using System;
using SimpleCqrs.Eventing;

namespace Sample.CQRS.Contracts.Events
{
    public class MovieCreatedEvent : DomainEvent
    {
        private Guid MovieId
        {
            get { return AggregateRootId; }
            set { AggregateRootId = value; }
        }
        public DateTime ReleaseDate { get; set; }
        public int RunningTimeMinutes { get; set; }
        public string Title { get; set; }
        public MovieCreatedEvent(Guid movieId, string title, DateTime releaseDate, int runningTimeMinutes)
        {
            MovieId = movieId;
            Title = title;
            ReleaseDate = releaseDate;
            RunningTimeMinutes = runningTimeMinutes;
        }
    }
}
