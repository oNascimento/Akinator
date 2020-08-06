using System;
using System.Collections.Generic;
using Objective.Akinator.WebApi.Models;

namespace Objective.Akinator.WebApi.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        List<Food> GetAll(Func<Food, bool> filter);
        Food Get(string id);
        Food GetFirst();
        Food? GetByName(string name);
        void Add(Food food);
        void UpdateNextLeft(string idParent, string idChild);
        void UpdateNextRight(string idParent, string idChild);
    }
}