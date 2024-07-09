using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CellarUserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public CellarUserController(IUserRepository userrepo)
        {
            _userRepository = userrepo;
        }



        [HttpGet]

        public IActionResult GetUsers()
        {
            return Ok(this._userRepository.GetAll());
        }


    }
}
