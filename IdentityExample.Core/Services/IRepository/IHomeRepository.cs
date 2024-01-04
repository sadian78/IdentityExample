using IdentityExample.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityExample.Core.Services.IRepository
{
    public interface IHomeRepository
    {
        Task<InformationClient> GetInformationClient(LoginViewModel model);
    }
}
