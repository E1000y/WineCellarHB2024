using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICellarRepository
    {
        public Task<List<Cellar>> GetAllAsync();

        public Task<Cellar> GetByIdAsync(int id);

        public Task CreateAsync(Cellar user);

        public Task UpdateAsync(Cellar user);

        public Task DeleteAsync(int id);

        public Task DeleteChainBotAsync(int id);

        public Task DeleteChainDrawAsync(int id);
    }
}
