using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface IRestaurantService
    {
        Task<string> GetRestaurantList(Restaurant restaurant);
    }
}