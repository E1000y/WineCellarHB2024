using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using WineCellarHB2024.DTOs;

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
            List<CellarUser> users = this._userRepository.GetAll();
            List<UserGetDTO> userGetDTOList = new List<UserGetDTO>();

            foreach (CellarUser user in users)
            {
                UserGetDTO userGetDTO = new UserGetDTO();

                userGetDTO.Id = user.Id;
                userGetDTO.FirstName = user.FirstName;
                userGetDTO.LastName = user.LastName;
                userGetDTO.BirthDate = user.BirthDate;
                userGetDTO.Email = user.Email;
                userGetDTO.Password = user.Password;
                userGetDTO.PhoneNumber = user.PhoneNumber;
                userGetDTO.Address = user.Address;
                userGetDTOList.Add(userGetDTO);

            }

            return Ok(userGetDTOList);
        }



        [HttpGet(("{id}"))]

        public IActionResult GetUser(string id)
        {
            var user = this._userRepository.GetById(id);
            UserGetDTO userGetDTO = new UserGetDTO();

            userGetDTO.Id = user.Id;
            userGetDTO.FirstName = user.FirstName;
            userGetDTO.LastName = user.LastName;
            userGetDTO.BirthDate = user.BirthDate;
            userGetDTO.Email = user.Email;
            userGetDTO.Password = user.Password;
            userGetDTO.PhoneNumber = user.PhoneNumber;
            userGetDTO.Address = user.Address;

            return Ok(userGetDTO);
        }

        [HttpPost]

        public IActionResult CreateUser([FromBody] UserDTO userdto)
        {


            CellarUser user = new CellarUser();
            user.FirstName = userdto.FirstName;
            user.LastName = userdto.LastName;
            user.BirthDate = userdto.BirthDate;
            user.Email = userdto.Email;
            user.Password = userdto.Password;
            user.PhoneNumber = userdto.PhoneNumber;
            user.Address = userdto.Address;


            this._userRepository.Create(user);


            return Created($"cellaruser/{user.Id}", user);

        }

        [HttpPut("{id}")]

        public IActionResult ModifyUser([FromRoute] string id, [FromBody] UserPutDTO userpdto)
        {
            if (id == null || id != userpdto.Id)
            {
                return BadRequest();
            }

            CellarUser user = new CellarUser();
            user.Id = id;
            user.FirstName = userpdto.FirstName;
            user.LastName = userpdto.LastName;
            user.BirthDate = userpdto.BirthDate;
            user.Email = userpdto.Email;
            user.Password = userpdto.Password;
            user.PhoneNumber = userpdto.PhoneNumber;
            user.Address = userpdto.Address;

            this._userRepository.Update(user);


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser([FromRoute] string id) {

            if (id == null)
            {
                return BadRequest();
            }

            CellarUser cellaruser = _userRepository.GetById(id);

            _userRepository.Delete(id);

            return Ok(cellaruser);
        
        }
    }
}
