﻿using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WineCellarHB2024.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class BottleController(IBottleRepository _bottleRepository,IBottleBusiness bottlebusiness) : ControllerBase
    {

        [Authorize]
        [HttpGet]

        public async Task<IActionResult> GetBottles()
        {
        
            List<Bottle> bottles = await _bottleRepository.GetAllAsync();
            List<BottleGetDTO> bottleGetDTOList= new List<BottleGetDTO>();
            foreach( Bottle b in bottles)
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



        // region pour gerer la récupération d'une bouteille par l'ID (aka Get Bottles)
        #region
        [Authorize]
        [HttpGet(("{id}"))]
        public async Task<IActionResult> GetBottlesAsync(int id)
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

        [HttpGet("Apogee")]
        public async Task<IActionResult> GetBottlesWithinPeak()
        {
            List<Bottle> bottleswithinpeak = await _bottleRepository.GetBottleWithinPeakAsync();


            List<BottleGetDTO> bottlesWPeak = new List<BottleGetDTO>();

            foreach (var bottle in bottleswithinpeak)
            {
                BottleGetDTO b = new BottleGetDTO();
                b.Id = bottle.Id;
                b.Color = bottle.Color;
                b.Name = bottle.Name;
                b.FullName = bottle.FullName;
                b.VintageYear = bottle.VintageYear;
                b.YearsOfKeep = bottle.YearsOfKeep;
                b.DomainName = bottle.DomainName;
                b.PeakInDate = bottle.PeakInDate;
                b.PeakOutDate = bottle.PeakOutDate;
                b.GrapeVariety = bottle.GrapeVariety;
                b.Tava = bottle.Tava;
                b.Capacity = bottle.Capacity;
                b.WineMakerName = bottle.WineMakerName;
                b.VintageName = bottle.VintageName;
                b.Aroma = bottle.Aroma;
                b.Price = bottle.Price;
                b.PurchaseDate = bottle.PurchaseDate;
                b.RelatedMeals = bottle.RelatedMeals;
                b.DrawerPosition = bottle.DrawerPosition;
                b.DrawerId = bottle.DrawerId;
               
                bottlesWPeak.Add(b);
            }
            
          


            return Ok(bottlesWPeak);

        }


        #endregion


        // region pour vérifier l'existence d'une bouteille et créer la nouvelle s'il n'existe pas.
        #region 
        [Authorize]
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


            if (await bottlebusiness.IsBottleExistingForDrawerIdAndDrawerPositionAsync(bottletopost.DrawerId, bottletopost.DrawerPosition))
            {
                return BadRequest("There already is a bottle in this drawerId and drawerPosition.");
            }

            if (await bottlebusiness.IsDrawerBigEnoughAsync(bottletopost))
            {

                return BadRequest("DrawerPosition invalid.");
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

            BottlePostDTO bottlePostDTO = new BottlePostDTO();
            bottlePostDTO.Color = bottle.Color;
            bottlePostDTO.Name = bottle.Name;
            bottlePostDTO.FullName = bottle.FullName;
            bottlePostDTO.VintageYear = bottle.VintageYear;
            bottlePostDTO.YearsOfKeep = bottle.YearsOfKeep;
            bottlePostDTO.DomainName = bottle.DomainName;
            bottlePostDTO.PeakInDate = bottle.PeakInDate;
            bottlePostDTO.PeakOutDate = bottle.PeakOutDate;
            bottlePostDTO.GrapeVariety = bottle.GrapeVariety;
            bottlePostDTO.Tava = bottle.Tava;
            bottlePostDTO.Capacity = bottle.Capacity;
            bottlePostDTO.WineMakerName = bottle.WineMakerName;
            bottlePostDTO.VintageName = bottle.VintageName;
            bottlePostDTO.Aroma = bottle.Aroma;
            bottlePostDTO.Price = bottle.Price;
            bottlePostDTO.PurchaseDate = bottle.PurchaseDate;
            bottlePostDTO.RelatedMeals = bottle.RelatedMeals;
            bottlePostDTO.DrawerPosition = bottle.DrawerPosition;
            bottlePostDTO.DrawerId = bottle.DrawerId;


            return Created($"bottle/{bottle.Id}", bottlePostDTO);
         
        }



        #endregion

        //region pour gerer la modification d'une bouteille ( aka Modify bottles)
        #region
        [Authorize]
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


            if (await bottlebusiness.IsBottleExistingForDrawerIdAndDrawerPositionAndIsNotItselfAsync(bottletoput)) 
                {
                
                    return BadRequest("There already is a bottle in this drawerId and drawerPosition.");
                }

            if (await bottlebusiness.IsDrawerBigEnoughAsync(bottletoput))
            {

                return BadRequest("DrawerPosition invalid.");
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



        #endregion

        //Region pour gérer la suppression des données
        #region
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBottles([FromRoute] int id)
        {
            if (id <= 0)
               
                return BadRequest();

            Bottle bottle = await _bottleRepository.GetByIdAsync(id);
            await _bottleRepository.DeleteBottleAsync(id);

            return Ok(bottle);

        }
        #endregion
        [Authorize]
        [HttpPost("DuplicateBottle/{id}")]
        public async Task<IActionResult> DuplicateBottle([FromRoute] int id,[FromBody] BottleDupDTO bottletodupe)
        {
            if (id <= 0 || bottletodupe.DrawerId <= 0)
            {
                return BadRequest();
            }
            if (await bottlebusiness.IsBottleExistingForDrawerIdAndDrawerPositionAsync(bottletodupe.DrawerId, bottletodupe.DrawerPosition))
            {
                return BadRequest("There already is a bottle in this drawerId and drawerPosition.");
            }

            var b = await _bottleRepository.GetByIdAsync(id);


            Bottle bottle = new Bottle();
            bottle.Color = b.Color;
            bottle.Name = b.Name;
            bottle.FullName = b.FullName;
            bottle.VintageYear = b.VintageYear;
            bottle.YearsOfKeep = b.YearsOfKeep;
            bottle.DomainName = b.DomainName;
            bottle.PeakInDate = b.PeakInDate;
            bottle.PeakOutDate = b.PeakOutDate;
            bottle.GrapeVariety = b.GrapeVariety;
            bottle.Tava = b.Tava;
            bottle.Capacity = b.Capacity;
            bottle.WineMakerName = b.WineMakerName;
            bottle.VintageName = b.VintageName;
            bottle.Aroma = b.Aroma;
            bottle.Price = b.Price;
            bottle.PurchaseDate = b.PurchaseDate;
            bottle.RelatedMeals = b.RelatedMeals;
            bottle.DrawerPosition = bottletodupe.DrawerPosition;
            bottle.DrawerId = bottletodupe.DrawerId;


            await _bottleRepository.CreateNewBottleAsync(bottle);


            return Created($"bottle/{bottle.Id}", bottle);
        }
    }
}


