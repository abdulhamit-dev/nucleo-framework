# Nucleo.Cache

Nucleo.Cache is a caching library designed to provide efficient and easy-to-use caching mechanisms for .NET applications.

## Features

- **In-Memory Caching**: Store and retrieve data quickly using in-memory storage.
- **Distributed Caching**: Support for distributed cache providers like Redis.
- **Expiration Policies**: Set absolute or sliding expiration for cached items.
- **Thread-Safe**: Ensure thread safety for concurrent access.

## Installation

To install Nucleo.Cache, use the following NuGet command:

```sh
dotnet add package Nucleo.Cache
```

## Usage

### Basic In-Memory Cache

```csharp
using Nucleo.Cache;

var cache = new MemoryCache();
cache.Set("key", "value", TimeSpan.FromMinutes(5));

var value = cache.Get<string>("key");
```

### Distributed Cache with Redis

```csharp
using Nucleo.Cache;
using Nucleo.Cache.Redis;

var redisCache = new RedisCache("your-redis-connection-string");
redisCache.Set("key", "value", TimeSpan.FromMinutes(5));

var value = redisCache.Get<string>("key");
```

## Contributing

Contributions are welcome! Please read the [contributing guidelines](CONTRIBUTING.md) before submitting a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any questions or feedback, please open an issue on GitHub.
