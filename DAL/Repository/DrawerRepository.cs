using DAL.Interfaces;
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
        public List<Drawer> GetAll()
        {
            return _ct.Drawers.ToList();
        }

        public List<Drawer> GetByCellarId(int cellarId) {
          
            
            return _ct.Drawers?.Where(d => d.CellarId == cellarId).ToList(); 
        }

        public Drawer GetById(int id)
        {
            return _ct.Drawers.FirstOrDefault(d => d.Id == id);
        }
        public void Update(Drawer drawer)
        {
            _ct.Drawers.Update(drawer);
            _ct.SaveChanges();
            
        }


        public void Create(Drawer drawer)
        {
            _ct.Drawers.Update(drawer);
            _ct.SaveChanges();
        }


     
        public void Delete(int id)
        {_ct.Drawers.Remove(GetById(id));
            _ct.SaveChanges();
        }

     
    }
}

