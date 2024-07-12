using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using DAL.Interfaces;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BottleController(IBottleRepository _bottleRepository,IBottleBusiness bottlebusiness) : ControllerBase
    {
       

        [HttpGet]

        public IActionResult GetBottles()
        {
            return Ok(_bottleRepository.GetAll());
        }



        [HttpGet(("{id}"))]

        public IActionResult GetBottles(int id)
        {
            return Ok(_bottleRepository.GetbottlebyID(id));
        }

        [HttpPost]

        public IActionResult CreateBottles([FromBody] BottlePostDTO bottletopost)
        {
            if (bottletopost.DrawerId <= 0)
            {
                return BadRequest();
            }

            /*
             * faire en sorte que la bouteille ne puisse pas avoir la même position qu'une autre bouteille pour un même drawerId           
             * 
             * Je ne dois pas pouvoir post une bottle si une existe déjà pour le drawerId et le drawerposition.
             */


            if (bottlebusiness.IsBottleExistingForDrawerIdAndDrawerPosition(bottletopost.DrawerId, bottletopost.DrawerPosition))
            {
                return BadRequest("There already is a bottle in this drawerId and drawerPosition.");
            }




            Bottle bottle = new Bottle();
            bottle.Color = bottletopost.Color;
            bottle.Name = bottletopost.Name;
            bottle.FullName = bottletopost.FullName;
            bottle.VintageYear = bottletopost.VintageYear;
            bottle.YearsOfKeep = bottletopost.YearsOfKeep;
            bottle.DomainName = bottletopost.DomainName;
            bottle.PeakInDate = bottletopost.PeakInDate;
            bottle.PeakOutDate = bottletopost.PeakOutDate;

            bottle.GrapeVariety =bottletopost.GrapeVariety;
            bottle.Tava =bottletopost.Tava;
            bottle.Capacity = bottletopost.Capacity;
            bottle.WineMakerName =bottletopost.WineMakerName;
            bottle.VintageName=bottletopost.VintageName;
            bottle.Aroma=bottletopost.Aroma;
            bottle.Price=bottletopost.Price;
            bottle.PurchaseDate=bottletopost.PurchaseDate;
            bottle.RelatedMeals=bottletopost.RelatedMeals;
            bottle.DrawerPosition=bottletopost.DrawerPosition;
 //           bottle.Drawer = bottletopost.Drawer
            bottle.DrawerId=bottletopost.DrawerId;


           _bottleRepository.CreateNewBottle(bottle);


            return Created($"bottle/{bottle.Id}", bottle);

        }

     

        [HttpPut("{id}")]

        public async Task<IActionResult> ModifyBottles([FromRoute] int id, [FromBody] BottlePutDTO bottletoput)
        {
            if (id <= 0 || id != bottletoput.Id)
            {
                return BadRequest();
            }
            /*
             * Je ne dois pas pouvoir put une bottle si une existe déjà pour le drawerId et le drawerPosition sauf si c'est elle-même
             * */


            if (bottlebusiness.IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItself(bottletoput)) 
                {
                
                    return BadRequest("There already is a bottle in this drawerId and drawerPosition.");
                }

                Bottle bottle = new Bottle();
            bottle.Id = bottletoput.Id;
            bottle.Color = bottletoput.Color;
            bottle.Name = bottletoput.Name;
            bottle.FullName = bottletoput.FullName;
            bottle.VintageYear = bottletoput.VintageYear;
            bottle.YearsOfKeep = bottletoput.YearsOfKeep;
            bottle.DomainName = bottletoput.DomainName;
            bottle.PeakInDate = bottletoput.PeakInDate;
            bottle.PeakOutDate = bottletoput.PeakOutDate;
            bottle.GrapeVariety = bottletoput.GrapeVariety;
            bottle.Tava = bottletoput.Tava;
            bottle.Capacity = bottletoput.Capacity;
            bottle.WineMakerName = bottletoput.WineMakerName;
            bottle.VintageName = bottletoput.VintageName;
            bottle.Aroma = bottletoput.Aroma;
            bottle.Price = bottletoput.Price;
            bottle.PurchaseDate = bottletoput.PurchaseDate;
            bottle.RelatedMeals = bottletoput.RelatedMeals;
            bottle.DrawerPosition = bottletoput.DrawerPosition; 
            bottle.DrawerId = bottletoput.DrawerId;
            

            await _bottleRepository.UpdateBottleAsync(bottle);


            return NoContent();
        }

       

        [HttpDelete("{id}")]

        public IActionResult DeleteBottles([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();

            Bottle bottle = _bottleRepository.GetbottlebyID(id);
            _bottleRepository.DeleteBottle(id);

            return Ok(bottle);

        }
    }
}


