using API.Models;
using GoogleApi.Entities.Places.Search.Text.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IGoogleAPIservice _googleAPIservice;
        private readonly ICacheService _cacheService;

        public RestaurantService(IGoogleAPIservice googleAPIservice, ICacheService cacheService)
        {
            _googleAPIservice = googleAPIservice;
            _cacheService = cacheService;
        }

        // This method will get reataurant list from google places from location parameter
        public async Task<string> GetRestaurantList(Restaurant restaurant)
        {
            // Find Data from cache
            string cacheResult = await _cacheService.GetMemoryCache<string>(restaurant.Location).ConfigureAwait(false);

            if (cacheResult != null)
            {
                // if data found in cache send data from cache
                return cacheResult;
            }

            // Set request for search restaurant by location text
            PlacesTextSearchRequest request = new PlacesTextSearchRequest
            {
                Query = string.Concat("restaurant+in+", restaurant.Location)
            };

            // Get result from google place api
            string result = await _googleAPIservice.GooglePlacesTextSearch(request).ConfigureAwait(false);

            // Set result to cache

            await _cacheService.SetMemoryCache(restaurant.Location, result).ConfigureAwait(false);

            return result;
        }
    }
}