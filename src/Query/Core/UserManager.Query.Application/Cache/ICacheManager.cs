namespace UserManager.Query.Application.Cache;

public interface ICacheManager
{
    public Task<bool> SetToCacheAsync<T>(string key, T data);
    public Task<T> ReadFromCacheAsync<T>(string key);
    public Task<string> ReadFromCacheAsync(string key);
    public Task<bool> RemoveFromCacheAsync(string key);
    public Task<bool> IsKeyExistAsync(string key);
}