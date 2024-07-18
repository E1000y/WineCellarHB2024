
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBottleRepository
    {
        public Task<List<Bottle>> GetAllAsync();
        public Task<Bottle> GetByIdAsync(int id);
        public Task CreateNewBottleAsync(Bottle Bottle);
        public Task UpdateBottleAsync(Bottle bottle);
        public Task DeleteBottleAsync(int id);
        public Task<Bottle?> GetBottleByDrawerIdAndDrawerPositionAsync(int drawerId, int? drawerPosition);

        public Task<List<Bottle>> GetBottleWithinPeakAsync();

    }
}

