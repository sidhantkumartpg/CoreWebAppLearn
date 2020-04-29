using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurant
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public int commit()
        {
            // Nothing will .Add or .Remove until SaveChanges is called
            return db.SaveChanges();
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in db.Restaurants
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            // Will return null if not any
            return db.Restaurants.Find(id); // Finds by primary key value or values
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            // The startswith and order by heavy operations will occur inside DB
            // Entity framework will just convert them to query
            return from r in db.Restaurants
                   where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // M about to give you an object whose information is already in DB
            // giving this object to track changes about this object
            var entity = db.Restaurants.Attach(updatedRestaurant);

            // Then tell ef that state of this entity (object) is modified
            // Some or all of its properties has been modified (Except Primary Key)     
            entity.State = EntityState.Modified;

            return updatedRestaurant;       // ? it returns changed obj or same as passed
        }
    }
}
