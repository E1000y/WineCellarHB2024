using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WineCellarHB2024.DTOs;
using DAL.Interfaces;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BottleController : ControllerBase
    {
        private readonly IBottleRepository _bottleRepository;

        public BottleController(IBottleRepository bottlerepository)
        {
            _bottleRepository = bottlerepository;
        }

        [HttpGet]

        public IActionResult GetBottles()
        {
            return Ok(this._bottleRepository.GetAll());
        }



        [HttpGet(("{id}"))]

        public IActionResult GetBottles(int id)
        {
            return Ok(this._bottleRepository.GetbottlebyID(id));
        }

        [HttpPost]

        public IActionResult CreateBottles([FromBody] BottlePostDTO bottletoput)
        {


            Bottle bottle = new Bottle();
            bottle.GrapeVariety =bottletoput.GrapeVariety;
            bottle.Tava =bottletoput.Tava;
            bottle.Capacity = bottletoput.Capacity;
            bottle.WineMakerName =bottletoput.WineMakerName;
            bottle.VintageName=bottletoput.VintageName;
            bottle.Aroma=bottletoput.Aroma;
            bottle.Price=bottletoput.Price;
            bottle.PurchaseDate=bottletoput.PurchaseDate;
            bottle.RelatedMeals=bottletoput.RelatedMeals;
            bottle.DrawerPosition=bottletoput.DrawerPosition;
            bottle.DrawerId=bottletoput.DrawerId;


           this._bottleRepository.CreateNewBottle(bottle);


            return Created($"bottle/{bottle.Id}", bottle);

        }

        [HttpPut("{id}")]

        public IActionResult ModifyBottles([FromRoute] int id, [FromBody] BottlePutDTO bottletoput)
        {
            if (id <= 0 || id != bottletoput.Id)
            {
                return BadRequest();
            }

            Bottle bottle = new Bottle();
            bottle.FullName = bottletoput.FullName;
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

            this._bottleRepository.UpdateBottle(bottle);


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBottles([FromRoute] int id)
        {


            _bottleRepository.DeleteBottle(id);

            return Ok();

        }
    }
}


