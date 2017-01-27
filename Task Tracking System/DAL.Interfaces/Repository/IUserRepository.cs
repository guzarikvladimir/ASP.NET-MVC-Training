using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        IEnumerable<DalUser> SearchUsersByEmail(string email);
    }
}
