﻿using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DrawerRepository : IDrawerRepository
    {

        private readonly CellarContext _ct;

        public DrawerRepository(CellarContext ct)
        {
            _ct = ct;
            
        }
        public async Task<List<Drawer>> GetAllAsync()
        {
            return await _ct.Drawers.ToListAsync();
        }

        public async  Task<List<Drawer>> GetByCellarIdAsync(int cellarId) 
        {
           return await _ct.Drawers?.Where(d => d.CellarId == cellarId).ToListAsync(); 
        }

        public async Task<Drawer> GetByIdAsync(int id)
        {
            return await _ct.Drawers.FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task UpdateAsync(Drawer drawer)
        {
            _ct.Drawers.Update(drawer);
            await _ct.SaveChangesAsync();
            
        }


        public async Task CreateAsync(Drawer drawer)
        {
            _ct.Drawers.Update(drawer);
            await _ct.SaveChangesAsync();
        }


     
        public async Task DeleteAsync(int id)
        {
            var Id = _ct.Drawers.Find(id);
            _ct.Drawers.Remove(Id);
           await _ct.SaveChangesAsync();
        }

        public async Task<Drawer>? GetByCellarIdAndNumberAsync(int cellarId, int number)
        {
            return await _ct.Drawers?.FirstOrDefaultAsync(d => d.CellarId == cellarId && d.Number == number);
        }
    }
}

