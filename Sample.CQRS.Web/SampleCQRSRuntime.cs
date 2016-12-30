using Sample.CQRS.Infrastrure;
using ServiceStack;
using SimpleCqrs;
using SimpleCqrs.Eventing;
using SimpleCqrs.Unity;
using SimpleCqrs.EventStore.SqlServer;
using SimpleCqrs.EventStore.SqlServer.Serializers;

namespace Sample.CQRS.Web
{
    public class SampleCqrsRuntime: SimpleCqrsRuntime<UnityServiceLocator>
    {
        protected override IEventStore GetEventStore(IServiceLocator serviceLocator)
        {
            var configuration = new SqlServerConfiguration(Constants.SampleCQRSMovieConnectionString);
            return new SqlServerEventStore(configuration, new JsonDomainEventSerializer());
        }
    }
}