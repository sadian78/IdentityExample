using IdentityExample.Core.DTOs;
using IdentityExample.Core.Services.IRepository;
using IdentityExample.Core.Utilities;
using IdentityExample.DataLayer.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityExample.Core.Services.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly IConfiguration _configuration;
        public HomeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<InformationClient> GetInformationClient(LoginViewModel model)
        {
            InformationClient informationClient = null;
            var email = _configuration.GetSection("LoginSadian:Email").Value;
            var password = _configuration.GetSection("LoginSadian:Passwoed").Value;

            if (FixText.FixEmail(model.EmailAddress)== email && model.PassWord == password)
            {
                informationClient = new InformationClient();
                //Use Context (With Design Pattern SingleTon)
                var client = IdentityContext.current.Client;
                informationClient.Age = client.Age;
                informationClient.FirstName = client.FirstName;
                informationClient.LastName = client.LastName;
                informationClient.PhoneNumber = client.PhoneNumber;
                informationClient.Token = Guid.NewGuid().ToString();
            }

            return informationClient;
        }
    }
}
