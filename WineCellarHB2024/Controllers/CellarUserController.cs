using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]

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


        [Authorize]
        [HttpGet(("{id}"))]

        public async Task<IActionResult> GetUser(string id)
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




        [Authorize]
        [HttpPut("{id}")]

        public async Task<IActionResult> ModifyUserAsync([FromRoute] string id, [FromBody] UserPutDTO userpdto)
        {
            if (id == null || !(id.Equals(userpdto.Id)))
            {
                return BadRequest();
            }

            CellarUser user = new CellarUser();
            user.Id = userpdto.Id;
            user.FirstName = userpdto.FirstName;
            user.LastName = userpdto.LastName;
            user.BirthDate = userpdto.BirthDate;
            user.Address = userpdto.Address;

            await this._userRepository.UpdateAsync(user);


            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] string id) {

            if (id == null)
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
