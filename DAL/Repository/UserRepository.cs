using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly CellarContext _ct;

        public UserRepository(CellarContext ct)
        {
            _ct = ct;
        }


        public async Task<List<CellarUser>> GetAllAsync()
        {
            return await _ct.Users.ToListAsync();
        }


        public async Task<CellarUser> GetByIdAsync(int id)
        {
            return await _ct.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(CellarUser user)
        {
            _ct.Users.Update(user);
            await _ct.SaveChangesAsync();

        }
        public async Task CreateAsync(CellarUser user)
        {
            _ct.Users.Add(user);
            await _ct.SaveChangesAsync();
        }

        public async Task<CellarUser> DeleteAsync(int id)
        {
            var user = this._ct.Users.Find(id);
            _ct.Users.Remove(user);
            await _ct.SaveChangesAsync();
            return user;
        }

    }
}
