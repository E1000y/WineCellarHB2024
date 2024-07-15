using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<CellarUser>> GetAllAsync();


        public Task<CellarUser> GetByIdAsync(string id);

        public Task CreateAsync(CellarUser user);

        public Task UpdateAsync(CellarUser user);


        public Task DeleteAsync(string id);
    }
}
