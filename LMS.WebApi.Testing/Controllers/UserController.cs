using LMS.Classes;
using LMS.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IBookManager _bookManager;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserManager userManager, IBookManager bookManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _bookManager = bookManager;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Create([FromBody] UserInfo user)
        {
            try
            {
                if (_bookManager.IsBookAval(user.bookID))
                {
                    UserInfo newUser = _userManager.CreateUser(user);
                    _bookManager.DecreaseCopies(newUser.bookID);
                    return Ok(newUser);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                UserInfo user = _userManager.GetUsersList().FirstOrDefault(x => x.id == id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            try
            {
                _userManager.RemoveUserById(id);
                return Ok("Removed!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(UserInfo user)
        {
            try
            {
                UserInfo newUser=_userManager.UpdateUser(user);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
    }
}
