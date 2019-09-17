using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Anatolii`s Pizza", Location = "Kharkov", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Crishna", Location = "Odessa", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "The Varenik", Location = "Kyiv", Cuisine = CuisineType.Ukrainian }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return _restaurants
                .Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name))
                .OrderBy(r => r.Name);
        }

        public Restaurant GetById(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var resto = _restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (resto != null)
            {
                resto.Name = updatedRestaurant.Name;
                resto.Location = updatedRestaurant.Location;
                resto.Cuisine = updatedRestaurant.Cuisine;
            }

            return resto;
        }
        
        public int Commit()
        {
            return 0;
        }
    }
}
