using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic.Services.Contracts
{
    public interface IRoleService
    {
        Task EnsureRoles();
    }
}
