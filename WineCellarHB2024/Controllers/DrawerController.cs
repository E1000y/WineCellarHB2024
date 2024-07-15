using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrawerController(IDrawerRepository _drawerRepository, IDrawerBusiness drawerBusiness) : ControllerBase
    {


        [Authorize]
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            List<Drawer> drawers = await _drawerRepository.GetAllAsync();
            List<DrawerGetDTO> drawerGetDTOList = new List<DrawerGetDTO>();

            foreach (Drawer drawer in drawers)
            {
                DrawerGetDTO drawerGetDTO = new DrawerGetDTO();

                drawerGetDTO.Id = drawer.Id;
                drawerGetDTO.Number = drawer.Number;
                drawerGetDTO.NbOfBottlesPerDrawer = drawer.NbOfBottlesPerDrawer;
                drawerGetDTO.CellarId = drawer.CellarId;
                drawerGetDTOList.Add(drawerGetDTO);

            }

            return Ok(drawerGetDTOList);
        }


        // Région pour la récupération des tiroirs par  l'Id (aka Get All Drawers by Id)
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var drawer = await _drawerRepository.GetByIdAsync(id);
            DrawerGetDTO drawerGetDTO = new DrawerGetDTO();

            drawerGetDTO.Id = drawer.Id;
            drawerGetDTO.Number = drawer.Number;
            drawerGetDTO.NbOfBottlesPerDrawer = drawer.NbOfBottlesPerDrawer;
            drawerGetDTO.CellarId = drawer.CellarId;

            return Ok(drawerGetDTO);
        }


        //Région pour la création des tiroirs (aka Create Drawers)
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> CreateDrawer([FromBody] DrawerPostDTO drawerPostDTO)
        {
            if (drawerPostDTO == null) { return BadRequest(); }

            //faire en sorte que le drawer ne puisse pas avoir le même numéro qu'un autre drawer pour un même cellarId

            //get dans le cellar, le drawer avec le cellarid


            List<Drawer> drawers = await _drawerRepository.GetByCellarIdAsync(drawerPostDTO.CellarId);

            // maintenant, vérifier qu'aucun drawer n'a le même numéro 

            if(drawerBusiness.CheckNoDrawerHasSameNumberThanInDrawerPostDTO(drawerPostDTO, drawers)) {return  BadRequest("another drawer has the same number in this cellar"); };
           

            Drawer drawer = new Drawer();
            drawer.Number = drawerPostDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPostDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPostDTO.CellarId;

            await _drawerRepository.CreateAsync(drawer);
            return Created($"drawer/{drawer.Id}", drawer);
        }

        private bool CheckNoDrawerHasSameNumberThanInDrawerPostDTO(DrawerPostDTO drawerPostDTO, List<Drawer> drawers)
        {
           bool flag = false;
            foreach (Drawer drawer in drawers)
            {
                if (drawer.Number == drawerPostDTO.Number) { flag = true; break; }
            }

            return flag;
            

        }

        // Région pour la modification des tiroirs ( aka ModifyDrawers)

        [Authorize]
        [HttpPut("{id}")]

        public async Task<IActionResult> ModifyDrawer([FromRoute] int id, [FromBody] DrawerPutDTO drawerPutDTO)
        {
            if (drawerPutDTO == null || (drawerPutDTO.Id != id))
            {
                return BadRequest();
            }
            
           
            if(!drawerBusiness.IsTrueWhenDrawerWithCellarIdAndNumberExistsAsync(drawerPutDTO))
            {
                return BadRequest("a drawer exists in this position");
            };




            Drawer drawer = new Drawer();

            drawer.Id = drawerPutDTO.Id;
            drawer.Number = drawerPutDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPutDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPutDTO.CellarId;

            await _drawerRepository.UpdateAsync(drawer);

            return NoContent();

        }


        //Région pour la suppression des tiroirs ( aka DeleteDrawers)
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDrawer([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Drawer drawer = await _drawerRepository.GetByIdAsync(id);
           await _drawerRepository.DeleteAsync(id);

            return Ok(drawer);
        }

    }
}
