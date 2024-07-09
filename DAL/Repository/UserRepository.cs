using DAL.Interfaces;
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

        
        public List<CellarUser> GetAll()
        {
            var stock = _ct.Users;
            return stock.ToList() ;

        }


        public CellarUser GetById(int id)
        {
            return _ct.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(CellarUser user)
        {
            _ct.Users.Update(user);
            _ct.SaveChanges();

        }
        public void Create(CellarUser user)
        {
            _ct.Users.Add(user);
            _ct.SaveChanges();
        }

        public void Delete(int id)
        {
            _ct.Users.Remove(GetById(id));
            _ct.SaveChanges();
        }

    }
}
