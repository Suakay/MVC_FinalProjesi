using MVC_FinalProje.Domain.Core.BaseEntities;
using System.Linq.Expressions;

namespace MVCFinalProje.Infrastucre.DataAccess
{
    public interface IAsyncQueryableRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking=true);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression,bool tracking=true);
    }
}