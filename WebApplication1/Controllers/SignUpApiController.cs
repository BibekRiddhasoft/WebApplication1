using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Manager;
using WebApplication1.Repository;
using WebApplication1.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpApiController : ControllerBase
    {

        [HttpPost]
        [Route("SignUp")]
        public ServiceResult<bool> Post(SignUp model)
        {
            var manager = new SignUpManager();
            var result = manager.AddSignUpAccountInfo(model);
            return new ServiceResult<bool>()
            {
                Data = result.Data,
                Message = result.Message,
                Status = result.Status
            };
        }

        [HttpPost]
        [Route("Login")]
        public ServiceResult<bool> Login(Login model)
        {
            var manager = new SignUpManager();
            var result = manager.Login(model);
            return new ServiceResult<bool>()
            {
                Data = result.Data,
                Message = result.Message,
                Status = result.Status
            };
        }



    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
