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


        public Cellar GetById(int id)
        {
            return _ct.Cellars.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Cellar cellar)
        {
            _ct.Cellars.Update(cellar);
            _ct.SaveChanges();

        }
        public void Create(Cellar cellar)
        {
            _ct.Cellars.Add(cellar);
            _ct.SaveChanges();
        }

        public Cellar Delete(int id)
        {
            _ct.Cellars.Remove(GetById(id));
            _ct.SaveChanges();
            var cellar = this._ct.Cellars.Find(id);
            return cellar;

        }

    }
}

