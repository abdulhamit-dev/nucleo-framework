# Nucleo.EventBus

## Overview
Nucleo.EventBus is a lightweight event bus library designed to facilitate communication between different parts of your application.

## Features
- Simple API
- High performance
- Easy integration

## Installation
To install Nucleo.EventBus, use the following command:

```bash
dotnet add package Nucleo.EventBus
```

## Usage
Here is a basic example of how to use Nucleo.EventBus:

```csharp
using Nucleo.EventBus;

// Create an event bus instance
var eventBus = new EventBus();

// Subscribe to an event
eventBus.Subscribe<MyEvent>(e => Console.WriteLine($"Event received: {e.Message}"));

// Publish an event
eventBus.Publish(new MyEvent { Message = "Hello, World!" });
```

## Contributing
Contributions are welcome! Please read the [contributing guidelines](CONTRIBUTING.md) first.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.