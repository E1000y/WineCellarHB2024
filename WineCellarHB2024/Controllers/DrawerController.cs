using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
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
        //Région pour la récupération des tiroirs (aka Get All Drawers)
        #region
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            List<Drawer> drawers = await this._drawerRepository.GetAllAsync();
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
        #endregion

        // Région pour la récupération des tiroirs par  l'Id (aka Get All Drawers by Id)
        #region
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var drawer = await this._drawerRepository.GetByIdAsync(id);
            DrawerGetDTO drawerGetDTO = new DrawerGetDTO();

            drawerGetDTO.Id = drawer.Id;
            drawerGetDTO.Number = drawer.Number;
            drawerGetDTO.NbOfBottlesPerDrawer = drawer.NbOfBottlesPerDrawer;
            drawerGetDTO.CellarId = drawer.CellarId;

            return Ok(drawerGetDTO);
        }
        #endregion

        //Région pour la création des tiroirs (aka Create Drawers)
        #region
        [HttpPost]

        public async Task<IActionResult> CreateDrawer([FromBody] DrawerPostDTO drawerPostDTO)
        {
            if (drawerPostDTO == null) { return BadRequest(); }

            //faire en sorte que le drawer ne puisse pas avoir le même numéro qu'un autre drawer pour un même cellarId

            //get dans le cellar, le drawer avec le cellarid


            List<Drawer> drawers = await this._drawerRepository.GetByCellarIdAsync(drawerPostDTO.CellarId);

            // maintenant, vérifier qu'aucun drawer n'a le même numéro 

            if (CheckNoDrawerHasSameNumberThanInDrawerPostDTO(drawerPostDTO, drawers)) { return BadRequest("another drawer has the same number in this cellar"); };


            Drawer drawer = new Drawer();
            drawer.Number = drawerPostDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPostDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPostDTO.CellarId;

            await this._drawerRepository.CreateAsync(drawer);
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
        #endregion

        // Région pour la modification des tiroirs ( aka ModifyDrawers)
        #region

        [HttpPut("{id}")]

        public async Task<IActionResult> ModifyDrawer([FromRoute] int id, [FromBody] DrawerPutDTO drawerPutDTO)
        {
            if (drawerPutDTO == null || (drawerPutDTO.Id != id))
            {
                return BadRequest();
            }


           // if (IsTrueWhenDrawerWithCellarIdAndNumberExists(drawerPutDTO))
           // {
               // return BadRequest("a drawer exists in this position");
            //};




            Drawer drawer = new Drawer();

            drawer.Id = drawerPutDTO.Id;
            drawer.Number = drawerPutDTO.Number;
            drawer.NbOfBottlesPerDrawer = drawerPutDTO.NbOfBottlesPerDrawer;
            drawer.CellarId = drawerPutDTO.CellarId;

            await this._drawerRepository.UpdateAsync(drawer);

            return NoContent();

        }

        private async Task<bool> IsTrueWhenDrawerWithCellarIdAndNumberExists(DrawerPutDTO drawerPutDto)
        {
            Drawer drawer =  await this._drawerRepository.GetByCellarIdAndNumberAsync(drawerPutDto.CellarId, drawerPutDto.Number);

            return !((drawer != null) && (drawerPutDto.Id != drawer.Id));
        }
        #endregion

        //Région pour la suppression des tiroirs ( aka DeleteDrawers)
        #region
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
        #endregion
    }
}
