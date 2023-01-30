using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Repository;

namespace WebApplication1.Service
{
    public class SignUpService
    {
        private ServiceFactory factory { get; set; }

        public SignUpService(ServiceFactory factory)
        {
            this.factory = factory;
        }

        public bool AddSignUpAccountInfo(SignUp model)
        {
            var accInfo = factory.GetInstance<SignUp>();
            var signUPInfo = new SignUp()
            {
                Address = model.Address,
                Email = model.Email,
                Password = model.Password,
                Name = model.Name
            };
            var signUp = factory.GetInstance<SignUp>().Add(signUPInfo);
            return true;

        }

        public bool ValidateUserLogin(Login model)
        {
            var validInfo = factory.GetInstance<SignUp>().List().Where(x => x.Email.ToLower() == model.Email.ToLower() && x.Password == model.Password).Any();
            return validInfo;
        }
    }
}
