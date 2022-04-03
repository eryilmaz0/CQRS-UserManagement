using System.Text.Json;
using MongoDB.Bson.IO;
using StackExchange.Redis;
using UserManager.Query.Application.Cache;
using UserManager.Query.Application.Configuration;

namespace UserManager.Query.Infrastructure.Cache;

public class RedisCacheManager : ICacheManager
{
    private readonly RedisConfiguration _config;
    private IConnectionMultiplexer _connection;
    private IDatabase _database;

    public RedisCacheManager(RedisConfiguration config)
    {
        _config = config;
    }


    public void StartConnection()
    {
        var redisOptions = new ConfigurationOptions()
        {
            EndPoints = { _config.Host },
            DefaultDatabase = _config.DatabaseIndex,
            Password = _config.Password,
            SyncTimeout = 10000
        };

        this._connection = ConnectionMultiplexer.Connect(redisOptions);
        this._database = _connection.GetDatabase();
    }
    

    public async Task<bool> SetToCacheAsync<T>(string key, T data)
    {
        string value = typeof(T) == typeof(string)
            ? data as string
            : JsonSerializer.Serialize(data);

        await _database.StringSetAsync(key, value);
        return true;
    }
    

    public async Task<T> ReadFromCacheAsync<T>(string key)
    {
        var value = await this._database.StringGetAsync(key);

        if (string.IsNullOrEmpty(value))
            return default(T);

        return JsonSerializer.Deserialize<T>(value);
    }
    
    
    public async Task<string> ReadFromCacheAsync(string key)
    {
        return await this._database.StringGetAsync(key);
    }
    

    
    public async Task<bool> RemoveFromCacheAsync(string key)
    {
        bool result = false;
        
        if (await this.IsKeyExistAsync(key))
        {
            result = await this._database.KeyDeleteAsync(key);
        }

        return result;
    }
    

    
    public async Task<bool> IsKeyExistAsync(string key)
    {
        return await this._database.KeyExistsAsync(key);
    }
    
}