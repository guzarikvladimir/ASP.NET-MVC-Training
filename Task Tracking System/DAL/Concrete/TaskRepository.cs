using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using ORM;
using Task = ORM.Task;

namespace DAL.Concrete
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext _context;

        public TaskRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<DalTask> GetAll()
        {
            return _context.Set<Task>().Select(t => new DalTask()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreationDateTime = t.CreationDateTime,
                DeadlineDate = t.DeadlineDate,
                DeadlineTime = t.DeadlineTime,
                TotalPoints = t.TotalPoints,
                Users = (from ut in t.UserTasks where ut.TaskId == t.Id select ut.User).Select(u => new DalUser()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    CreationDate = u.CreationDate,
                    RoleId = u.RoleId.Value,
                    RoleName = u.Role.Name
                }).ToList()
            });
        }

        public async Task<DalTask> GetById(int key)
        {
            var task = await _context.Set<Task>().FirstOrDefaultAsync(t => t.Id == key);
            return new DalTask()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreationDateTime = task.CreationDateTime,
                DeadlineDate = task.DeadlineDate,
                DeadlineTime = task.DeadlineTime,
                TotalPoints = task.TotalPoints,
                Users = (from ut in task.UserTasks where ut.TaskId == task.Id select ut.User).Select(u => new DalUser()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    CreationDate = u.CreationDate,
                    RoleId = u.RoleId.Value,
                    RoleName = u.Role.Name
                }).ToList()
            };
        }

        public IEnumerable<DalTask> Find(Func<DalTask, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTask e)
        {
            var task = new Task()
            {
                Title = e.Title,
                Description = e.Description,
                CreationDateTime = e.CreationDateTime,
                DeadlineDate = e.DeadlineDate,
                DeadlineTime = e.DeadlineTime,
                TotalPoints = e.TotalPoints
            };
            _context.Set<Task>().Add(task);
        }

        public void Delete(DalTask e)
        {
            var task = _context.Set<Task>().FirstOrDefault(t => t.Id == e.Id);
            _context.Set<Task>().Remove(task);
        }

        public void Update(DalTask e)
        {
            var task = _context.Set<Task>().FirstOrDefault(t => t.Id == e.Id);
            task.Title = e.Title;
            task.Description = e.Description;
            task.DeadlineDate = e.DeadlineDate;
            task.DeadlineTime = e.DeadlineTime;
            task.TotalPoints = e.TotalPoints;
        }

        public void AssignTask(DalTask e)
        {
            foreach (var user in e.Users)
            {
                _context.Set<UserTask>().Add(new UserTask()
                {
                    UserId = user.Id,
                    TaskId = e.Id,
                    PointsCompleted = 0,
                    StatusId = _context.Set<Status>().FirstOrDefault(s => s.Name == "In progress").Id
                });
            }
        }

        public IEnumerable<DalStatus> GetAllStatuses
        {
            get
            {
                return _context.Set<Status>().Select(s => new DalStatus()
                {
                    Id = s.Id,
                    Name = s.Name
                });
            }
        }

        public void UpdateUserTask(DalUserTask userTask)
        {
            var ut =
                _context.Set<UserTask>().FirstOrDefault(u => u.UserId == userTask.UserId && u.TaskId == userTask.TaskId);
            if (userTask.PointsCompleted != 0)
            {
                ut.PointsCompleted = userTask.PointsCompleted;
            }
            if (userTask.StatusId != 0)
            {
                ut.StatusId = userTask.StatusId;
            }
            if (ut.Task.TotalPoints == userTask.PointsCompleted | ut.Task.TotalPoints == ut.PointsCompleted)
            {
                ut.StatusId = _context.Set<Status>().FirstOrDefault(s => s.Name == "Completed").Id;
            }
        }
    }
}
