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
                DrawerGetDTO drawerGetDTO  = new DrawerGetDTO();

                drawerGetDTO.Id = drawer.Id;
                drawerGetDTO.Number = drawer.Number;
                drawerGetDTO.NbOfBottlesPerDrawer = drawer.NbOfBottlesPerDrawer;
                drawerGetDTOList.Add(drawerGetDTO);

            }

            return Ok(drawerGetDTOList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

              return Ok(this._drawerRepository.GetById(id));
        }

        [HttpPost]

        public IActionResult CreateDrawer([FromBody] DrawerPostDTO drawerPostDTO)
        {
            if (drawerPostDTO == null) { return BadRequest(); }

            Drawer drawer = new Drawer();
            drawer.Number = drawerPostDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPostDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPostDTO.CellarId;

            this._drawerRepository.Create(drawer);
            return Created($"drawer/{drawer.Id}", drawer);
        }

        [HttpPut("{id}")]

        public IActionResult ModifyDrawer([FromRoute] int id, [FromBody] DrawerPutDTO drawerPutDTO)
        {
            if (drawerPutDTO == null)
            {
                return BadRequest();
            }

            Drawer drawer = new Drawer();

            drawer.

    }
}
