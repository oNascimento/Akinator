using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Objective.Akinator.WebApi.Models;
using Objective.Akinator.WebApi.Repositories.Interfaces;

namespace Objective.Akinator.WebApi.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private List<Food> Foods { get; set; }
        public FoodRepository()
        {
            Foods = new List<Food>();
            var first = new Food {
                Name = "Massa",
            };
            var second = new Food {
                Name = "Lasanha"
            };
            Add(first);
            Add(second);
            UpdateNextLeft(first.Id, second.Id);
        }
        
        public List<Food> GetAll( Func<Food, bool> filter) => Foods.Where(filter).ToList();
        public Food Get(string id) => Foods.FirstOrDefault(f => f.Id == id);
        public void Add(Food food)
        {
            food.Id = Guid.NewGuid().ToString();
            Foods.Add(food);
        }
        public void UpdateNextLeft(string idParent, string idChild) => Get(idParent).IdLeft = idChild;
        public void UpdateNextRight(string idParent, string idChild) => Get(idParent).IdRight = idChild;
        public Food GetByName(string name) => Foods.FirstOrDefault(f => EF.Functions.Like(f.Name, $"%{name}%"));
        public Food GetFirst() => Foods.First();
    }
}