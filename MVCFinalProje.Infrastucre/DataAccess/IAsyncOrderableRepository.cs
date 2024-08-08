using MVC_FinalProje.Domain.Core.BaseEntities;
using System.Linq.Expressions;

namespace MVCFinalProje.Infrastucre.DataAccess
{
    public  interface IAsyncOrderableRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> orderBy, bool orderBySDesc, bool tracking = true); // hepsini getir çoklu sorgu koşullu
        Task<IEnumerable<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> orderBy, bool orderBySDesc, bool tracking = true); // koşula göre getir. Overload çoklu sorgu koşullu // TKey kullanımı orderBy ile alakalı.
    }
}