using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using ORM;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId.Value,
                RoleName = user.Role.Name,
                Tasks = (from ut in user.UserTasks where ut.UserId == user.Id select ut.Task).Select(t => new DalTask()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDateTime = t.CreationDateTime,
                    DeadlineDate = t.DeadlineDate,
                    DeadlineTime = t.DeadlineTime,
                    TotalPoints = t.TotalPoints,
                    PointsCompleted = t.UserTasks.FirstOrDefault(task => task.TaskId == t.Id && task.UserId == user.Id).PointsCompleted,
                    StatusId = t.UserTasks.FirstOrDefault(task => task.TaskId == t.Id && task.UserId == user.Id).StatusId.Value,
                    StatusName = t.UserTasks.FirstOrDefault(task => task.TaskId == t.Id && task.UserId == user.Id).Status.Name
                }).ToList()
            });
        }

        public async System.Threading.Tasks.Task<DalUser> GetById(int key)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == key);
            var tasks = (from ut in user.UserTasks where ut.UserId == user.Id select ut.Task).ToList();
            return new DalUser()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                RoleId = user.RoleId.Value,
                RoleName = user.Role.Name,
                Tasks = tasks.Select(t => new DalTask()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreationDateTime = t.CreationDateTime,
                    DeadlineDate = t.DeadlineDate,
                    DeadlineTime = t.DeadlineTime,
                    TotalPoints = t.TotalPoints,
                    PointsCompleted = t.UserTasks.FirstOrDefault(task => task.TaskId == t.Id && task.UserId == user.Id).PointsCompleted,
                    StatusId = t.UserTasks.FirstOrDefault(task => task.TaskId == t.Id && task.UserId == user.Id).StatusId.Value,
                    StatusName = t.UserTasks.FirstOrDefault(task => task.TaskId == t.Id && task.UserId == user.Id).Status.Name
                }).ToList()
            };
        }

        public IEnumerable<DalUser> Find(Func<DalUser, bool> f)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Func<DalUser, bool>, Func<User, bool>>());
            Mapper.Initialize(cfg => cfg.CreateMap<User, DalUser>());

            Func<User, bool> func = Mapper.Map<Func<DalUser, bool>, Func<User, bool>>(f);
            return Mapper.Map<IEnumerable<User>, IEnumerable<DalUser>>(_context.Set<User>().Where(func));
        }

        public void Create(DalUser e)
        {
            var user = new User()
            {
                Email = e.Email,
                Password = e.Password,
                CreationDate = e.CreationDate,
                RoleId = e.RoleId
            };
            _context.Set<User>().Add(user);
        }

        public void Delete(DalUser e)
        {
            var user = _context.Set<User>().FirstOrDefault(u => u.Id == e.Id);
            _context.Set<User>().Remove(user);
        }

        public void Update(DalUser e)
        {
            var user = _context.Set<User>().FirstOrDefault(u => u.Id == e.Id);
            user.RoleId = e.RoleId;
        }

        public IEnumerable<DalUser> SearchUsersByEmail(string email)
        {
            return _context.Set<User>().Where(u => u.Email.Contains(email))
                .Select(u => new DalUser() { Email = u.Email });
        }
    }
}
