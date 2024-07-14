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
     public class BottleRepository : IBottleRepository
    {

        private readonly CellarContext _ct;
  
        public BottleRepository(CellarContext ct)
        {
            _ct = ct;
        }


        public async Task<List<Bottle>> GetAllAsync()
        {
            return await _ct.Bottles.ToListAsync();

        }
        public async Task<Bottle> GetByIdAsync(int id)
        {
            return await _ct.Bottles.FirstOrDefaultAsync(c => c.Id == id);
        }

        // public Bottle? GetbottlebyID(int Id) => _ct.Bottles.FirstOrDefault(u => u.Id == Id);

        public async Task UpdateBottleAsync(Bottle bottle)
        {

            await _ct.Bottles
                .Where(b => b.Id == bottle.Id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(b => b.Color, bottle.Color)
                .SetProperty(b => b.Name, bottle.Name)
                .SetProperty(b => b.FullName, bottle.FullName)
                .SetProperty(b => b.VintageYear, bottle.VintageYear)
                .SetProperty(b => b.YearsOfKeep, bottle.YearsOfKeep)
                .SetProperty(b => b.DomainName, bottle.DomainName)
                .SetProperty(b => b.PeakInDate, bottle.PeakInDate)
                .SetProperty(b => b.PeakOutDate, bottle.PeakOutDate)
                .SetProperty(b => b.GrapeVariety, bottle.GrapeVariety)
                .SetProperty(b => b.Tava, bottle.Tava)
                .SetProperty(b => b.Capacity, bottle.Capacity)
                .SetProperty(b => b.WineMakerName, bottle.WineMakerName)
                .SetProperty(b => b.VintageName, bottle.VintageName)
                .SetProperty(b => b.Aroma, bottle.Aroma)
                .SetProperty(b => b.Price, bottle.Price)
                .SetProperty(b => b.PurchaseDate, bottle.PurchaseDate)
                .SetProperty(b => b.RelatedMeals, bottle.RelatedMeals)
                .SetProperty(b => b.DrawerPosition, bottle.DrawerPosition)
                .SetProperty(b => b.DrawerId, bottle.DrawerId));


            await _ct.SaveChangesAsync();
        }
            
        public async Task CreateNewBottleAsync(Bottle bottle)
        {
            _ct.Bottles.Add(bottle);
            await _ct.SaveChangesAsync();
            
        }

        public async Task  DeleteBottleAsync(int Id)
        {
            var id = _ct.Bottles.Find(Id);
            _ct.Bottles.Remove(id);
            await _ct.SaveChangesAsync();
    
        }

        public async Task<Bottle?> GetBottleByDrawerIdAndDrawerPositionAsync(int drawerId, int? drawerPosition)
        {
           return await _ct.Bottles.FirstOrDefaultAsync(b => b.DrawerId == drawerId && b.DrawerPosition == drawerPosition);
        }
    }

}
