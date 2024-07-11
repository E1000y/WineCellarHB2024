using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using WineCellarHB2024.DTOs;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CellarController(ICellarRepository cellarRepository, ILogger<CellarController> logger, UserManager<CellarUser> userManager) : ControllerBase
    {

        //private readonly ICellarRepository cellarRepository;

        //public CellarController(ICellarRepository cellarrepo)
       // {
            //cellarRepository = cellarrepo;
       // }

        [HttpGet]

        public async Task< IActionResult> GetCellars()
        {

            List<Cellar> cellars =  await cellarRepository.GetAllAsync();
            List<CellarGetDTO> cellarGetDTOList = new List<CellarGetDTO>();

            foreach (Cellar cellar in cellars)
            {
                CellarGetDTO cellarGetDTO = new CellarGetDTO();

                cellarGetDTO.Id = cellar.Id;
                cellarGetDTO.Name = cellar.Name;
                cellarGetDTO.Family = cellar.Family;
                cellarGetDTO.Manufacturer = cellar.Manufacturer;
                cellarGetDTO.Temperature = cellar.Temperature;
                cellarGetDTO.CellarUserId = cellar.CellarUserId;
                cellarGetDTOList.Add(cellarGetDTO);
            }

            return Ok(cellarGetDTOList);
        }



        [HttpGet(("{id}"))]

        public IActionResult GetCellar(int id)
        {
            var cellar = cellarRepository.GetById(id);
            CellarGetDTO cellarGetDTO = new CellarGetDTO();

            cellarGetDTO.Id = cellar.Id;
            cellarGetDTO.Name = cellar.Name;
            cellarGetDTO.Family = cellar.Family;
            cellarGetDTO.Manufacturer = cellar.Manufacturer;
            cellarGetDTO.Temperature = cellar.Temperature;
            cellarGetDTO.CellarUserId = cellar.CellarUserId;

            return Ok(cellarGetDTO);
        }

        [HttpPost]

        public IActionResult CreateCellar([FromBody] CellarDTO cellardto)
        {


            Cellar cellar = new Cellar();
            cellar.Name = cellardto.Name;
            cellar.Family = cellardto.Family;
            cellar.Manufacturer = cellardto.Manufacturer;
            cellar.Temperature = cellardto.Temperature;
            cellar.CellarUserId = cellardto.CellarUserId;


            cellarRepository.Create(cellar);


            return Created($"cellar/{cellar.Id}", cellar);

        }

        [HttpPut("{id}")]

        public IActionResult ModifyCellar([FromRoute] int id, [FromBody] CellarPutDTO cellarpdto)
        {
            if (id <= 0 || id != cellarpdto.Id)
            {
                return BadRequest();
            }

            Cellar cellar = new Cellar();
            cellar.Id = id;
            cellar.Name = cellarpdto.Name;
            cellar.Family = cellarpdto.Family;
            cellar.Manufacturer = cellarpdto.Manufacturer;
            cellar.Temperature = cellarpdto.Temperature;
            cellar.CellarUserId = cellarpdto.CellarUserId;


           cellarRepository.Update(cellar);


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteCellar([FromRoute] int id)
        {

            if (id <= 0)
                return BadRequest();
            Cellar cellar = cellarRepository.GetById(id);
            cellarRepository.Delete(id);

            return Ok(cellar);

        }
    }
}
