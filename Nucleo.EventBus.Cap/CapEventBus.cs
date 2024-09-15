using DotNetCore.CAP;
using Nucleo.EventBus;

public class CapEventBus : IEventBus
{
    private readonly ICapPublisher _capPublisher;

    public CapEventBus(ICapPublisher capPublisher)
    {
        _capPublisher = capPublisher;
    }

    public void Publish<T>(T @event, string topic = null) where T : class
    {
        _capPublisher.Publish(topic ?? typeof(T).Name, @event);
    }
}
