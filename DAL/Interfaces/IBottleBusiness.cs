using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTOs;

namespace DAL.Interfaces
{
    public interface IBottleBusiness
    {

        public bool IsBottleExistingForDrawerIdAndDrawerPosition(int drawerId, int? drawerPosition);

        public bool IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItself(BottlePutDTO bottletoput)

    }
}
