using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DALTests.Business
{
    internal class MockDrawerRepository : IDrawerRepository
    {
        List<Drawer> drawers = new List<Drawer>()
        {
            new Drawer() { Id = 1, Number = 1, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 2, Number = 2, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 3, Number = 3, NbOfBottlesPerDrawer = 20, CellarId =1  },
            new Drawer() { Id = 4, Number = 1, NbOfBottlesPerDrawer = 20, CellarId =2  },
        };

        public Task CreateAsync(Drawer drawer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Drawer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Drawer> GetByCellarIdAndNumberAsync(int cellarId, int number)
        {
            return await Task.Run(()=> {
                return drawers.FirstOrDefault(d => d.CellarId == cellarId && d.Number == number);
                })  ;
        }

        public Task<List<Drawer>> GetByCellarIdAsync(int cellarId)
        {
            throw new NotImplementedException();
        }

        public Task<Drawer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Drawer drawer)
        {
            throw new NotImplementedException();
        }
    }
}

