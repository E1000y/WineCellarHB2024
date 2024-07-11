using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public List<CellarUser> GetAll();


        public CellarUser GetById(string id);

        public void Create(CellarUser user);

        public void Update(CellarUser user);


        public void Delete(string id);
    }
}
