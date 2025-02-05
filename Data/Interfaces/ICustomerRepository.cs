using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerEntity> CreateCustomerEntityAsync(CustomerEntity entity);
        Task<bool> DeleteCustomerEntityAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<IEnumerable<CustomerEntity>> GetAllCustomerEntityAsync();
        Task<CustomerEntity> GetCustomerEntityAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<CustomerEntity> UpdateCustomerEntityAsync(CustomerEntity updatedEntity);
    }
}