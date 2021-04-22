using GestToDo.Api.Models.Client.Entities;
using GestToDo.Api.Repositories;
using GetToDo.Api.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository<User> _repository;

        public AuthController(IAuthRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterForm form)
        {
            User user = new User(form.LastName, form.FirstName, form.Email, form.Passwd);
            if (_repository.Register(user))
                return Ok();

            return BadRequest();
        }
    }
}
