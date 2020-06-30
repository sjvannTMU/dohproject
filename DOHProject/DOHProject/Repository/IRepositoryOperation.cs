using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DOHProject.Repository
{
    interface IRepositoryOperation<T> where T:class
    {
        T GetById(int id);
        IQueryable<T> GetAll(int pid = 0);
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression, int pid = 0);
        T Create(T Model);
        T Update(T Model);
        bool Delete(int id);
    }
}
