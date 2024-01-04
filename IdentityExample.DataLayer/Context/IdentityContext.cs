using IdentityExample.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityExample.DataLayer.Context
{
    public class IdentityContext
    {
        public async Task<Client> GetClient()
        {
            Client client = new Client()
            {
                Age = 25,
                FirstName = "sadian",
                LastName="tohidian",
                PhoneNumber="09000000000"
            };
            return client;
        } 
    }
}
