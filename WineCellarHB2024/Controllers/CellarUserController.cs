using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;

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

        public async Task<IActionResult> GetUsers()
        {
            List<CellarUser> users = await this._userRepository.GetAllAsync();
            List<UserGetDTO> userGetDTOList = new List<UserGetDTO>();

            foreach (CellarUser user in users)
            {
                UserGetDTO userGetDTO = new UserGetDTO();

                userGetDTO.Id = user.Id;
                userGetDTO.FirstName = user.FirstName;
                userGetDTO.LastName = user.LastName;
                userGetDTO.BirthDate = user.BirthDate;

                userGetDTO.Address = user.Address;
                userGetDTOList.Add(userGetDTO);

            }

            return Ok(userGetDTOList);
        }



        [HttpGet(("{id}"))]

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this._userRepository.GetByIdAsync(id);
            UserGetDTO userGetDTO = new UserGetDTO();

            userGetDTO.Id = user.Id;
            userGetDTO.FirstName = user.FirstName;
            userGetDTO.LastName = user.LastName;
            userGetDTO.BirthDate = user.BirthDate;
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

        public IActionResult ModifyUser([FromRoute] int id, [FromBody] UserPutDTO userpdto)
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
            user.Address = userpdto.Address;

            await this._userRepository.UpdateAsync(user);


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser([FromRoute] int id) {

            if (id <= 0)
            {
                return BadRequest();
            }

            CellarUser cellaruser = await _userRepository.GetByIdAsync(id);

            _userRepository.DeleteAsync(id);
            await _userRepository.DeleteAsync(id);

            return Ok(cellaruser);
        
        }
    }
}
