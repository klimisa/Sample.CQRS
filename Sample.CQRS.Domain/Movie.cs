using System;
using System.Collections.Generic;
using Sample.CQRS.Contracts.Events;
using SimpleCqrs.Domain;

namespace Sample.CQRS.Domain
{
    public class Movie: AggregateRoot
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTimeMinutes { get; set; }
        public List<MovieReview> Reviews { get; set; }
        public Movie() { }
        public Movie(Guid movieId, string title, DateTime releaseDate, int runningTimeMinutes)
        {
            Apply(new MovieCreatedEvent(movieId, title, releaseDate, runningTimeMinutes));
        }
        protected void OnMovieCreated(MovieCreatedEvent domainEvent)
        {
            Id = domainEvent.AggregateRootId;
            Title = domainEvent.Title;
            ReleaseDate = domainEvent.ReleaseDate;
            RunningTimeMinutes = domainEvent.RunningTimeMinutes;
        }
    }
}
