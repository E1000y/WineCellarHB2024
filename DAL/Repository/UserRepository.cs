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
            return _ct.Users.ToList();

        }
    }
}
