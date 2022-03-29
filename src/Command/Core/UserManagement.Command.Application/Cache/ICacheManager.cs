namespace UserManagement.Command.Application.Cache;

public interface ICacheManager
{
    public Task<bool> SetToCache<T>(string key, T data);
    public Task<T> ReadFromCache<T>(string key);
    public Task<string> ReadFromCache(string key);
    public Task<bool> RemoveFromCache(string key);
    public Task<bool> IsKeyExist(string key);
    public Task<bool> ClearCache();
    
}