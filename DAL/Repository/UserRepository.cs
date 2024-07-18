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


        public async Task<CellarUser> GetByIdAsync(string id)
        {
            return await _ct.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task CreateAsync(CellarUser user)
        {
            _ct.Users.Add(user);
            await _ct.SaveChangesAsync();
        }

        public async Task UpdateAsync(CellarUser user)
        {
            await _ct.Users.Where(u => u.Id == user.Id).ExecuteUpdateAsync(
                updates => updates.
                SetProperty(u => u.FirstName, user.FirstName).
                      SetProperty(u => u.LastName, user.LastName).
                      SetProperty(u => u.BirthDate, user.BirthDate).
                      SetProperty(u => u.Email, user.Email).
                      SetProperty(u => u.PhoneNumber, user.PhoneNumber).
                      SetProperty(u => u.Address, user.Address));
            await _ct.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            await _ct.Users.Where(u => u.Id.Equals(id)).ExecuteDeleteAsync();
            await _ct.SaveChangesAsync();
        }
        public async Task DeleteChainBotAsync(string id)
        {
            await _ct.Bottles.Include(d => d.Drawer)
                .ThenInclude(c => c.Cellar)
                .ThenInclude(u => u.User).Where(b => b.Drawer.Cellar.User.Id.Equals(id)).ExecuteDeleteAsync();
        }
        public async Task DeleteChainDrawAsync(string id)
        {
            await _ct.Drawers.Include(c => c.Cellar)
                .ThenInclude(u => u.User).Where(d => d.Cellar.User.Id.Equals(id)).ExecuteDeleteAsync();
        }
        public async Task DeleteChainCelAsync(string id)
        {
            await _ct.Cellars.Include(u => u.User).Where(c => c.User.Id.Equals(id)).ExecuteDeleteAsync();
        }
    }
}
