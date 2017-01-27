using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class ExceptionService : IExceptionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IExceptionRepository _exceptionRepository;

        public ExceptionService(IUnitOfWork uow, IExceptionRepository exceptionRepository)
        {
            _uow = uow;
            _exceptionRepository = exceptionRepository;
        }

        public IEnumerable<ExceptionEntity> GetAllExceptionEntities()
        {
            return _exceptionRepository.GetAll().Select(exc => new ExceptionEntity()
            {
                Id = exc.Id,
                ExceptionMessage = exc.ExceptionMessage,
                ControllerName = exc.ControllerName,
                ActionName = exc.ActionName,
                StackTrace = exc.StackTrace,
                Date = exc.Date
            });
        }

        public void CreateException(ExceptionEntity exception)
        {
           _exceptionRepository.Create(new DalException()
           {
               ExceptionMessage = exception.ExceptionMessage,
               ControllerName = exception.ControllerName,
               ActionName = exception.ActionName,
               StackTrace = exception.StackTrace,
               Date = exception.Date
           });
            _uow.Commit();
        }

        public void DeleteException(ExceptionEntity exception)
        {
            _exceptionRepository.Delete(new DalException()
            {
                Id = exception.Id
            });
            _uow.Commit();
        }
    }
}
