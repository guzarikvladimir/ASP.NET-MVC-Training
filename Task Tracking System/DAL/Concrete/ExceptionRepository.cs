using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using Exception = ORM.Exception;

namespace DAL.Concrete
{
    public class ExceptionRepository : IExceptionRepository
    {
        private readonly DbContext _context;

        public ExceptionRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<DalException> GetAll()
        {
            return _context.Set<Exception>().Select(exc => new DalException()
            {
                Id = exc.Id,
                ExceptionMessage = exc.ExceptionMessage,
                ControllerName = exc.ControllerName,
                ActionName = exc.ActionName,
                StackTrace = exc.StackTrace,
                Date = exc.Date
            });
        }

        public Task<DalException> GetById(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalException> Find(Func<DalException, bool> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalException e)
        {
            var exception = new Exception()
            {
                ExceptionMessage = e.ExceptionMessage,
                ControllerName = e.ControllerName,
                ActionName = e.ActionName,
                StackTrace = e.StackTrace,
                Date = e.Date
            };
            _context.Set<Exception>().Add(exception);
        }

        public void Delete(DalException e)
        {
            var exception = _context.Set<Exception>().FirstOrDefault(exc => exc.Id == e.Id);
            _context.Set<Exception>().Remove(exception);
        }

        public void Update(DalException e)
        {
            throw new NotImplementedException();
        }
    }
}
