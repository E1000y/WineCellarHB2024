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

        public async Task UpdateAsync(Cellar cellar)
        {
            _ct.Cellars.Update(cellar);
            await _ct.SaveChangesAsync();

        }
        public async Task CreateAsync(Cellar cellar)
        {
            _ct.Cellars.Add(cellar);
           await  _ct.SaveChangesAsync();
        }

        public async Task<Cellar> DeleteAsync(int id)
        {
            var cellar = this._ct.Cellars.Find(id);
            _ct.Cellars.Remove(cellar);
           await _ct.SaveChangesAsync();
            return cellar;

        }

    }
}

