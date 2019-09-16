using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestarauntData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestarauntData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Anatolii`s Pizza", Location = "Kharkov", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Crishna", Location = "Odessa", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "The Varenik", Location = "Kyiv", Cuisine = CuisineType.Ukrainian }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                .OrderBy(r => r.Name);
        }
    }
}
