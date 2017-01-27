using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
//using BLL.Mappers;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            _uow = uow;
            _userRepository = repository;
        }

        public async Task<UserEntity> GetUserEntity(int id)
        {
            var user = await _userRepository.GetById(id);
            return new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                RoleName = user.RoleName,
                Tasks = user.Tasks.Select(t => new TaskEntity()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDateTime = t.CreationDateTime,
                    DeadlineDate = t.DeadlineDate,
                    DeadlineTime = t.DeadlineTime,
                    TotalPoints = t.TotalPoints,
                    PointsCompleted = t.PointsCompleted,
                    StatusId = t.StatusId,
                    StatusName = t.StatusName
                }).ToList()
            };
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return _userRepository.GetAll().Select(user => new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                RoleName = user.RoleName,
                Tasks = user.Tasks.Select(t => new TaskEntity()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDateTime = t.CreationDateTime,
                    DeadlineDate = t.DeadlineDate,
                    DeadlineTime = t.DeadlineTime,
                    TotalPoints = t.TotalPoints,
                    PointsCompleted = t.PointsCompleted,
                    StatusId = t.StatusId,
                    StatusName = t.StatusName
                }).ToList()
            });
        }

        public UserEntity GetUserByEmail(string email)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == email);
            return user == null ? null : new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId,
                RoleName = user.RoleName,
                Tasks = user.Tasks.Select(t => new TaskEntity()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDateTime = t.CreationDateTime,
                    DeadlineDate = t.DeadlineDate,
                    DeadlineTime = t.DeadlineTime,
                    TotalPoints = t.TotalPoints,
                    PointsCompleted = t.PointsCompleted,
                    StatusId = t.StatusId,
                    StatusName = t.StatusName
                }).ToList()
            };
        }

        public IEnumerable<UserEntity> SearchUsersByEmail(string email)
        {
            return _userRepository.SearchUsersByEmail(email).Select(u => new UserEntity()
            {
                Email = u.Email
            });
        }

        public IEnumerable<UserEntity> Find(Func<UserEntity, bool> f)
        {
            throw new NotImplementedException();
            //Mapper.Initialize(cfg => cfg.CreateMap<Func<UserEntity, bool>, Func<DalUser, bool>>());
            //Mapper.Initialize(cfg => cfg.CreateMap<UserEntity, DalUser>());

            //Func<DalUser, bool> func = Mapper.Map<Func<UserEntity, bool>, Func<DalUser, bool>>(f);
            //return Mapper.Map<IEnumerable<DalUser>, IEnumerable<UserEntity>>(_userRepository.Find(func));
        }

        public void CreateUser(UserEntity user)
        {
            _userRepository.Create(new DalUser()
            {
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId
            });
            _uow.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            _userRepository.Delete(new DalUser()
            {
                Id = user.Id
            });
            _uow.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            _userRepository.Update(new DalUser()
            {
                Id = user.Id,
                RoleId = user.RoleId
            });
            _uow.Commit();
        }
    }
}
