using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _uow;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IUnitOfWork uow, ITaskRepository repository)
        {
            _uow = uow;
            _taskRepository = repository;
        }

        public IEnumerable<TaskEntity> GetAllTaskEntities()
        {
            return _taskRepository.GetAll().Select(t => new TaskEntity()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreationDateTime = t.CreationDateTime,
                DeadlineDate = t.DeadlineDate,
                DeadlineTime = t.DeadlineTime,
                TotalPoints = t.TotalPoints
            });
        }

        public async Task<TaskEntity> GetTaskEntity(int id)
        {
            var t = await _taskRepository.GetById(id);
            return new TaskEntity()
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
                StatusName = t.StatusName,
                Users = t.Users.Select(u => new UserEntity()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    CreationDate = u.CreationDate,
                    RoleId = u.RoleId,
                    RoleName = u.RoleName
                }).ToList()
            };
        }

        public TaskEntity GetTaskByTitle(string title)
        {
            var task = _taskRepository.GetAll().FirstOrDefault(t => t.Title == title);
            return new TaskEntity()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreationDateTime = task.CreationDateTime,
                DeadlineDate = task.DeadlineDate,
                DeadlineTime = task.DeadlineTime,
                TotalPoints = task.TotalPoints,
                PointsCompleted = task.PointsCompleted,
                StatusId = task.StatusId,
                StatusName = task.StatusName,
                Users = task.Users.Select(u => new UserEntity()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    CreationDate = u.CreationDate,
                    RoleId = u.RoleId,
                    RoleName = u.RoleName
                }).ToList()
            };
        }

        public void CreateTask(TaskEntity task)
        {
            _taskRepository.Create(new DalTask()
            {
                Title = task.Title,
                Description = task.Description,
                CreationDateTime = task.CreationDateTime,
                DeadlineDate = task.DeadlineDate,
                DeadlineTime = task.DeadlineTime,
                TotalPoints = task.TotalPoints
            });
            _uow.Commit();
        }

        public void DeleteTask(TaskEntity task)
        {
            _taskRepository.Delete(new DalTask()
            {
                Id = task.Id
            });
            _uow.Commit();
        }

        public void UpdateTask(TaskEntity task)
        {
            _taskRepository.Update(new DalTask()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DeadlineDate = task.DeadlineDate,
                DeadlineTime = task.DeadlineTime,
                TotalPoints = task.TotalPoints
            });
            _uow.Commit();
        }

        public void AssignTask(TaskEntity task)
        {
            _taskRepository.AssignTask(new DalTask()
            {
                Id = task.Id,
                Users = task.Users.Select(u => new DalUser()
                {
                    Id = u.Id
                }).ToList()
            });
            _uow.Commit();
        }

        public IEnumerable<StatusEntity> GetAllStatuses
        {
            get
            {
                return _taskRepository.GetAllStatuses.Select(s => new StatusEntity()
                {
                    Id = s.Id,
                    Name = s.Name
                });
            }
        }

        public void UpdateUserTaskEntity(UserTaskEntity userTask)
        {
            _taskRepository.UpdateUserTask(new DalUserTask()
            {
                UserId = userTask.UserId,
                TaskId = userTask.TaskId,
                PointsCompleted = userTask.PointsCompleted,
                StatusId = userTask.StatusId
            });
            _uow.Commit();
        }
    }
}
