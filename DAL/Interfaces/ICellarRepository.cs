using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICellarRepository
    {
        public List<Cellar> GetAll();

        public Cellar GetById(int id);

        public void Create(Cellar user);

        public void Update(Cellar user);

        public void Delete(int id);
    }
}
