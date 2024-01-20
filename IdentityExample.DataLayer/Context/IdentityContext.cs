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
        //Design Patten SingleTon
        public Client Client { get; set; }
        public static IdentityContext current { get; } = new IdentityContext();
        public IdentityContext()
        {
            Client = new Client()
            {
                Age = 25,
                FirstName = "sadian",
                LastName = "tohidian",
                PhoneNumber = "09000000000"
            };
        }
    }
}
