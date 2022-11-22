using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repo;

        public HouseService(IRepository _repo)
        {
            repo= _repo;
        }

        public async Task<HousesQueryModel> All(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new HousesQueryModel();
            var houses = repo.AllReadonly<House>();
               // .Where(h => h.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                houses = houses
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                houses = houses
                    .Where(h => EF.Functions.Like(h.Title.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Address.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Description.ToLower(), searchTerm));
            }

            //switch (sorting)
            //{
            //    case HouseSorting.Price:
            //        houses = houses
            //        .OrderBy(h => h.PricePerMonth);
            //        break;
            //    case HouseSorting.NotRentedFirst:
            //        houses = houses
            //        .OrderBy(h => h.RenterId);
            //        break;
            //    default:
            //        houses = houses.OrderByDescending(h => h.Id);
            //        break;
            //}

            houses = sorting switch
            {
                HouseSorting.Price => houses
                    .OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentedFirst => houses
                    .OrderBy(h => h.RenterId),
                _ => houses.OrderByDescending(h => h.Id)
            };

            result.Houses = await houses
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Address = h.Address,
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title
                })
                .ToListAsync();

            result.TotalHousesCount = await houses.CountAsync();

            return result;
        }


        public  async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();

        }






        public async Task<IEnumerable<HouseCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                 .OrderBy(x => x.Name)
                 .Select(c => new HouseCategoryModel() {
                 Id=c.Id,
                 Name=c.Name
                 })
                 .ToListAsync();
        }

        

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(HouseModel model,int AgentId)
        {
            var house = new House()
            {
                Address=model.Address,
                CategoryId=model.CategoryId,
                Description=model.Description,
                ImageUrl=model.ImageUrl,
                PricePerMonth=model.PricePerMonth,
                Title=model.Title,
                AgentId= AgentId

            };

            await repo.AddAsync(house);
            await repo.SaveChangesAsync();

            return house.Id;
        }





        public async Task<IEnumerable<HouseHomeModel>> LastThreeHouses()
        {


           var houses= await repo.AllReadonly<House>()
                .OrderByDescending(x => x.Id)
                .Select(h => new HouseHomeModel
                {
                Id=h.Id,
                ImageUrl=h.ImageUrl,
                Title=h.Title

                })
                  .Take(3)
                .ToListAsync();

            return houses;
        }
    }
}
