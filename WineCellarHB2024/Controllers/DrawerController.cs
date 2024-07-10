using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_drawerRepository.GetAll());
        }

    }
}
