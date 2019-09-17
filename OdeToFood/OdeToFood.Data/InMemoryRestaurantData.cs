using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(i => i.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var resto = _restaurants.FirstOrDefault(r => r.Id == id);
            if (resto != null)
            {
                _restaurants.Remove(resto);
            }

            return resto;
        }

        public int Commit()
        {
            return 0;
        }
    }
}