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
    public class BottleBusiness(IBottleRepository _bottleRepository) : IBottleBusiness
    {
        public async Task<bool> IsBottleExistingForDrawerIdAndDrawerPositionAsync(int drawerId, int? drawerPosition)
        {
            Bottle? bottle = await _bottleRepository.GetBottleByDrawerIdAndDrawerPositionAsync(drawerId, drawerPosition);

            return bottle != null;
        }

        public async Task<bool> IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItselfAsync(BottlePutDTO bottletoput)
        {

            Bottle? bottle = await _bottleRepository.GetBottleByDrawerIdAndDrawerPositionAsync(bottletoput.DrawerId, bottletoput.DrawerPosition);

            return !((bottle != null) && (bottle.Id == bottletoput.Id));

        }
    }
}
