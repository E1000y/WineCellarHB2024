using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WineCellarHB2024.DTOs;
using Models;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrawerController : ControllerBase
    {

        private readonly IDrawerRepository _drawerRepository;

        public DrawerController(IDrawerRepository drawerrepo)
        {
            _drawerRepository = drawerrepo;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Drawer> drawers = this._drawerRepository.GetAll();
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

            var drawer = this._drawerRepository.GetById(id);
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


            List<Drawer> drawers = this._drawerRepository.GetByCellarId(drawerPostDTO.CellarId);
           
            // maintenant, vérifier qu'aucun drawer n'a le même numéro 

            if(CheckNoDrawerHasSameNumberThanInDrawerPostDTO(drawerPostDTO, drawers)) {return  BadRequest("another drawer has the same number in this cellar"); };
           

            Drawer drawer = new Drawer();
            drawer.Number = drawerPostDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPostDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPostDTO.CellarId;

            this._drawerRepository.Create(drawer);
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

        [HttpPut("{id}")]

        public IActionResult ModifyDrawer([FromRoute] int id, [FromBody] DrawerPutDTO drawerPutDTO)
        {
            if (drawerPutDTO == null || (drawerPutDTO.Id != id))
            {
                return BadRequest();
            }
            
           
            if(IsTrueWhenDrawerWithCellarIdAndNumberExists(drawerPutDTO))
            {
                return BadRequest("a drawer exists in this position");
            };




            Drawer drawer = new Drawer();

            drawer.Id = drawerPutDTO.Id;
            drawer.Number = drawerPutDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPutDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPutDTO.CellarId;

            this._drawerRepository.Create(drawer);

            return NoContent();

        }

        private bool IsTrueWhenDrawerWithCellarIdAndNumberExists(DrawerPutDTO drawerPutDto)
        {
            Drawer drawer = this._drawerRepository.GetByCellarIdAndNumber(drawerPutDto.CellarId, drawerPutDto.Number);

            return !((drawer != null)&& (drawerPutDto.Id != drawer.Id));
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteDrawer([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Drawer drawer = this._drawerRepository.GetById(id);
            this._drawerRepository.Delete(id);

            return Ok(drawer);
        }
    }
}
