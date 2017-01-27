using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
//using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository repository)
        {
            _roleRepository = repository;
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return _roleRepository.GetAll().Select(role => new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        public async Task<RoleEntity> GetById(int roleId)
        {
            var role = await _roleRepository.GetById(roleId);
            return new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
