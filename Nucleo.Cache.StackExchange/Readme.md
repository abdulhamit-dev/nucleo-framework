# Nucleo.Cache.StackExchange

Welcome to the Nucleo.Cache.StackExchange repository. This project provides caching capabilities using StackExchange.Redis.

## Getting Started

To get started with Nucleo.Cache.StackExchange, follow these steps:

1. **Installation**: Add the package to your project.
    ```bash
    dotnet add package Nucleo.Cache.StackExchange
    ```

2. **Configuration**: Configure the cache settings in your application.
    ```csharp
    var cacheOptions = new CacheOptions
    {
        ConnectionString = "your_redis_connection_string"
    };
    ```

3. **Usage**: Use the cache in your application.
    ```csharp
    var cache = new StackExchangeCache(cacheOptions);
    cache.Set("key", "value");
    var value = cache.Get("key");
    ```

## Contributing

We welcome contributions! Please read our [contributing guidelines](CONTRIBUTING.md) to get started.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any questions or feedback, please open an issue or contact us at support@nucleo-framework.com.
