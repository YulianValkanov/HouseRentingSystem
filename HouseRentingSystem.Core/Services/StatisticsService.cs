using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistics;
using HouseRentingSystem.Infrastructure.Data;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Services
{
    public class StatisticsService : IStatisticsService
    {

        private readonly IRepository repo;

        public StatisticsService(IRepository _repo)
        {
            repo= _repo;
        }
        public async Task<StatisticsServiceModel> Total()
        {
            int totalHouses = await repo.AllReadonly<House>()
                .CountAsync(c=>c.isActive);

            int rentedHouses=await repo.AllReadonly<House>()
                .CountAsync(c => c.isActive &&  c.RenterId!=null);

            return new StatisticsServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = rentedHouses,
            };


        }
    }
}
