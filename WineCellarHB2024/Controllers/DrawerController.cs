using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrawerController(IDrawerRepository _drawerRepository, IDrawerBusiness drawerBusiness) : ControllerBase
    {

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Drawer> drawers = _drawerRepository.GetAll();
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var drawer = _drawerRepository.GetById(id);
            DrawerGetDTO drawerGetDTO = new DrawerGetDTO();

            drawerGetDTO.Id = drawer.Id;
            drawerGetDTO.Number = drawer.Number;
            drawerGetDTO.NbOfBottlesPerDrawer = drawer.NbOfBottlesPerDrawer;
            drawerGetDTO.CellarId= drawer.CellarId;

            return Ok(drawerGetDTO);
        }

        [HttpPost]

        public IActionResult CreateDrawer([FromBody] DrawerPostDTO drawerPostDTO)
        {
            if (drawerPostDTO == null) { return BadRequest(); }

            //faire en sorte que le drawer ne puisse pas avoir le même numéro qu'un autre drawer pour un même cellarId

            //get dans le cellar, le drawer avec le cellarid


            List<Drawer> drawers = _drawerRepository.GetByCellarId(drawerPostDTO.CellarId);
           
            // maintenant, vérifier qu'aucun drawer n'a le même numéro 

            if(drawerBusiness.CheckNoDrawerHasSameNumberThanInDrawerPostDTO(drawerPostDTO, drawers)) {return  BadRequest("another drawer has the same number in this cellar"); };
           

            Drawer drawer = new Drawer();
            drawer.Number = drawerPostDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPostDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPostDTO.CellarId;

            _drawerRepository.Create(drawer);
            return Created($"drawer/{drawer.Id}", drawer);
        }

       

        [HttpPut("{id}")]

        public IActionResult ModifyDrawer([FromRoute] int id, [FromBody] DrawerPutDTO drawerPutDTO)
        {
            if (drawerPutDTO == null || (drawerPutDTO.Id != id))
            {
                return BadRequest();
            }
            
           
            if(!drawerBusiness.IsTrueWhenDrawerWithCellarIdAndNumberExists(drawerPutDTO))
            {
                return BadRequest("a drawer exists in this position");
            };




            Drawer drawer = new Drawer();

            drawer.Id = drawerPutDTO.Id;
            drawer.Number = drawerPutDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPutDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPutDTO.CellarId;

            _drawerRepository.Update(drawer);

            return NoContent();

        }

       
        [HttpDelete("{id}")]

        public IActionResult DeleteDrawer([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Drawer drawer = _drawerRepository.GetById(id);
            _drawerRepository.Delete(id);

            return Ok(drawer);
        }
    }
}
