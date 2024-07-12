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
        public bool IsBottleExistingForDrawerIdAndDrawerPosition(int drawerId, int? drawerPosition)
        {
            Bottle? bottle = _bottleRepository.GetBottleByDrawerIdAndDrawerPosition(drawerId, drawerPosition);

            return bottle != null;
        }

        public bool IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItself(BottlePutDTO bottletoput)
        {

            Bottle? bottle = _bottleRepository.GetBottleByDrawerIdAndDrawerPosition(bottletoput.DrawerId, bottletoput.DrawerPosition);

            return !((bottle != null) && (bottle.Id == bottletoput.Id));

        }
    }
}
