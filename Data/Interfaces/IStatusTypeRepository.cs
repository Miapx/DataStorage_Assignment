using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IStatusTypeRepository
    {
        Task<StatusTypeEntity> CreateStatusTypeEntityAsync(StatusTypeEntity entity);
        Task<bool> DeleteStatusTypeEntityAsync(Expression<Func<StatusTypeEntity, bool>> expression);
        Task<IEnumerable<StatusTypeEntity>> GetAllStatusTypeEntityAsync();
        Task<StatusTypeEntity> GetStatusTypeEntityAsync(Expression<Func<StatusTypeEntity, bool>> expression);
        Task<StatusTypeEntity> UpdateStatusTypeEntityAsync(StatusTypeEntity updatedEntity);
    }
}