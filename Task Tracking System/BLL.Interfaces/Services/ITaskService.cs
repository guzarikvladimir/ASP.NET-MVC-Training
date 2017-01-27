using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface ITaskService
    {
        Task<TaskEntity> GetTaskEntity(int id);
        IEnumerable<TaskEntity> GetAllTaskEntities();
        void CreateTask(TaskEntity task);
        void DeleteTask(TaskEntity task);
        void UpdateTask(TaskEntity task);
        void AssignTask(TaskEntity task);
        IEnumerable<StatusEntity> GetAllStatuses { get; }
        TaskEntity GetTaskByTitle(string title);
        void UpdateUserTaskEntity(UserTaskEntity userTask);
    }
}
