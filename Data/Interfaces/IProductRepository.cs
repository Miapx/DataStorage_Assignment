using Data.Entities;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> CreateProductEntityAsync(ProductEntity entity);
        Task<bool> DeleteProductEntityAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<IEnumerable<ProductEntity>> GetAllProductEntityAsync();
        Task<ProductEntity> GetProductEntityAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<ProductEntity> UpdateProductEntityAsync(ProductEntity updatedEntity);
    }
}