using Models.DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;

namespace DAL.Interfaces
{
    public interface IDrawerBusiness
    {

        public bool CheckNoDrawerHasSameNumberThanInDrawerPostDTO(DrawerPostDTO drawerPostDTO, List<Drawer> drawers);

        public bool IsTrueWhenDrawerWithCellarIdAndNumberExists(DrawerPutDTO drawerPutDto);
       
    }
}
