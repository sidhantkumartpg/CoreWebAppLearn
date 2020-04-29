using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurant
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
                new Restaurant { id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.Italian},
                new Restaurant { id = 3, Name = "Food Point", Location = "Mullana", Cuisine=CuisineType.Indian},
                new Restaurant { id = 4, Name = "Food foundry", Location = "Barara", Cuisine=CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            // If name parameter is Empty then it will return all the list elements 
            // (because of first IsNullOrEmpty condition will be true)
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name,true,null)
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            //return from r in restaurants
            //       where r.id == id
            //       select r;
            return restaurants.SingleOrDefault(r => r.id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.id == updatedRestaurant.id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.PureVeg = updatedRestaurant.PureVeg;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            return null;
        }

        public int commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
