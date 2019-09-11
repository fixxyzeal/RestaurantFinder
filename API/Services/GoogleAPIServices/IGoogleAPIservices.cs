using System.Threading.Tasks;

using GoogleApi.Entities.Places.Search.Text.Request;

namespace API.Services
{
    public interface IGoogleAPIservice
    {
        Task<string> GooglePlacesTextSearch(PlacesTextSearchRequest request);
    }
}