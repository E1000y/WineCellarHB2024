using Microsoft.Identity.Client;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDrawerRepository
    {
        public Task<List<Drawer>> GetAllAsync();

        public Task<Drawer> GetByIdAsync(int id);
        public Task<List<Drawer>> GetByCellarIdAsync(int cellarId);

        public Task<Drawer> GetByCellarIdAndNumberAsync(int cellarId, int number);

        public Task CreateAsync(Drawer drawer);

        public Task UpdateAsync(Drawer drawer);

        public Task DeleteAsync(int id);

       

    }
}
