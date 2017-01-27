using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAllRoleEntities();
        Task<RoleEntity> GetById(int roleId);
    }
}
