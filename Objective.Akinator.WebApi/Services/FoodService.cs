using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objective.Akinator.WebApi.Models;
using Objective.Akinator.WebApi.Repositories.Interfaces;

namespace Objective.Akinator.WebApi.Services
{
    public class FoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Food> StartGame(){
            return _foodRepository.GetFirst();
        }

        public async Task LearnRight(Food food, string idParent)
        {
            if(food.Name == null)
                throw new NullReferenceException("A Name must be provided");
            
            IndexNearestName(food);
            _foodRepository.Add(food);

            if(idParent != null)
                _foodRepository.UpdateNextRight(idParent, food.Id);
        }

        public async Task LearnLeft(Food food, string idParent)
        {
            if(food.Name == null)
                throw new NullReferenceException("A Name must be provided");
            
            IndexNearestName(food);
            _foodRepository.Add(food);
            
            if(idParent != null)
                _foodRepository.UpdateNextLeft(idParent, food.Id);
        }

        private void IndexNearestName(Food food){
            if(food.Name.Contains(" ")){
                var firstName = food.Name.Substring(0, food.Name.IndexOf(" "));
                var appendedChild = _foodRepository.GetByName(firstName);
                food.IdRight = appendedChild.Id;
            }
        }
        public async Task<Food> GetById(string id)
        {
            return _foodRepository.Get(id);
        }
    }
}