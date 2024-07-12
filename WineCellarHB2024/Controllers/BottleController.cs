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
        // region pour gerer la récupération pour toutes les bouteilles (aka Get Bottles)
        #region 

        [HttpGet]

        public async Task< IActionResult> GetBottles()
        {
            List<Bottle> bottle = await _bottleRepository.GetAllAsync();
            List<BottleGetDTO> bottleGetDTOList= new List<BottleGetDTO>();
            foreach( Bottle b in bottle)
            {
                BottleGetDTO bottleGetDTO = new BottleGetDTO();
                bottleGetDTO.Id = b.Id;
                bottleGetDTO.Color = b.Color;
                bottleGetDTO.Name = b.Name;
                bottleGetDTO.FullName = b.FullName;
                bottleGetDTO.VintageYear = b.VintageYear;
                bottleGetDTO.YearsOfKeep = b.YearsOfKeep;
                bottleGetDTO.DomainName = b.DomainName;
                bottleGetDTO.PeakInDate = b.PeakInDate;
                bottleGetDTO.PeakOutDate = b.PeakOutDate;

                bottleGetDTO.GrapeVariety = b.GrapeVariety;
                bottleGetDTO.Tava = b.Tava;
                bottleGetDTO.Capacity = b.Capacity;
                bottleGetDTO.WineMakerName = b.WineMakerName;
                bottleGetDTO.VintageName = b.VintageName;
                bottleGetDTO.Aroma = b.Aroma;
                bottleGetDTO.Price = b.Price;
                bottleGetDTO.PurchaseDate = b.PurchaseDate;
                bottleGetDTO.RelatedMeals = b.RelatedMeals;
                bottleGetDTO.DrawerPosition = b.DrawerPosition;
                //           bottleGetDTO.Drawer = b.Drawer
                bottleGetDTO.DrawerId = b.DrawerId;
               bottleGetDTOList.Add(bottleGetDTO);

            }

            return Ok(bottleGetDTOList);
        }

        #endregion

        // region pour gerer la récupération d'une bouteille par l'ID (aka Get Bottles)
        #region
        [HttpGet(("{id}"))]
        public async Task<IActionResult> GetBottles(int id)
        {
            var b= await _bottleRepository.GetByIdAsync(id);
            BottleGetDTO bottleGetDTO = new BottleGetDTO();
            bottleGetDTO.Id = b.Id;
            bottleGetDTO.Color = b.Color;
            bottleGetDTO.Name = b.Name;
            bottleGetDTO.FullName = b.FullName;
            bottleGetDTO.VintageYear = b.VintageYear;
            bottleGetDTO.YearsOfKeep = b.YearsOfKeep;
            bottleGetDTO.DomainName = b.DomainName;
            bottleGetDTO.PeakInDate = b.PeakInDate;
            bottleGetDTO.PeakOutDate = b.PeakOutDate;
            bottleGetDTO.GrapeVariety = b.GrapeVariety;
            bottleGetDTO.Tava = b.Tava;
            bottleGetDTO.Capacity = b.Capacity;
            bottleGetDTO.WineMakerName = b.WineMakerName;
            bottleGetDTO.VintageName = b.VintageName;
            bottleGetDTO.Aroma = b.Aroma;
            bottleGetDTO.Price = b.Price;
            bottleGetDTO.PurchaseDate = b.PurchaseDate;
            bottleGetDTO.RelatedMeals = b.RelatedMeals;
            bottleGetDTO.DrawerPosition = b.DrawerPosition;
            //           bottleGetDTO.Drawer = b.Drawer
            bottleGetDTO.DrawerId = b.DrawerId;

            return Ok(bottleGetDTO);
        }
        #endregion


        // region pour vérifier l'existence d'une bouteille et créer la nouvelle s'il n'existe pas.
        #region 
        [HttpPost]

        public async Task<IActionResult> CreateBottles([FromBody] BottlePostDTO bottletopost)
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


            if (IsBottleExistingForDrawerIdAndDrawerPosition(bottletopost.DrawerId, bottletopost.DrawerPosition))
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


           await _bottleRepository.CreateNewBottleAsync(bottle);


            return Created($"bottle/{bottle.Id}", bottle);
         
        }
   
        private bool IsBottleExistingForDrawerIdAndDrawerPosition(int drawerId, int? drawerPosition)
        {
            Bottle? bottle = this._bottleRepository.GetBottleByDrawerIdAndDrawerPosition(drawerId, drawerPosition);

           return bottle != null;
        }

        #endregion

        //region pour gerer la modification d'une bouteille ( aka Modify bottles)
        #region
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


            if(IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItself(bottletoput)) 
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

        private bool IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItself(BottlePutDTO bottletoput)
        {

            Bottle? bottle = this._bottleRepository.GetBottleByDrawerIdAndDrawerPosition(bottletoput.DrawerId, bottletoput.DrawerPosition);

            return !((bottle != null) && (bottle.Id == bottletoput.Id));
        
        }

        #endregion

        //Region pour gérer la suppression des données
        #region
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBottles([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();

            Bottle bottle = await _bottleRepository.GetByIdAsync(id);
            await _bottleRepository.DeleteBottleAsync(id);

            return Ok(bottle);

        }
        #endregion
    }
}


