using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTests.Business
{
    internal class MockBottleRepository : IBottleRepository
    {

        List<Bottle> bottles = new List<Bottle>()
        {
            new Bottle() { Id= 1, DrawerId = 1, DrawerPosition = 1 }
        };

   
        public Task CreateNewBottleAsync(Bottle Bottle)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBottleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Bottle>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Bottle?> GetBottleByDrawerIdAndDrawerPositionAsync(int drawerId, int? drawerPosition)
        {
            return await Task.Run(() => { return bottles.FirstOrDefault(b => b.DrawerId == drawerId && b.DrawerPosition == drawerPosition); });
        }

        public Task<List<Bottle>> GetBottleWithinPeakAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bottle> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBottleAsync(Bottle bottle)
        {
            throw new NotImplementedException();
        }
    }
}
