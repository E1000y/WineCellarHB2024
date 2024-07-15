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
    public class CellarRepository : ICellarRepository
    {
        private readonly CellarContext _ct;

        public CellarRepository(CellarContext ct)
        {
            _ct = ct;
        }


        public async Task<List<Cellar>> GetAllAsync()
        {
            return await _ct.Cellars.ToListAsync();
        }


        public async Task<Cellar> GetByIdAsync(int id)
        {
            return await _ct.Cellars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateAsync(Cellar cellar)
        {
            _ct.Cellars.Add(cellar);
            await _ct.SaveChangesAsync();
        }
        public async Task UpdateAsync(Cellar cellar)
        {
            await _ct.Cellars.Where(u => u.Id == cellar.Id).ExecuteUpdateAsync(
                updates => updates.
                SetProperty(c => c.Name, cellar.Name).
                      SetProperty(c => c.Family, cellar.Family ).
                      SetProperty(c => c.Manufacturer, cellar.Manufacturer).
                      SetProperty(c => c.Temperature, cellar.Temperature));
            await _ct.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            await _ct.Cellars.Where(c => c.Id == id).ExecuteDeleteAsync();
            await _ct.SaveChangesAsync();
        }

    }
}

