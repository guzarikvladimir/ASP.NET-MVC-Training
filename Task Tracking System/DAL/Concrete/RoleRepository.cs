using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return _context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            });
        }

        public async Task<DalRole> GetById(int key)
        {
            var role = await _context.Set<Role>().FirstOrDefaultAsync(r => r.Id == key);
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public IEnumerable<DalRole> Find(Func<DalRole, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole e)
        {
            throw new NotImplementedException();
        }
    }
}
