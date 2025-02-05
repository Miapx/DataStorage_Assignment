using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> CreateUserEntityAsync(UserEntity entity);
        Task<bool> DeleteUserEntityAsync(Expression<Func<UserEntity, bool>> expression);
        Task<IEnumerable<UserEntity>> GetAllUserEntityAsync();
        Task<UserEntity> GetUserEntityAsync(Expression<Func<UserEntity, bool>> expression);
        Task<UserEntity> UpdateUserEntityAsync(UserEntity updatedEntity);
    }
}