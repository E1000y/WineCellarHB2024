using Microsoft.AspNetCore.Identity;
using System;


namespace Models
{
     public class CellarUser :IdentityUser
        {
            //public int Id { get; set; }
           public string? FirstName { get; set; }

           public string? LastName { get; set; }

           public DateOnly? BirthDate { get; set; }


           public string? Address { get; set; }

        public List<Cellar>? Cellars { get; set; }

    }

}
