using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // Post api/restaurant
        // This will return list of restaurant from location parameter search
        // Remark Use HttpPost method for security reason
        [HttpPost]
        public async Task<ActionResult<string>> GetRestaurantList([FromBody]Restaurant restaurantModel)
        {
            string result = await _restaurantService.GetRestaurantList(restaurantModel).ConfigureAwait(false);

            return Ok(result);
        }

        // Get api/restaurant
        // default api show project name
        [HttpGet]
        public async Task<ActionResult<string>> Show()
        {
            return await Task.Run(() => "RestaurantList API").ConfigureAwait(false);
        }
    }
}