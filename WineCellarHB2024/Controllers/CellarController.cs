using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using WineCellarHB2024.DTOs;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CellarController : ControllerBase
    {
        private readonly ICellarRepository cellarRepository;

        public CellarController(ICellarRepository cellarrepo)
        {
            cellarRepository = cellarrepo;
        }



        [HttpGet]

        public IActionResult GetCellars()
        {
            return Ok(this.cellarRepository.GetAll());
        }



        [HttpGet(("{id}"))]

        public IActionResult GetCellar(int id)
        {
            return Ok(this.cellarRepository.GetById(id));
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


            this.cellarRepository.Create(cellar);


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


            this.cellarRepository.Update(cellar);


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteCellar([FromRoute] int id)
        {

            if (id <= 0)
                return BadRequest();

            cellarRepository.Delete(id);

            return Ok();

        }
    }
}
