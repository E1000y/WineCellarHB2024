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

        public Task<bool> IsBottleExistingForDrawerIdAndDrawerPositionAsync(int drawerId, int? drawerPosition);

        public Task<bool> IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItselfAsync(BottlePutDTO bottletoput);

        public Task<bool> IsDrawerBigEnough(BottlePostDTO bottlePostDTO);


    }
}
