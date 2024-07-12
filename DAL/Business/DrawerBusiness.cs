using DAL.Interfaces;
using Models.DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;

namespace DAL.Business
{
    public class DrawerBusiness(IDrawerRepository _drawerRepository) : IDrawerBusiness
    {

        public bool CheckNoDrawerHasSameNumberThanInDrawerPostDTO(DrawerPostDTO drawerPostDTO, List<Drawer> drawers)
        {
            bool flag = false;
            foreach (Drawer drawer in drawers)
            {
                if (drawer.Number == drawerPostDTO.Number) { flag = true; break; }
            }

            return flag;
        }

        public bool IsTrueWhenDrawerWithCellarIdAndNumberExists(DrawerPutDTO drawerPutDto)
        {
            Drawer drawer = _drawerRepository.GetByCellarIdAndNumber(drawerPutDto.CellarId, drawerPutDto.Number);

            return ((drawer != null) || (drawerPutDto.Id != drawer.Id));
        }

       
    }
}
