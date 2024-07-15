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
            return _ct.Users.ToList() ;
        }


        public CellarUser GetById(string id)
        {
            return _ct.Users.FirstOrDefault(u => u.Id.Equals(id));
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

        public void Delete(string id)
        {
            _ct.Users.Remove(GetById(id));
            _ct.SaveChanges();
        }

    }
}
