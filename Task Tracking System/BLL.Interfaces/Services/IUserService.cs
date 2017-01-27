using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserEntity> GetUserEntity(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        UserEntity GetUserByEmail(string email);
        IEnumerable<UserEntity> SearchUsersByEmail(string email);
        IEnumerable<UserEntity> Find(Func<UserEntity, bool> f);
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        void UpdateUser(UserEntity user);
    }
}
