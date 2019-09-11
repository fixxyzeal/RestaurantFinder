using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class GoogleAPIservice : IGoogleAPIservice
    {
        private readonly IConfiguration _configuration;

        public GoogleAPIservice(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This Method will return json result from google place with textsearch request
        public async Task<string> GooglePlacesTextSearch(PlacesTextSearchRequest request)
        {
            // Get google api key from appsettings.json file
            request.Key = _configuration["ApiKey"];

            PlacesTextSearchResponse response = await GoogleApi.GooglePlaces.TextSearch.QueryAsync(request).ConfigureAwait(false);
            return response.RawJson;
        }
    }
}