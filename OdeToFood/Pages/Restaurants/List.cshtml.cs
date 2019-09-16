using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restarauntData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restarauntData)
        {
            this.config = config;
            this.restarauntData = restarauntData;
        }

        public void OnGet()
        {
            //HttpContext.Request.Query
            Message = config["Message"];
            Restaurants = restarauntData.GetRestaurantsByName(SearchTerm);
        }
    }
}