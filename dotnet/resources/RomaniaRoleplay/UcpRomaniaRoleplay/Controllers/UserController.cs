using BusinessLogic.Users;
using Helper.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UcpRomaniaRoleplay.Models.Users;

namespace UcpRomaniaRoleplay.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UsersWorker _usersWorker;

        public UserController()
        {
            _usersWorker = new UsersWorker();
        }

        [HttpPost("[action]")]
        public void Register([FromBody] RegisterViewModel registerModel)
        {
            var existsUser = _usersWorker.ExistsUser(registerModel.Username);
            if (existsUser)
            {
                //Do something
            }
            else
            {
                var encryptedPass = EncryptHelper.ComputeSha512Hash(registerModel.Password);
                _usersWorker.Create(registerModel.Username, registerModel.Email, encryptedPass);
            }
        }
    }
}
