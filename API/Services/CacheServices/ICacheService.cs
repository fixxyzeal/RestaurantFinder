using System.Threading.Tasks;

namespace API.Services
{
    public interface ICacheService
    {
        Task<T> GetMemoryCache<T>(string key);
        Task<T> SetMemoryCache<T>(string key, T value);
    }
}