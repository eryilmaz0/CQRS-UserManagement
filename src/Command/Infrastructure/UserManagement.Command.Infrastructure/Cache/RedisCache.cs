using Newtonsoft.Json;
using StackExchange.Redis;
using UserManagement.Command.API.ConfigurationModel;
using UserManagement.Command.Application.Cache;

namespace UserManagement.Command.Infrastructure.Cache;

public class RedisCache : ICacheManager
{
    private readonly RedisConfiguration _config;
    private IConnectionMultiplexer _connection;
    private IDatabase _database;

    public RedisCache(RedisConfiguration config)
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
    

    public async Task<bool> SetToCache<T>(string key, T data)
    {
        string value = typeof(T) == typeof(string) 
                     ? data as string 
                     : JsonConvert.SerializeObject(data);

        await _database.StringSetAsync(key, value);
        return true;
    }
    

    public async Task<T> ReadFromCache<T>(string key)
    {
        var value = await this._database.StringGetAsync(key);

        if (string.IsNullOrEmpty(value))
            return default(T);

        return JsonConvert.DeserializeObject<T>(value);
    }
    
    
    public async Task<string> ReadFromCache(string key)
    {
        return await this._database.StringGetAsync(key);
    }
    

    
    public async Task<bool> RemoveFromCache(string key)
    {
        if (await this.IsKeyExist(key))
        {
            await this._database.KeyDeleteAsync(key);
            return true;
        }

        return false;
    }
    

    
    public async Task<bool> IsKeyExist(string key)
    {
        return await this._database.KeyExistsAsync(key);
    }

    
    public Task<bool> ClearCache()
    {
        throw new NotImplementedException();
    }
    
}