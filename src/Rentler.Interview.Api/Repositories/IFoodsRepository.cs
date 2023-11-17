using Microsoft.EntityFrameworkCore;
using Rentler.Interview.Api.Entities;

namespace Rentler.Interview.Api.Repositories
{
    public interface IFoodsRepository
    {
        Task<(List<Food>, PagingMetaData)> GetAllFoods(PagingModel pagingData);
        Task<Food> GetFood(long id);
        Task<Food> SaveFood(Food food);
        Task DeleteFood(long id);
        Task UpdateFood(Food food);


    }
}
