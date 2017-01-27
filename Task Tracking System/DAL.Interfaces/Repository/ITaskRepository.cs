using System.Collections.Generic;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface ITaskRepository : IRepository<DalTask>
    {
        IEnumerable<DalStatus> GetAllStatuses { get; }
        void AssignTask(DalTask task);
        void UpdateUserTask(DalUserTask userTask);
    }
}
