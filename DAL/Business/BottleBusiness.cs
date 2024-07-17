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
    public class BottleBusiness(IBottleRepository _bottleRepository, IDrawerRepository drawerRepository) : IBottleBusiness
    {
        public async Task<bool> IsBottleExistingForDrawerIdAndDrawerPositionAsync(int drawerId, int? drawerPosition)
        {
            Bottle? bottle = await _bottleRepository.GetBottleByDrawerIdAndDrawerPositionAsync(drawerId, drawerPosition);

            return bottle != null;
        }

        public async Task<bool> IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItselfAsync(BottlePutDTO bottletoput)
        {
            // Fetch the bottle based on DrawerId and DrawerPosition
            Bottle? bottle = await _bottleRepository.GetBottleByDrawerIdAndDrawerPositionAsync(bottletoput.DrawerId, bottletoput.DrawerPosition);

            // Check if a bottle was found and if it's not the same as the one being put
            if (bottle != null && bottle.Id != bottletoput.Id)
            {
                return true;
            }

            return false;




            //  return !((bottle != null) && (bottle.Id == bottletoput.Id));

        }
        public async Task<bool> IsDrawerBigEnough(BottlePostDTO bottlePostDTO)
        {
            Bottle? bottle = await _bottleRepository.GetBottleByDrawerIdAndDrawerPositionAsync(bottlePostDTO.DrawerId, bottlePostDTO.DrawerPosition);
            Drawer? drawer = await drawerRepository.GetByIdAsync(bottlePostDTO.DrawerId);
            if (bottlePostDTO.DrawerPosition <= 0 || bottlePostDTO.DrawerPosition > drawer.NbOfBottlesPerDrawer)
            {
                return true;
            }
            return false;
        }

    }
}
