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
                      SetProperty(u => u.Password, user.Password).
                      SetProperty(u => u.PhoneNumber, user.PhoneNumber).
                      SetProperty(u => u.Address, user.Address));
            await _ct.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _ct.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            await _ct.SaveChangesAsync();
        }

    }
}
