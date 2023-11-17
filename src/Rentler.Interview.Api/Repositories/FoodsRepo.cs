using Microsoft.EntityFrameworkCore;
using Rentler.Interview.Api.Context;
using Rentler.Interview.Api.Entities;

namespace Rentler.Interview.Api.Repositories
{
    public class FoodsRepo : IFoodsRepository
    {
        private readonly FoodContext _context;

        public FoodsRepo(FoodContext context)
        {
            _context = context;
        }

        public async Task<(List<Food>, PagingMetaData)> GetAllFoods(PagingModel pagingModel)
        {
            IQueryable<Food> foods;

            if (string.IsNullOrEmpty(pagingModel.SearchTerm))
            {
                foods = _context.Foods.OrderBy(f => f.FoodId).AsQueryable();
            }
            else {
                foods = _context.Foods.Where(food => food.Description.Contains(pagingModel.SearchTerm)).OrderBy(f => f.FoodId).AsQueryable();
            }            

            return await GetPaginatedFoods(pagingModel, foods);            
        }        

        private async Task<(List<Food>, PagingMetaData)> GetPaginatedFoods(PagingModel pagingModel, IQueryable<Food> foods)
        {
            if (pagingModel == null)
            {
                pagingModel = new PagingModel()
                {
                    PageSize = 5,
                    PageNumber = 1,
                };
            }

            int count = await foods.CountAsync();
            int CurrentPage = pagingModel.PageNumber;
            int PageSize = pagingModel.PageSize;
            int TotalCount = count;
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            var items = await foods.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToListAsync();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // metadata object that goes in the header
            var paginationMetadata = new PagingMetaData
            {
                TotalCount = TotalCount,
                PageSize = PageSize,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PreviousPage = previousPage,
                NextPage = nextPage
            };

            return (items, paginationMetadata);
        }

        public async Task<Food> SaveFood(Food food)
        {
            var foodToReturn = _context.Add(food);
            await _context.SaveChangesAsync();

            return await _context.Foods.FindAsync(foodToReturn.Entity.FoodId);
        }

        public async Task<Food> GetFood(long id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task DeleteFood(long id) 
        {
            var food = new Food() { FoodId = id };
            _context.Remove(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFood(Food food)
        {
            var foodToUpdate = await _context.Foods.FindAsync(food.FoodId);

            if (foodToUpdate != null) {
                foodToUpdate.Protein = food.Protein;
                foodToUpdate.Description = food.Description;
                foodToUpdate.Fat = food.Fat;
                foodToUpdate.ServingSize = food.ServingSize;
                foodToUpdate.Sodium = food.Sodium;
                foodToUpdate.Potassium = food.Potassium;
                foodToUpdate.Calories = food.Calories;
                foodToUpdate.Brand = food.Brand;
                foodToUpdate.Carbohydrates = food.Carbohydrates;
                foodToUpdate.Cholesterol = food.Cholesterol;
                              
                await _context.SaveChangesAsync();
            }
        }
    }
}
