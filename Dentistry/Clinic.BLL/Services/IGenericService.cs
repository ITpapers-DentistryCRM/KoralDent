using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Services
{
    public interface IGenericService<T, TKey> where T : class, new()
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(TKey id);
        T Add(T obj);
        T Update(T obj);
        T Delete(TKey id);
    }
}
