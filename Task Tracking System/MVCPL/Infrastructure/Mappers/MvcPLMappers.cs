using System.Linq;
using BLL.Interfaces.Entities;
using MVCPL.Models;

namespace MVCPL.Infrastructure.Mappers
{
    public static class MvcplMappers
    {
        public static UserViewModel ToMvcUser(this UserEntity userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate,
                RoleId = userEntity.RoleId,
                Role = userEntity.RoleName,
                Tasks = userEntity.Tasks.Select(t => new TaskViewModel()
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

        public static TaskViewModel ToMvcTask(this TaskEntity task)
        {
            return new TaskViewModel
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
                Users = task.Users?.Select(u => new UserViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    CreationDate = u.CreationDate,
                    RoleId = u.RoleId
                }).ToList()
            };
        }

        public static TaskEntity ToBllTask(this TaskViewModel task)
        {
            return new TaskEntity
            {
                Title = task.Title,
                Description = task.Description,
                CreationDateTime = task.CreationDateTime,
                DeadlineDate = task.DeadlineDate,
                DeadlineTime = task.DeadlineTime,
                TotalPoints = task.TotalPoints,
                PointsCompleted = task.PointsCompleted,
                StatusId = task.StatusId,
                Users = task.Users?.Select(u => new UserEntity()
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    CreationDate = u.CreationDate,
                    RoleId = u.RoleId
                }).ToList()
            };
        }

        public static ExceptionEntity ToBllException(this ExceptionViewModel exception)
        {
            return new ExceptionEntity()
            {
                ExceptionMessage = exception.ExceptionMessage,
                ControllerName = exception.ControllerName,
                ActionName = exception.ActionName,
                StackTrace = exception.StackTrace,
                Date = exception.Date
            };
        }

        public static ExceptionViewModel ToMvcException(this ExceptionEntity exception)
        {
            return new ExceptionViewModel()
            {
                Id = exception.Id,
                ExceptionMessage = exception.ExceptionMessage,
                ControllerName = exception.ControllerName,
                ActionName = exception.ActionName,
                StackTrace = exception.StackTrace,
                Date = exception.Date
            };
        }
    }
}