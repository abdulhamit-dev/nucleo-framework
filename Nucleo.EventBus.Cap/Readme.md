# Nucleo.EventBus.Cap

## Overview
Nucleo.EventBus.Cap is a component of the Nucleo Framework that provides event bus capabilities using the CAP (C# Advanced Producer) library.

## Features
- **Event Publishing**: Publish events to various message brokers.
- **Event Subscription**: Subscribe to events from different sources.
- **Reliability**: Ensures message delivery with retry mechanisms.

## Installation
To install Nucleo.EventBus.Cap, use the following NuGet command:
```sh
dotnet add package Nucleo.EventBus.Cap
```

## Usage
### Publishing Events
```csharp
public class MyEvent
{
    public string Message { get; set; }
}

var eventBus = new EventBus();
eventBus.Publish(new MyEvent { Message = "Hello, World!" });
```

### Subscribing to Events
```csharp
public class MyEventHandler : IEventHandler<MyEvent>
{
    public Task Handle(MyEvent @event)
    {
        Console.WriteLine(@event.Message);
        return Task.CompletedTask;
    }
}

var eventBus = new EventBus();
eventBus.Subscribe<MyEvent, MyEventHandler>();
```

## Contributing
Contributions are welcome! Please read the [contributing guidelines](CONTRIBUTING.md) before submitting a pull request.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact
For more information, please contact the maintainers at [support@nucleo-framework.com](mailto:support@nucleo-framework.com).