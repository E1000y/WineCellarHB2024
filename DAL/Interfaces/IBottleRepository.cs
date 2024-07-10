
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBottleRepository
    {
            public List<Bottle> GetAll();


            public Bottle GetbottlebyID(int id);

            public void CreateNewBottle(Bottle Bottle);

            public void UpdateBottle(Bottle bottle);


            public void DeleteBottle(int Id);
        }
    }

