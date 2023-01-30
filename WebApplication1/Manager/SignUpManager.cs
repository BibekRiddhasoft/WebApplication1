using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Repository;
using WebApplication1.Service;

namespace WebApplication1.Manager
{
    public class SignUpManager : IDisposable
    {
        public void Dispose()
        {
            
        }

        public ServiceResult<bool> AddSignUpAccountInfo(SignUp model)
        {
            using(var factory = new ServiceFactory())
            {
                var service = new SignUpService(factory);
                var result = service.AddSignUpAccountInfo(model);
                return new ServiceResult<bool>()
                {
                    Data = result,
                    Message = "Added Successfully",
                    Status = ResultStatus.Ok
                };
            }
        }

        public ServiceResult<bool> Login(Login model)
        {
            using(var factory = new ServiceFactory())
            {
                var service = new SignUpService(factory);
                var result = service.ValidateUserLogin(model);
                return new ServiceResult<bool>()
                {
                    Data = result,
                    Message = result == true ? "valid" : "Invalid credential",
                    Status = result == true ? ResultStatus.Ok : ResultStatus.processError
                };
            }
        }
    }
}
