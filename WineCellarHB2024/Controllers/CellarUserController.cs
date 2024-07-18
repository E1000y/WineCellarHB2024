using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;

namespace WineCellarHB2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CellarUserController(IUserRepository _userRepository, UserManager<CellarUser> _userManager) : ControllerBase
    {

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetUsers()
        {
            List<CellarUser> users = await _userRepository.GetAllAsync();
            List<UserGetDTO> userGetDTOList = new List<UserGetDTO>();

            foreach (CellarUser user in users)
            {
                UserGetDTO userGetDTO = new UserGetDTO();

                //userGetDTO.Id = user.Id;
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
            var user = await _userRepository.GetByIdAsync(id);
            UserGetDTO userGetDTO = new UserGetDTO();

            //userGetDTO.Id = user.Id;
            userGetDTO.FirstName = user.FirstName;
            userGetDTO.LastName = user.LastName;
            userGetDTO.BirthDate = user.BirthDate;
            userGetDTO.Address = user.Address;

            return Ok(userGetDTO);
        }




        [Authorize]
        [HttpPut]

        public async Task<IActionResult> ModifyUser([FromBody] UserPutDTO userpdto)
        {

            CellarUser user = new CellarUser();
            user.Id = _userManager.GetUserId(User);
            user.FirstName = userpdto.FirstName;
            user.LastName = userpdto.LastName;
            user.BirthDate = userpdto.BirthDate;
            user.Address = userpdto.Address;

            await _userRepository.UpdateAsync(user);


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

            await _userRepository.DeleteChainBotAsync(id);
            await _userRepository.DeleteChainDrawAsync(id);
            await _userRepository.DeleteChainCelAsync(id);
            await _userRepository.DeleteAsync(id);


            return Ok(cellaruser);
        
        }
    }
}
