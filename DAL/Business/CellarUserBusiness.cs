using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repository;
using Models;
using Models.DTOs;

namespace DAL.Business
{
    public class CellarUserBusiness(IUserRepository _userRepository): ICellarUserBusiness
    {
        public async Task <string> IsAgeValidAsync(DateOnly dob)
        {
            //CellarUser? CellarUser = await _userRepository.GetDateonlyAsync(dob);

            //while (CellarUser != null)
            
                 DateOnly currentdate = DateOnly.FromDateTime(DateTime.Now);

                int age = dob.Year - currentdate.Year;
                if (age > 0 && age < 18)
                {
                    return "Not Valid";
                }
                return "Valid";
            
            //return "doesnotExist";
        }  
    
    }
}
