using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace General.Repository.Commons
{

    public interface IGenericRepository<T, TKey> where T : class, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(TKey id);//
        void Create(T obj);
        void Update(T obj);
        void Delete(TKey id);
        void Save();
    }
}
