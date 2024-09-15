using System;

namespace Nucleo.EventBus;

public interface IEventBus
{
    void Publish<T>(T @event, string topic = null) where T : class;
}

public interface IEventHandler<in T> where T : class
{
    Task Handle(T @event);
}
