using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DAL.Interfaces;
using Models;

namespace DALTests.Business
{
    public class MockUserRepository : IUserRepository
    {
        List<CellarUser> users = new List<CellarUser>()
        {
        new CellarUser() { Id ="23a30a9c-5fd5-487e-9ab6-86bf04a2f026",FirstName="John",LastName="Doe", BirthDate =new DateOnly(1986,01,05) },
        new CellarUser() { Id ="34737e97-a89d-40f9-afd7-ef1dd82c54af",FirstName="Jane",LastName="Smith",BirthDate=new DateOnly(1990,07,02) },
        };

        public async Task IsAgeValidAsync( int age)

        {
            throw new NotImplementedException();
        }
        public Task CreateAsync(CellarUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CellarUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CellarUser> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        //public async Task<CellarUser?> GetDateonlyAsync(DateOnly dob)
        //{
        //    return await Task.Run(() =>
        //    {
        //        return users.FirstOrDefault(p => p.BirthDate == dob);
        //    });
        //}

        public Task UpdateAsync(CellarUser user)
        {
            throw new NotImplementedException();
        }
    }
}
