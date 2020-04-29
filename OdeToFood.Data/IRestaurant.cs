using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurant
    {
        public IEnumerable<Restaurant> GetAll();
        public IEnumerable<Restaurant> GetRestaurantsByName(string name);
        public Restaurant GetRestaurantById(int id);
        public Restaurant Update(Restaurant updatedRestaurant);
        public Restaurant Create(Restaurant newRestaurant);
        public int commit();
        public Restaurant Delete(int id);
    }
}
