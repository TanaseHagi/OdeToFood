using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMenoryRestaurantData : IRestaurantData
    {
        // a list is NOT thread safe !!!
        List<Restaurant> _restaurants;

        public InMenoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant{ Id = 0, Name = "Scott's Pizza Place", Cuisine = CuisineType.Italian },
                new Restaurant{ Id = 1, Name = "Tersiguels", Cuisine = CuisineType.French },
                new Restaurant{ Id = 2, Name = "King's Contrivance", Cuisine = CuisineType.German }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Count;
            _restaurants.Add(restaurant);
            return restaurant;
        }
    }
}
