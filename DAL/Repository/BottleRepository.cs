using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
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


        public List<Bottle> GetAll()
        {
            var bottlesinStock = _ct.Bottles;
            return bottlesinStock.ToList();

        }
        public Bottle? GetbottlebyID(int Id) => _ct.Bottles.FirstOrDefault(u => u.Id == Id);
        public void UpdateBottle(Bottle bottle)
        {
            _ct.Bottles.Add(bottle);
            _ct.SaveChanges();

        }
        public void CreateNewBottle(Bottle bottle)
        {
            _ct.Bottles.Add(bottle);
            _ct.SaveChanges();
            
        }

        public void DeleteBottle(int Id)
        {
            _ct.Bottles.Remove(GetbottlebyID(Id));
            _ct.SaveChanges();
        }

    }

}
