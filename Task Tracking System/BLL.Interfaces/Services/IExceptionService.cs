using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IExceptionService
    {
        IEnumerable<ExceptionEntity> GetAllExceptionEntities();
        void CreateException(ExceptionEntity exception);
        void DeleteException(ExceptionEntity exception);
    }
}
